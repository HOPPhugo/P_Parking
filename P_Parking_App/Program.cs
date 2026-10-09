using P_Parking_App;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

string userEntry;

//Création du parking avec 20 places.
Parking parking1 = new Parking(20);

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.CursorVisible = false;
    Console.WriteLine("Bienvenue dans le parking !");

    //Affiche le menu.
    parking1.ShowMenu();
    Console.CursorVisible = true;
    userEntry = Console.ReadLine();
    Console.Clear();

    //Selon l'entrée utilisateur.
    switch (userEntry)
    {
        case "1": parking1.EnterVehicule(); Console.ReadLine();  break; //Apelle la methode pour entrer un vehicule dans le parking.
        case "2": parking1.ExitVehicule(Console.ReadLine()); Console.ReadLine(); break; //Apelle la methode pour faire sortir un vehicule du parking.
        case "3": parking1.ShowTable(); Console.ReadLine(); break; //Apelle la methode pour afficher l'état du parking et les voitures qui y sont parkée.
        case "4": parking1.SearchVehicule(Console.ReadLine()); Console.ReadLine(); break; //Apelle la methode pour rechercher un vehicule dans le parking et afficher ses informations.
        case "5": parking1.ShowStats(); Console.ReadLine(); break; //Apelle la methode pour afficher les informations du parking.
        case "6": parking1.ShowTransactionHistory(); Console.ReadLine(); break; //Apelle la methode pour afficher l'historique des transactions.
        default : parking1.CloseApp(); break; //Apelle la methode pour fermer l'application sur demande de l'utilisateur.
    }
}