using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_Parking_App;

namespace P_Parking_App
{
    internal class Parking
    {
        int empty = 0;
        public Place[] ParkingPlace { get; set; }
        public List<Voiture> CarList { get; set; }
        public List<Ticket> TicketList { get; set; }
        public Parking(int _nbrPlace) { 
            ParkingPlace = new Place[_nbrPlace];
            CarList = new List<Voiture>();
            TicketList = new List<Ticket>();
        }
        public void ShowTable()
        {
            Console.WriteLine("Table\n");
        }
        private void ShowMessage(int messageId)
        {
            switch (messageId)
            {
                case 0 : Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"La voiture avec la plaque : << {this.CarList[this.CarList.Count() - 1].LicensePlate} >> à bien été ajoutée !"); break;
                case 1 : Console.ForegroundColor = ConsoleColor.Red;  Console.WriteLine("La voiture n'as pas pu être ajoutée pour cause de manque de place."); break;
                case 2 : Console.ForegroundColor = ConsoleColor.Red;  Console.WriteLine("La norme pour la plaque n'as pas été respectée ! Exemple : VD-274891"); break;
                case 3: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"Une voiture ayant la plaque : <<{this.CarList[this.CarList.Count() - 1].LicensePlate}>> existe déjà dans le parking"); break;
            }
        }
        public void EnterVehicule(String licensePLate)
        {
            bool isCheckGood = false;
            int _LicenseCheck = CheckLicensePlate(licensePLate);
            if (_LicenseCheck == 1)
            {
                
                for (int i  = 0; i < ParkingPlace.Length; i++)
                {
                        if (ParkingPlace[i] ==  null)
                        {
                            CarList.Add(new Voiture(licensePLate));
                            ParkingPlace[i] = new Place(CarList[CarList.Count - 1]);
                            TicketList.Add(new Ticket(CarList[CarList.Count-1],i));
                            isCheckGood = true;
                            ShowMessage(0);
                            break;
                        }
                }
                if (!isCheckGood){
                    isCheckGood = true;
                    ShowMessage(1);
                }
                
            }
            if (!isCheckGood){
                    isCheckGood = true;
                if (_LicenseCheck == 0){
                    ShowMessage(2);
                }
                else
                {
                    ShowMessage(3);
                }
            }
        }
        private int CheckLicensePlate(string licensePLate)
        {
            int _nbrLettre =0;
            int _nbrDigit = 0;
            bool _IsUnion = false;
            int _licensePlateLenght = 0;
            licensePLate = licensePLate.ToLower();
            int _numberOfIteration=0;
            foreach (char c in licensePLate)
            {
                _numberOfIteration++;
                if (char.IsDigit(c) && _numberOfIteration >= 4 && _numberOfIteration <= 6)
                {
                    _nbrDigit++;
                }
                else if (c == '-' && _numberOfIteration == 3)
                {
                    _IsUnion = true;
                }
                else if (char.IsLetter(c) && (_numberOfIteration == 1 || _numberOfIteration == 2))
                {
                    _nbrLettre++;
                }
                _licensePlateLenght++;
                if (_nbrLettre == 2 && _nbrDigit == 6 && _IsUnion == true && _licensePlateLenght == licensePLate.Length)
                {
                    foreach (Voiture v in CarList)
                    {
                        if (v.LicensePlate == licensePLate)
                        {
                            return 2;
                        }
                    }
                    return 1;
                }
            }
            return 0;
        }
        private int CountOccupedPlace()
        {
            int count = 0;
            foreach (Place place in ParkingPlace)
                {
                    if (place != null)
                    {
                        count++;
                    }
                }
            return count;
        }
        public void ShowCar()
        {
            //Faire un foreach du tableau des voitures
            //Puis mettre "Place {car[b].place} : {car[b].licensePlate} (depuis {car[b].time})"
        }
        public void ShowMenu()
        {Console.Write(@"=== MENU PRINCIPAL ===
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
        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine($@"=== ÉTAT DU PARKING ===
Places totales : {this.ParkingPlace.Count().ToString()}
Places occupées : {CountOccupedPlace()}
Places libres : {ParkingPlace.Length - CountOccupedPlace()}
Taux d'occupation : {CountOccupedPlace() * 5}%
");

            Console.WriteLine($"Plan du parking (L=libre, X=Occupé) :");
            ShowTable();
            Console.WriteLine("Véhicules présents:\n");
            Console.ReadLine();

        }
    }
}
