using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airbnb
{
    class Country // skapa en klass för länder 
    {
        public Country(string name, int citizen, int bnp, List<City> cities)
        {
            Name = name;
            Citizen = citizen;
            Bnp = bnp;
            Cities = cities;
        }

        public string Name { get; set; }
        public int Citizen { get; set; }
        public int Bnp { get; set; }
        public List<City> Cities { get; } = new List<City>();
    }
}
