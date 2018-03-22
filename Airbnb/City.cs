using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb
{
    class City // skapa en klass för Städer
               // Jerome comment: Jag tror att det skulle vara bättre att skapa variable som private först och deklarerar dem public senare
    {
        public City(
            string nameCity, 
            int citizenCity, 
            double MiddleIncome, 
            int tourist, 
            List<Accommodation> accommodates
            )
        
        {
            NameCity = nameCity;
            CitizenCity = citizenCity;
            MiddleIncome = middleIncome;
            Tourist = tourist;
            Accommodates = accommodates;

            AverageCost = accommodates.Average(a => a.price);   // LINQ, beräkna medelvärde
            countValues = accommodates.Count();    // LINQ, beräkna antal
        }

        public string NameCity { get; set; }
        public int CitizenCity { get; set; }
        public double middleIncome { get; set; }
        public int Tourist { get; set; }
        public List<Accommodation> Accommodates { get; } = new List<Accommodation>();
        public int AccommodationCount
        {
            get { return Accommodates.Count; }
        }
        public double AverageCost { get; set; }
        public int countValues { get; set; }
    }
}
