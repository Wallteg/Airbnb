using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb
{
    class Country // skapa en klass för länder 
                  // Jerome comment:Jag tror att det skulle vara bättre att skapa variable som private först och deklarerar dem public senare. 
                  // Också i variable namn= det skulle vara bara att använda nåt som säger det handlar om Country till exempel countryNamn  
    {
        public Country(string name, int citizen, int bnp, List<City> cities)
        {
            Name = name;
            Citizen = citizen;
            Bnp = bnp;
            Cities = cities;
            int i = 0;
        }

        public string Name { get; set; }
        public int Citizen { get; set; }
        public int Bnp { get; set; }
        public List<City> Cities { get; } = new List<City>();
    }
}
