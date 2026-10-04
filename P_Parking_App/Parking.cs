using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P_Parking_App;

namespace P_Parking_App
{
    public class Parking
    {
        public Place[] ParkingPlace { get; set; }
        public List<Voiture> CarList { get; set; }
        public List<Ticket> TicketList { get; set; }
        public double money = 0;
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
                        if (actualCase <= 9){
                        Console.Write($" N°{actualCase}   X ║");}
                        else
                        {
                            Console.Write($" N°{actualCase}  X ║");
                        }
                    }
                    else
                    {
                        if (actualCase <= 9){
                        Console.Write($" N°{actualCase}   L ║");}
                        else
                        {
                            Console.Write($" N°{actualCase}  L ║");
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

            Console.WriteLine("\n\nVéhicules présents : ");
            ShowCar();
        }
        private void ShowMessage(int messageId, Voiture actualCar)
        {
            switch (messageId)
            {
                case 0: Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"La voiture avec la plaque : << {actualCar.LicensePlate} >> à bien été ajoutée !"); break;
                case 1: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("La voiture n'as pas pu être ajoutée pour cause de manque de place."); break;
                case 2: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("La norme pour la plaque n'as pas été respectée ! Exemple : VD-274891"); break;
                case 3: Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"Une voiture ayant la plaque : <<{actualCar.LicensePlate}>> existe déjà dans le parking"); break;
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

                if (int.TryParse(vehiculeInfo, out int value)){
                    if (this.ParkingPlace[value] != null)
                    {
                        for (int i = 0; i < TicketList.Count(); i++)
                        {
                            if (TicketList[i].PlaceNumber == value && TicketList[i].Price == 0)
                            {
                                vehiculeFound = true;
                                Console.WriteLine(TicketList[i].ToString());
                                Console.WriteLine($"Plaque d'immatriculation : <<{TicketList[i].LinkedCar.LicensePlate}>>");
                            }
                        }
                    }
                }
            }


            if (!vehiculeFound)
            {
                if (place)
                {
                    this.ShowMessage(5, null);
                }
                else
                {
                    this.ShowMessage(4, null);
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
                int placeNumber = 0;
                if (int.TryParse(vehiculeInfo, out placeNumber)) {
                    if (int.IsPositive(placeNumber) && this.ParkingPlace[placeNumber] != null)
                    {
                        for (int i = 0; i < TicketList.Count(); i++)
                        {
                            if (TicketList[i].PlaceNumber == placeNumber)
                            {
                                vehiculeFound = true;
                                ExitChoice(TicketList[i].LinkedCar, TicketList[i], i);
                            }
                        }
                    }
                }
            }
            

            if (!vehiculeFound)
            {
                if (place)
                {
                    int.TryParse(vehiculeInfo, out int value);
                    if (!int.IsPositive(value))
                    {
                        this.ShowMessage(6, null);
                    }
                    else
                    {
                        this.ShowMessage(5, null);
                    }
                }
                else
                {
                    this.ShowMessage(4, null);
                }
            }
        }
        public void CloseApp()
        {
            Console.Write("Êtes vous sûr de vouloir fermet l'application ? (o,n) : ");
            string userEntry = Console.ReadLine();

            if (userEntry != null)
            {
                if (userEntry == "o")
                {
                    Environment.Exit(0);
                }
            }

            Console.ReadKey();


        }
        private void ExitChoice( Voiture thisCar, Ticket t, int i)
        {
            Console.Clear();
            t.CalculatePrice();
            t.Lefting = true;
            Console.WriteLine(thisCar.LicensePlate);
            Console.WriteLine(t.ToString());

            Console.Write("Voulez-vous vraiment faire sortir cette voiture ? (o/n) : ");
            if (Console.ReadLine() == "o")
            {
                thisCar.IsActuallyInThePark = false;
                ParkingPlace[i] = null;
                t.exitHour = DateTime.Now;
                Console.WriteLine($"La place de parque N°{i} à été libérée.");
                t.CarStopWatch.Stop();
                money += t.Price;
            }
            else
            {
                t.Price = 0;
                Console.WriteLine($"la place de parque N°{i} est toujours occupée.");
            }
            t.Lefting = false;
        }
        public void EnterVehicule(String licensePLate)
        {
            bool isCheckGood = false;
            licensePLate = licensePLate.ToLower();
            int licenseCheck = CheckLicensePlate(licensePLate);
            if (licenseCheck == 1)
            {
                Console.Clear();
                Console.Write("Quel place voulez vous que la voiture occupe ?(0-19) : ");
                bool isDigit = int.TryParse(Console.ReadLine(), out int placeChoosed);
                if (isDigit)
                {
                    if (placeChoosed >= 0 && placeChoosed <= 19)
                    {
                        if (ParkingPlace[placeChoosed] == null)
                        {
                            CarList.Add(new Voiture(licensePLate));
                            ParkingPlace[placeChoosed] = new Place(CarList[CarList.Count - 1]);
                            TicketList.Add(new Ticket(CarList[CarList.Count - 1], placeChoosed));
                            Console.WriteLine(TicketList[TicketList.Count - 1]);
                            isCheckGood = true;
                            ShowMessage(0, CarList[CarList.Count - 1]);
                        }
                    }
                }
                if (!isCheckGood){
                    isCheckGood = true;
                    ShowMessage(1, null);
                }
                
            }
            if (!isCheckGood){
                    isCheckGood = true;
                if (licenseCheck == 0){
                    ShowMessage(2, null);
                }
                else
                {
                    foreach (Voiture v in CarList)
                    {
                        if (v.LicensePlate == licensePLate && v.IsActuallyInThePark == true)
                        ShowMessage(3, v);
                    }
                }
            }
        }
        public int CheckLicensePlate(string licensePLate)
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

            for (int i = 0; i < ParkingPlace.Length; i++)
            {
                if (ParkingPlace[i] != null)
                {
                    TimeSpan difference = DateTime.Now - DateTime.Now;
                    foreach (Ticket t in TicketList)
                    {
                        if (t.LinkedCar == ParkingPlace[i].ActualCar && t.Price == 0)
                        {
                            difference = t.GetElapsedTime();
                        }
                    }
                    string secondes = string.Format("{0:00}", difference.Seconds);
                    string minutes = string.Format("{0:00}", difference.Minutes);
                    Console.WriteLine($"Place {i + 1} : {ParkingPlace[i].ActualCar.LicensePlate} (depuis {difference.Hours}h{minutes}:{secondes})");
                }

            }
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
            Console.WriteLine($@"=== ÉTAT DU PARKING ===
Places totales : {this.ParkingPlace.Count().ToString()}
Places occupées : {CountOccupedPlace()}
Places libres : {ParkingPlace.Length - CountOccupedPlace()}
Taux d'occupation : {CountOccupedPlace() * 5}%
Totale d'argent engendré : {money}.-
");
            ShowCar();
            

        }
        public void ShowTransactionHistory()
        {
            Console.WriteLine("Historique des transactions : \n");
            foreach (Voiture v in CarList)
            {
                Console.WriteLine($@"
Voiture : {v.LicensePlate}");
                foreach (Ticket t in TicketList)
                {
                    if (t.LinkedCar == v)
                    {
                        Console.WriteLine($"Heure d'entrée : {t.entryHour}");
                        TimeSpan elapsedTime = t.GetElapsedTime();
                        string secondes = string.Format("{0:00}", elapsedTime.Seconds);
                        string minutes = string.Format("{0:00}", elapsedTime.Minutes);
                        if (!v.IsActuallyInThePark)
                        {
                            Console.WriteLine($"Heure de sortie : {t.exitHour}");
                            Console.WriteLine($"Temps passé dans le parking : {t.GetElapsedTime().Hours}h{minutes}:{secondes}");
                            Console.WriteLine($"Prix du ticket : {t.Price}.-");
                        }
                        if (v.IsActuallyInThePark)
                        Console.WriteLine($"Temps passé dans le parking : {t.GetElapsedTime().Hours}h{minutes}:{secondes}");
                    }
                }
            }
            
        }
    }
}
