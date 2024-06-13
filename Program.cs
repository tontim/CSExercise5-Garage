using CSExercise5_Garage;
using Newtonsoft.Json;
using System.IO;

// Read json file where all vehicles are stored
string vehiclesFile = File.ReadAllText("vehicles.json");
//Deserialize json into list 
List<Vehicles> vehicles = JsonConvert.DeserializeObject<List<Vehicles>>(vehiclesFile)!;

Console.ForegroundColor = ConsoleColor.Red;
Console.Write("SYSTEM: ");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("vehicles.json ");
Console.ResetColor();
Console.Write("loaded!\n\n");


Console.WriteLine("Welcome to the garage!\n" +
    "What do you want to do?\n" +
    //submenu that lists what types and how many
    "[1] - What vehicles are in the garage?\n" +
    "[2] - Add & Remove vehicles\n" +
    "[3] - Search for vehicle\n" +
    "[4] - Create or Load Garage\n" +
    "[Q] - Quit");
string selection = Console.ReadLine()!;

switch (selection)
{
    case "1":
        foreach ()
        break;
        
    case "2":

        break;
        
    case "3":

        break;
    case "4":

        break;

    default:
        Console.WriteLine("Please input a valid entry");
        break;
}

