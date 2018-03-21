﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // API för hämtning av data från SQL
using System.Windows.Forms.DataVisualization.Charting; // API för att kunna visualisera datan i charter.

namespace Airbnb
{
    public partial class Visualisering : Form
    {
        public Visualisering()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // skapa en lista med citynames, för Boston, Amsterdam & Barcelona
            List<string> cityNames = new List<string>
            {
                "Boston", "Amsterdam", "Barcelona"
            };
            List<City> cities = new List<City>();
            

            SqlConnection conn = new SqlConnection(); // Skapa en koppling med SQL, kopplingsnamn "conn"

            conn.ConnectionString = "Data Source=DESKTOP-0KMEDJA\\SQL2017;Initial Catalog=airbnbtest;Integrated Security=True";


            foreach (var item in cityNames) // Foreach, loopar igenom dem olika städerna.
            {

                
                try
                {
                    conn.Open(); // öppna kopplingen
                    List<Accommodation> AccommodationList = new List<Accommodation>(); //skapa en lista med alla Accommodations

                    SqlCommand myQuery = new SqlCommand("SELECT * FROM " + item + ";", connection: conn); // ITEM = Citynames

                    SqlDataReader myReader = myQuery.ExecuteReader();


                    // Deklarerar de variabler jag vill använda för att tanka in mina värden i.
                    int Room_id;
                    int Host_id;
                    string Room_type;
                    string Borough;
                    string Neighborhood;
                    int Reviews;
                    double Overall_Satisfaction;
                    double Bedrooms;
                    int Accommodates;
                    double Price;
                    int Minstay;
                    double Latitude;
                    double Longitude;
                    string Last_modified;

                                // tillfälliga strängar som sedan konverteras till double.
                                string letOS; 
                                string letBed;
                                string letPrice;
                                string letLat;
                                string letLong;
                                bool MinstayTest; // Bool, för att testa om minstay är 'null' eller har värde




                    while (myReader.Read())
                    {
                        Room_id = (int)myReader["Room_id"];
                        Host_id = (int)myReader["Host_id"];
                        Room_type = (string)myReader["Room_type"];

                        if (myReader["borough"] is String) //hanterar ifall borough är null
                        {
                            Borough = (string)myReader["borough"];
                        }
                        else
                        {
                            Borough = "";
                        }
                        Neighborhood = myReader["Neighborhood"].ToString();
                        Reviews = (int)myReader["reviews"];
                            letOS = myReader["Overall_Satisfaction"].ToString(); //tillfällig
                        Overall_Satisfaction = double.Parse(letOS);
                            letBed = myReader["Bedrooms"].ToString();  //tillfällig
                        Bedrooms = double.Parse(letBed);
                        Accommodates = (int)myReader["Accommodates"];
                            letPrice = myReader["Price"].ToString();  //tillfällig
                        Price = double.Parse(letPrice);

                        MinstayTest = int.TryParse(Convert.ToString(myReader["Minstay"]), out Minstay);
                        if (MinstayTest == false)
                        {
                            Minstay = 0;
                        }
                        else
                        {
                            Minstay = (int)myReader["Minstay"];
                        }
                            letLat = myReader["Latitude"].ToString();   //tillfällig
                        Latitude = double.Parse(letLat);
                            letLong = myReader["Longitude"].ToString();    //tillfällig
                        Longitude = double.Parse(letLong); 
                        Last_modified = myReader["Last_modified"].ToString();


                        //Skapa olika objekt som ska finnas i klassen Accommodation
                        Accommodation accommodations = new Accommodation(
                            Room_id,
                            Host_id,
                            Room_type,
                            Borough,
                            Neighborhood,
                            Reviews,
                            Overall_Satisfaction,
                            Accommodates,
                            Bedrooms,
                            Price,
                            Minstay,
                            Latitude,
                            Longitude,
                            Last_modified
                            );

                        // Lägger in objektet.
                        AccommodationList.Add(accommodations);

                    }

                    City city = new City(item, 0, 0, 0, AccommodationList);
                    cities.Add(city);

                    
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            foreach (City c in cities)  // För att kunna plocka fram önskad stad till de olika charterna.
            {
                switch (c.NameCity) //utgår från mina olika städer som finns i klassen City
                {
                    case "Boston":  //Om staden är Boston
                        foreach (Accommodation ac in c.Accommodates.Where(y => y.room_type == "Private room"))
                        {

                                Boston1.Series["Price"].Points.AddY(ac.Price);
                        };
                        break;
                    case "Amsterdam": // Om staden är Amsterdam
                        foreach (Accommodation ac in c.Accommodates.Where(y => y.room_type == "Private room"))
                        {

                            Amsterdam1.Series["Price"].Points.AddY(ac.Price);
                        };
                        break;
                    case "Barcelona": // Om staden är Barcelona
                        foreach (Accommodation ac in c.Accommodates.Where(y => y.room_type == "Private room"))
                        {

                            Barcelona1.Series["Price"].Points.AddY(ac.Price);
                        };
                        break;
                    default:
                        break;
                }
            }

            foreach (City c in cities)
            {
                switch (c.NameCity)
                {
                    case "Boston":
                        foreach (Accommodation ac in c.Accommodates.Where(y => y.overall_satisfaction != 0 && y.overall_satisfaction < 4.5))
                        {

                            Boston2.Series["OS"].Points.AddXY(ac.price, ac.overall_satisfaction);
                        };
                        break;
                    case "Amsterdam":
                        foreach (Accommodation ac in c.Accommodates.Where(y => y.overall_satisfaction != 0 && y.overall_satisfaction < 4.5))
                        {

                            Amsterdam2.Series["OS"].Points.AddXY(ac.price, ac.overall_satisfaction);
                        };
                        break;
                    case "Barcelona":
                        foreach (Accommodation ac in c.Accommodates.Where(y => y.overall_satisfaction != 0 && y.overall_satisfaction < 4.5))
                        {

                            Barcelona2.Series["OS"].Points.AddXY(ac.price, ac.overall_satisfaction);
                        };
                        break;

                    default:
                        break;
                }
            }
            // Första charten, Boston 
            Boston1.Series["Price"].ChartType = SeriesChartType.Column;
            Boston1.Titles.Add("Boston Histogram");
            
            //
            Boston2.Series["OS"].ChartType = SeriesChartType.Point;
            Boston2.Series["Price"].ChartType = SeriesChartType.Point;
            Boston2.Titles.Add("Boston Scatterplot");

            Amsterdam1.Series["Price"].ChartType = SeriesChartType.Column;
            Amsterdam1.Titles.Add("Amsterdam Histogram");

            Amsterdam2.Series["OS"].ChartType = SeriesChartType.Point;
            Amsterdam2.Series["Price"].ChartType = SeriesChartType.Point;
            Amsterdam2.Titles.Add("Amsterdam Scatterplot");

            Barcelona1.Series["Price"].ChartType = SeriesChartType.Column;
            Barcelona1.Titles.Add("Barcelona Histogram");

            Barcelona2.Series["OS"].ChartType = SeriesChartType.Point;
            Barcelona2.Series["Price"].ChartType = SeriesChartType.Point;
            Barcelona2.Titles.Add("Barcelona Scatterplot");
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}