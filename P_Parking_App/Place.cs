using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_App
{
    internal class Place
    {
        public Voiture ActualCar { get; set; }
        //variable qui stock la voiture qu'il occupe
        public Place(Voiture actualCar) {
            this.ActualCar = actualCar;
        }
    }
}
