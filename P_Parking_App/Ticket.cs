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

        public Ticket(Voiture _LinkedCar, int _PlaceNumber) { 
            EntryHour = DateTime.Now;
            LinkedCar = _LinkedCar;
            PlaceNumber = _PlaceNumber;
            ShowInfo();
        }
        private void ShowInfo()
        {
            Console.WriteLine($@"Heure d'entrée    : {EntryHour}
Place du vehicule : N°{PlaceNumber}
Tarif horaire     : {RATE}.-/h");
        }
        public double calculatePrice()
        {
            Price = (EntryHour.CompareTo(DateTime.Now))*RATE;
            return 0;
        }
    }
}
