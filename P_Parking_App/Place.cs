using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_App
{
    internal class Place
    {
        public int number { get; set; }
        public bool is_empty { get; set; }
        public int nbrOfUse { get; set; }
        //variable qui stock la voiture qu'il occupe
        public Place(int _number) {
            is_empty = true;
            nbrOfUse = 0;
            number = _number;

        }
    }
}
