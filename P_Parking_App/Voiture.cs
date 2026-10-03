using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_App
{
    public class Voiture
    {
        public string LicensePlate { get; set; }
        public bool IsActuallyInThePark { get; set; }
        public Voiture(string licensePlate) { 
            LicensePlate = licensePlate;
            LicensePlate = LicensePlate.ToLower();
            IsActuallyInThePark = true;
        }
    }
}
