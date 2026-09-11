using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_App
{
    internal class Ticket
    {
        public Voiture linkedCar { get; set; }
        public int price { get; set; }
        public Ticket(Voiture _linkedCar) { 
            linkedCar = _linkedCar;
            price = 0;
        }
    }
}
