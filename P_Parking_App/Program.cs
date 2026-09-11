using P_Parking_App;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

string userEntry;
Parking parking1 = new Parking(20);



while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.CursorVisible = false;
    parking1.ShowStats();
    Console.CursorVisible = true;
    userEntry = Console.ReadLine();
    switch (userEntry)
    {
        case "1": Console.Clear(); if (parking1.EnterVehicule(Console.ReadLine()))
            {
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"La voiture avec la plaque : <<{parking1.car[parking1.car.Count() - 1].licensePlate}>> à bien été ajoutée !");
            }
        else
            {
                Console.ForegroundColor = ConsoleColor.Red;  Console.WriteLine("La voiture n'as pas pu être ajoutée pour cause de manque de place");
            } Console.ReadLine();
                break; 
        case "2": break; //Appeler ExitVehicule
        case "3": break; //Appeler ShowStats
        case "4": break; //Appeler SearchVehicule
        case "5": break; //Appeler DayStatistics
        case "6": break; //Appeler TransactionsHistory
        default : break; //Appeler CloseApp
    }
}