using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_App
{
    internal class Voiture
    {
        public string licensePlate { get; set; }
        public bool is_ActuallyInThePark { get; set; }
        public Voiture(string _licensePlate) { 
            licensePlate = _licensePlate;
            is_ActuallyInThePark = true;
        }
    }
}
