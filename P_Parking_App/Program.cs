using P_Parking_App;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

string userEntry;
Parking parking1 = new Parking(20);

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.CursorVisible = false;
    Console.WriteLine("Bienvenue dans le parking !");
    parking1.ShowMenu();
    Console.CursorVisible = true;
    userEntry = Console.ReadLine();
    switch (userEntry)
    {
        case "1": Console.Clear(); parking1.EnterVehicule(Console.ReadLine()); Console.ReadLine();
                break; 
        case "2": Console.Clear(); parking1.ExitVehicule(Console.ReadLine()); Console.ReadLine(); break;
        case "3": Console.Clear(); parking1.ShowTable(); Console.ReadLine(); break; 
        case "4": break; //Appeler SearchVehicule
        case "5": break; //Appeler DayStatistics
        case "6": break; //Appeler TransactionsHistory
        default : break; //Appeler CloseApp
    }
}