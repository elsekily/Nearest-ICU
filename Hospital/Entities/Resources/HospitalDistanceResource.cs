using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Entities.Resources
{
    public class HospitalDistanceResource
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int FreeUnits { get; set; }
        public double Distance { get; set; }
    }
}
