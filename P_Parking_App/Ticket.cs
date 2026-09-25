using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_App
{
    internal class Ticket
    {
        public Voiture LinkedCar { get; set; }
        public double Price { get; set; }
        private const double RATE = 2.50; 
        public DateTime EntryHour {get; set;}
        public int PlaceNumber { get; set; }

        public Ticket(Voiture linkedCar, int placeNumber) {
            Price = 0;
            EntryHour = DateTime.Now;
            LinkedCar = linkedCar;
            PlaceNumber = placeNumber;
            Console.WriteLine(this.ToString());
        }
        public double CalculatePrice()
        {
            Price = (DateTime.Now.CompareTo(EntryHour))*RATE;
            return Price;
        }
        public override string ToString()
        {
            if (Price == 0)
            {
                return $@"Heure d'entrée    : {EntryHour}
Place du vehicule : N°{PlaceNumber+1}
Tarif horaire     : {RATE}.-/h";
            }
            else
            {
                return $@"Heure d'entrée    : {EntryHour}
Place du vehicule : N°{PlaceNumber+1}
Tarif horaire     : {RATE}.-/h
Prix du ticket : {Price}";
            }
        }
    }
}
