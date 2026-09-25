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
        public Place[] ParkingPlace { get; set; }
        public List<Voiture> CarList { get; set; }
        public List<Ticket> TicketList { get; set; }
        public Parking(int nbrPlace) { 
            ParkingPlace = new Place[nbrPlace];
            CarList = new List<Voiture>();
            TicketList = new List<Ticket>();
        }
        public void ShowTable()
        {
            int actualCase = 0;
            Console.WriteLine(@"
X = Occupé
L = Libre
            ");
            Console.WriteLine("Plan du parking : \n╔═════════╦═════════╦═════════╦═════════╦═════════╗");
            for (int i = 0;i < 4; i++)
            {
                Console.Write("║");
                for(int j = 0; j < 5;j++)
                {
                    if (this.ParkingPlace[actualCase] != null)
                    {
                        if (actualCase <= 8){
                        Console.Write($" N°{actualCase+1}   X ║");}
                        else
                        {
                            Console.Write($" N°{actualCase+1}  X ║");
                        }
                    }
                    else
                    {
                        if (actualCase <= 8){
                        Console.Write($" N°{actualCase+1}   L ║");}
                        else
                        {
                            Console.Write($" N°{actualCase+1}  L ║");
                        }
                    }
                    actualCase++;
                }
                Console.WriteLine();
                if (i < 3){
                    Console.WriteLine("╠═════════╬═════════╬═════════╬═════════╬═════════╣");
                }
            }
            Console.WriteLine("╚═════════╩═════════╩═════════╩═════════╩═════════╝");
        }
        private void ShowMessage(int messageId)
        {
            switch (messageId)
            {
                case 0: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"La voiture avec la plaque : << {this.CarList[this.CarList.Count() - 1].LicensePlate} >> à bien été ajoutée !"); break;
                case 1: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("La voiture n'as pas pu être ajoutée pour cause de manque de place."); break;
                case 2: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("La norme pour la plaque n'as pas été respectée ! Exemple : VD-274891"); break;
                case 3: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"Une voiture ayant la plaque : <<{this.CarList[this.CarList.Count() - 1].LicensePlate}>> existe déjà dans le parking"); break;
                case 4: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("La voiture mensionée n'est pas dans le parking."); break;
                case 5: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Cet place est actuellement libre"); break;
                case 6: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Cet place ne fait pas parti du Parking."); break;
            }
        }
        public void SearchVehicule(string vehiculeInfo)
        {
            bool vehiculeFound = false;
            bool place = false;
            Console.Clear();
            if (vehiculeInfo.Length > 2)
            {
                for (int i = 0; i < ParkingPlace.Length; i++)
                {
                    if (ParkingPlace[i] != null && ParkingPlace[i].ActualCar.LicensePlate == vehiculeInfo)
                    {
                        Voiture thisCar = ParkingPlace[i].ActualCar;
                        foreach (Ticket t in TicketList)
                        {
                            if (t.LinkedCar == thisCar)
                            {
                                vehiculeFound = true;
                                Console.WriteLine($"{t.ToString()} \nPlaque d'immatriculation : <<{thisCar.LicensePlate}>>");
                            }

                        }
                    }
                }
            }
            else
            {
                place = true;
                if (this.ParkingPlace[int.Parse(vehiculeInfo)] != null)
                {
                    for (int i = 0; i < TicketList.Count(); i++)
                    {
                        if (TicketList[i].PlaceNumber == int.Parse(vehiculeInfo) && TicketList[i].Price == 0)
                        {
                            vehiculeFound = true;
                            Console.WriteLine(TicketList[i].ToString());
                            Console.WriteLine($"Plaque d'immatriculation : <<{TicketList[i].LinkedCar.LicensePlate}>>");
                        }
                    }
                }
            }


            if (!vehiculeFound)
            {
                if (place)
                {
                    this.ShowMessage(5);
                }
                else
                {
                    this.ShowMessage(4);
                }
            }
        }
        public void ExitVehicule(string vehiculeInfo)
        {
            bool vehiculeFound = false;
            bool place = false;
            if (vehiculeInfo.Length > 2)
            { 
                for (int i = 0; i < ParkingPlace.Length; i++)
                {
                    if (ParkingPlace[i] != null && ParkingPlace[i].ActualCar.LicensePlate == vehiculeInfo)
                    {
                        Voiture thisCar = ParkingPlace[i].ActualCar;
                        foreach (Ticket t in TicketList)
                        {
                            if (t.LinkedCar == thisCar)
                            {
                                vehiculeFound = true;
                                ExitChoice( thisCar, t, i);
                            }

                        }
                    }
                }
            }
            else
            { 
                place = true;
                if ( int.IsPositive(int.Parse(vehiculeInfo)) && this.ParkingPlace[int.Parse(vehiculeInfo)] != null)
                {
                    for (int i = 0; i < TicketList.Count(); i++)
                    {
                        if (TicketList[i].PlaceNumber == int.Parse(vehiculeInfo))
                        {
                            vehiculeFound = true;
                            ExitChoice(TicketList[i].LinkedCar, TicketList[i], i);
                        }
                    }
                }
            }
            

            if (!vehiculeFound)
            {
                if (!int.IsPositive(int.Parse(vehiculeInfo)))
                {
                    this.ShowMessage(6);
                }
                else if (place)
                {
                    this.ShowMessage(5);
                }
                else
                {
                    this.ShowMessage(4);
                }
            }
        }
        private void ExitChoice( Voiture thisCar, Ticket t, int i)
        {
            t.CalculatePrice();
            Console.WriteLine(t.ToString());

            Console.Write("Voulez-vous vraiment faire sortir cette voiture ? (o/n) : ");
            if (Console.ReadLine() == "o")
            {
                thisCar.IsActuallyInThePark = false;
                ParkingPlace[i] = null;
                Console.WriteLine($"La place de parque N°{i} à été libérée.");
            }
            else
            {
                t.Price = 0;
                Console.WriteLine($"la place de parque N°{i} est toujours occupée.");
            }
        }
        public void EnterVehicule(String licensePLate)
        {
            bool isCheckGood = false;
            int licenseCheck = CheckLicensePlate(licensePLate);
            if (licenseCheck == 1)
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
                if (licenseCheck == 0){
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
            int nbrLettre =0;
            int nbrDigit = 0;
            bool isUnion = false;
            int licensePlateLenght = 0;
            licensePLate = licensePLate.ToLower();
            int numberOfIteration=0;
            foreach (char c in licensePLate)
            {
                numberOfIteration++;
                if (char.IsDigit(c) && numberOfIteration >= 4 && numberOfIteration <= 11)
                {
                    nbrDigit++;
                }
                if (c == '-' && numberOfIteration == 3)
                {
                    isUnion = true;
                }
                if (char.IsLetter(c) && (numberOfIteration == 1 || numberOfIteration == 2))
                {
                    nbrLettre++;
                }
                licensePlateLenght++;
                if (nbrLettre == 2 && nbrDigit == 6 && isUnion == true && licensePlateLenght == licensePLate.Length)
                {
                    foreach (Voiture v in CarList)
                    {
                        if (v.LicensePlate == licensePLate && v.IsActuallyInThePark)
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
