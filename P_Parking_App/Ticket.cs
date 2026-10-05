using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_Parking_App
{
    /// <summary>
    /// Classe <c>Ticket</c> stocke les données des vehicules dans la parking.
    /// </summary>
    public class Ticket
    {
        public Voiture LinkedCar { get; set; }
        public double Price { get; set; }
        private const double RATE = 2.50; 
        public TimeSpan elapsedTime {get; set;}
        public DateTime entryHour { get; set; }
        public DateTime exitHour { get; set; }
        public int PlaceNumber { get; set; }
        public Stopwatch CarStopWatch { get; set; } //Compte le temps passé dans la parking
        public bool Lefting = false;

        public Ticket(Voiture linkedCar, int placeNumber) {
            Price = 0;
            LinkedCar = linkedCar;
            PlaceNumber = placeNumber;
            entryHour = DateTime.Now;
            CarStopWatch = Stopwatch.StartNew();
            CarStopWatch.Start();
            
        }
        /// <summary>
        /// Méthode <c>CalculatePrice</c> calcule le prix du ticket selon le temps passé dans le parking et le tarif horraire
        /// </summary>
        /// <returns>
        /// un <see cref="Double"/> avec le prix du ticket.
        /// </returns>
        public double CalculatePrice()
        {
            Price = Math.Round(GetElapsedTime().TotalHours, 2)* RATE;
            if (Price == 0)
            {
                Price = 0.10;
            }
            return Price;
        }
        /// <summary>
        /// Méthode <c>GetElapsedTime</c> permet de récupérer le temps passé dans le parking.
        /// </summary>
        /// <returns>
        /// Un <see cref="TimeSpan"/> qui est le temps passé dans le parking
        /// </returns>
        public TimeSpan GetElapsedTime()
        {
            return this.CarStopWatch.Elapsed;
        } 
        /// <summary>
        /// Méthode <c>ToString</c> permet de modifier les informations du ToString de Ticket
        /// </summary>
        /// <returns>
        /// Un <see cref="String"/> contenant les informations du ticket.
        /// </returns>
        public override string ToString()
        {
            string priceTot = string.Format("{0:0.00}", Price);
            string minutes = string.Format("{0:00}", GetElapsedTime().TotalMinutes);
            string secondes = string.Format("{0:00}", GetElapsedTime().TotalSeconds);
            if (Price == 0)
            {
                return $@"Heure d'entrée    : {entryHour}
Place du vehicule : N°{PlaceNumber}
Tarif horaire     : {RATE}.-/h";
            }
            else if (Lefting)
            {
                return $@"Heure d'entrée    : {entryHour}
Heure de sortie   : {DateTime.Now}
Temps passé dans le parking : {Math.Round(GetElapsedTime().TotalHours)}h{minutes}:{secondes}
Place du vehicule : N°{PlaceNumber}
Tarif horaire     : {RATE}.-/h
Prix du ticket    : {priceTot}.-";
            }
            else
            {
                return $@"Heure d'entrée    : {entryHour}
Heure de sortie   : {exitHour.Date}
Temps passé dans le parking : {Math.Round(GetElapsedTime().TotalHours)}h{minutes}:{secondes}
Place du vehicule : N°{PlaceNumber}
Tarif horaire     : {RATE}.-/h
Prix du ticket    : {priceTot}.-";
            }
        }  
    }
}
