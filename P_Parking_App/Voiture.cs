using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_App
{
    internal class Voiture
    {
        public string LicensePlate { get; set; }
        public bool IsActuallyInThePark { get; set; }
        public Voiture(string _licensePlate) { 
            LicensePlate = _licensePlate;
            IsActuallyInThePark = true;
        }
    }
}
