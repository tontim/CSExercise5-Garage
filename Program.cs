using CSExercise5_Garage;
using CSExercise5_Garage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

// Read json file where all vehicles are stored
string vehiclesFile = File.ReadAllText("vehicles.json");
//Deserialize json into list 
List<Vehicles> vehicles = JsonConvert.DeserializeObject<List<Vehicles>>(vehiclesFile) ?? new List<Vehicles>();

//Convert deserialized list to IVehicle since we cannot convert directly
List<IVehicle> ivehicles = new List<IVehicle>(vehicles);

Console.ForegroundColor = ConsoleColor.Red;
Console.Write("SYSTEM: ");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("vehicles.json ");
Console.ResetColor();
Console.Write("loaded!\n\n");

//Instantiate Interface for garagehandler
IHandler garageHandler = new GarageHandler(ivehicles);

// Create default garage with some empty spaces available
int defaultCapacity = ivehicles.Count +10; 
garageHandler.CreateGarage(defaultCapacity);

Console.WriteLine("\n\nWelcome to the garage!\n" +
    "What do you want to do?\n" +
    "[1] - What vehicles are in the garage?\n" +
    "[2] - Add & Remove vehicles\n" +
    "[3] - Search for vehicle\n" +
    "[4] - Create Garage\n" +
    "[5] - Save Garage\n" +
    "[6] - Search by Properties\n" +
    "[7] - Load Garage\n" +
    "[Q] - Quit");
string selection = Console.ReadLine()!;

//As long as loop is not Q, keep loop going 
while (selection.ToUpper() != "Q")
{
    switch (selection)
    {
        case "1":
            garageHandler.ListVehicles();
            break;

        case "2":
            
            Console.WriteLine("[A]dd or [R]emove?");
            string subSelection = Console.ReadLine()!;

            //Effective way of checking if true with OrdinalIgnoreCase 
            if (subSelection.Equals("A", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Enter vehicle type:");
                string type = Console.ReadLine()!;

                Console.WriteLine("Enter model:");
                string model = Console.ReadLine()!;
                
                Console.WriteLine("Enter year:");
                string year = Console.ReadLine()!;
                
                Console.WriteLine("Enter color:");
                string color = Console.ReadLine()!;
                
                Console.WriteLine("Enter plate:");
                string plate = Console.ReadLine()!;
                //TODO: Make if case for boats (they don't have wheels)
                Console.WriteLine("Enter number of wheels:");
                int numberOfWheels = int.Parse(Console.ReadLine()!);
                //New vehicle via interface
                IVehicle vehicle = new Vehicles
                {
                    Type = type,
                    Model = model,
                    Year = year,
                    Color = color,
                    Plate = plate,
                    NumberOfWheels = numberOfWheels
                };
                garageHandler.AddVehicle(vehicle);
            }
            else if (subSelection.Equals("R", StringComparison.OrdinalIgnoreCase))
            {
                //Use of plates which is an unique identifier for vehicles
                Console.WriteLine("Enter plate of the vehicle to remove:");
                string plate = Console.ReadLine()!;
                garageHandler.RemoveVehicle(plate);
            }
            break;

        case "3":
            Console.WriteLine("Enter plate of the vehicle to search:");
            string searchPlate = Console.ReadLine()!;
            garageHandler.SearchVehicle(searchPlate);
            break;

        case "4":
            Console.WriteLine("Give garage capacity:");
            int capacity = int.Parse(Console.ReadLine()!);
            garageHandler.CreateGarage(capacity);
            break;

        case "5":
            Console.WriteLine("Enter file path to save garage:");
            string saveFilePath = Console.ReadLine()!;
            garageHandler.SaveGarage(saveFilePath);
            break;

        case "6":
            Console.WriteLine("Enter color:");
            string? searchColor = Console.ReadLine();

            //If search is null then use "", otherwise searchColor
            searchColor ??= string.IsNullOrEmpty(searchColor) ? "" : searchColor;
            
            Console.WriteLine("Enter number of wheels to search (leave blank for any):");
            string? wheelsInput = Console.ReadLine();

            //keep going if search is null otherwise use input
            //TODO: Fix input check so it doesn't crash with wrong input
            int? searchWheels = string.IsNullOrEmpty(wheelsInput) ? (int?)null : int.Parse(wheelsInput);

            garageHandler.SearchByProperties(searchColor, searchWheels);
            
            break;
        case "7":

            Console.WriteLine("Enter file name to load:");
            string? loadInput = Console.ReadLine();

            garageHandler.LoadGarage(loadInput!);

            break;
        
        default:
            Console.WriteLine("Please input a valid entry");
            break;
    }

    Console.WriteLine("Welcome to the garage!\n" +
        "What do you want to do?\n" +
        "[1] - What vehicles are in the garage?\n" +
        "[2] - Add & Remove vehicles\n" +
        "[3] - Search for vehicle\n" +
        "[4] - Create Garage\n" +
        "[5] - Save Garage\n" +
        "[6] - Search by Properties\n" +
        "[7] - Load Garage\n" +
        "[Q] - Quit");
    selection = Console.ReadLine()!;
}
