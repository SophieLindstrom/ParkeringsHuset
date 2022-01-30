using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsHuset.Models
{
    class Parkings
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string HouseName { get; set; }
        public int SlotNumber { get; set; }
        public bool ElectricOutlet { get; set; }
        public string Plate { get; set; }
        public string CarData { get; set; }
    }
}
