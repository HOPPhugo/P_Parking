using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public TimeSpan elapsedTime {get; set;}
        public DateTime entryHour { get; set; }
        public DateTime exitHour { get; set; }
        public int PlaceNumber { get; set; }
        public Stopwatch CarStopWatch { get; set; }
        public bool Lefting = false;

        public Ticket(Voiture linkedCar, int placeNumber) {
            Price = 0;
            LinkedCar = linkedCar;
            PlaceNumber = placeNumber;
            entryHour = DateTime.Now;
            CarStopWatch = Stopwatch.StartNew();
            CarStopWatch.Start();
            
        }
        public double CalculatePrice()
        {
            Price = Math.Round(GetElapsedTime().TotalHours, 2)* RATE;
            if (Price == 0)
            {
                Price = 0.10;
            }
            return Price;
        }
        public TimeSpan GetElapsedTime()
        {
            return this.CarStopWatch.Elapsed;
        }
        public override string ToString()
        {
            string priceTot = string.Format("{0:0.00}", Price);
            string minutes = string.Format("{0:00}", GetElapsedTime().TotalMinutes);
            string secondes = string.Format("{0:00}", GetElapsedTime().TotalSeconds);
            if (Price == 0)
            {
                return $@"Heure d'entrée    : {entryHour}
Place du vehicule : N°{PlaceNumber+1}
Tarif horaire     : {RATE}.-/h";
            }
            else if (Lefting)
            {
                return $@"Heure d'entrée    : {entryHour}
Heure de sortie   : {DateTime.Now}
Temps passé dans le parking : {Math.Round(GetElapsedTime().TotalHours)}h{minutes}:{secondes}
Place du vehicule : N°{PlaceNumber+1}
Tarif horaire     : {RATE}.-/h
Prix du ticket    : {priceTot}.-";
            }
            else
            {
                return $@"Heure d'entrée    : {entryHour}
Heure de sortie   : {exitHour.Date}
Temps passé dans le parking : {Math.Round(GetElapsedTime().TotalHours)}h{minutes}:{secondes}
Place du vehicule : N°{PlaceNumber + 1}
Tarif horaire     : {RATE}.-/h
Prix du ticket    : {priceTot}.-";
            }
        }
    }
}
