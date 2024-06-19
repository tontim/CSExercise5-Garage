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


IHandler garageHandler = new GarageHandler(ivehicles);

// Create default garage 
int defaultCapacity = ivehicles.Count; 
garageHandler.CreateGarage(defaultCapacity);

Console.WriteLine("Welcome to the garage!\n" +
    "What do you want to do?\n" +
    "[1] - What vehicles are in the garage?\n" +
    "[2] - Add & Remove vehicles\n" +
    "[3] - Search for vehicle\n" +
    "[4] - Create or Load Garage\n" +
    "[5] - Save Garage\n" +
    "[6] - Search by Properties\n" +
    "[Q] - Quit");
string selection = Console.ReadLine()!;

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
                
                Console.WriteLine("Enter number of wheels:");
                int numberOfWheels = int.Parse(Console.ReadLine()!);

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
            Console.WriteLine("Enter garage capacity:");
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
            string searchColor = Console.ReadLine();
            Console.WriteLine("Enter number of wheels to search (leave blank for any):");
            string wheelsInput = Console.ReadLine();
            int? searchWheels = string.IsNullOrEmpty(wheelsInput) ? (int?)null : int.Parse(wheelsInput);
            garageHandler.SearchByProperties(searchColor, searchWheels);
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
        "[4] - Create or Load Garage\n" +
        "[5] - Save Garage\n" +
        "[6] - Search by Properties\n" +
        "[Q] - Quit");
    selection = Console.ReadLine()!;
}
