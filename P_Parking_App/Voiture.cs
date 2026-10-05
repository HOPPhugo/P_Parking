using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_App
{
    /// <summary>
    /// Classe <c>Voiture</c> qui contient la plaque d'immatriculation de la voiture et s'il est dans le parking ou non.
    /// </summary>
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
