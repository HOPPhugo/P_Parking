using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_Parking_App;

namespace P_Parking_App
{
    internal class Parking
    {
        int empty = 0;
        public Place[] parkingPlace { get; set; }
        public List<Voiture> car { get; set; }
        public List<Ticket> ticket { get; set; }
        public Parking(int nbrPlace) { 
            parkingPlace = new Place[nbrPlace];
            car = new List<Voiture>();
            ticket = new List<Ticket>();
            InitializePlace();
        }
        public void ShowTable()
        {
            Console.WriteLine("Table\n");
        }    
        private void InitializePlace()
        {
            for (int i = 0;  i < parkingPlace.Length; i++)
            {
                parkingPlace[i] = new Place(i);
            }
        }
        public void ShowCar()
        {
            //Faire un foreach du tableau des voitures
            //Puis mettre "Place {car[b].place} : {car[b].licensePlate} (depuis {car[b].time})"
        }
        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine($@"=== ÉTAT DU PARKING ===
Places totales : {empty}
Places occupées : {empty}
Places libres : {empty}
Taux d'occupation : {empty}
");

            Console.WriteLine($"Plan du parking (L=libre, X=Occupé) :");
            ShowTable();
            Console.WriteLine("Véhicules présents:\n");
            Console.Write(@"=== MENU PRINCIPAL ===
1. Entrée d'un véhicule
2. Sortie d'un véhicule
3. Afficher l'état du parking
4. Rechercher un véhicule
5. Statistiques du jour
6. Historique des transactions
Default : Quitter
");
            Console.Write("Votre choix : ");

        }
    }
}
