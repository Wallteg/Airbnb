using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb
{


    class Accommodation // skapa en klass för Boende
    {
        //Lista med variabler
        public int room_id;
        public int host_id;
        public string room_type;
        public string borough;
        public string neighborhood;
        public int reviews;
        public double overall_satisfaction;
        public int accommodates;
        public double bedrooms;
        public double price;
        public int minstay;
        public double latitude;
        public double longitude;
        public string last_modified;

        // konstruktor
        public Accommodation(
            int Room_id, 
            int Host_id, 
            string Room_type, 
            string Borough, 
            string Neighborhood, 
            int Reviews, 
            double Overall_satisfaction, 
            int Accommodates, 
            double Bedrooms, 
            double Price, 
            int Minstay, 
            double Latitude, 
            double Longitude, 
            string Last_modified
            )

        {
            room_id = Room_id;
            host_id = Host_id;
            room_type = Room_type;
            borough = Borough;
            neighborhood = Neighborhood;
            reviews = Reviews;
            overall_satisfaction = Overall_satisfaction;
            accommodates = Accommodates;
            bedrooms = Bedrooms;
            price = Price;
            minstay = Minstay;
            latitude = Latitude;
            longitude = Longitude;
            last_modified = Last_modified;
        }

        // getter setters
        public int Room_id
        {
            get { return room_id; }
            set { room_id = value; }
        }
        public int Host_id
        {
            get { return host_id; }
            set { host_id = value; }
        }
        public string Room_type
        {
            get { return room_type; }
            set { room_type = value; }
        }
        public string Borough
        {
            get { return borough; }
            set { borough = value; }
        }
        public string Neighborhood
        {
            get { return Neighborhood; }
            set { Neighborhood = value; }
        }
        public int Reviews
        {
            get { return reviews; }
            set { reviews = value; }
        }
        public double Overall_satisfaction
        {
            get { return overall_satisfaction; }
            set { overall_satisfaction = value; }
        }
        public int Accommodates
        {
            get { return accommodates; }
            set { accommodates = value; }
        }
        public double Bedrooms
        {
            get { return bedrooms; }
            set { bedrooms = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Minstay
        {
            get { return minstay; }
            set { minstay = value; }
        }
        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public string Last_modified
        {
            get { return last_modified; }
            set { last_modified = value; }
        }
    }
}
