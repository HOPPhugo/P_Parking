using P_Parking_App;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

string userEntry;
Parking parking1 = new Parking(20);



while (true)
{
    Console.CursorVisible = false;
    parking1.ShowStats();
    Console.CursorVisible = true;
    userEntry = Console.ReadLine();
    switch (userEntry)
    {
        case "1": break; //Appeler EnterVehicule
        case "2": break; //Appeler ExitVehicule
        case "3": break; //Appeler ShowStats
        case "4": break; //Appeler SearchVehicule
        case "5": break; //Appeler DayStatistics
        case "6": break; //Appeler TransactionsHistory
        default : break; //Appeler CloseApp
    }
}