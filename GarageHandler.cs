using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using CSExercise5_Garage.Interfaces;

namespace CSExercise5_Garage
{
    internal class GarageHandler : IHandler
    {
        private IGarage<IVehicle>? garage;
        private List<IVehicle> vehicles;

        public GarageHandler(List<IVehicle> vehicles)
        {
            this.vehicles = vehicles ?? new List<IVehicle>();
        }

        public void CreateGarage(int capacity)
        {
            garage = new Garage<IVehicle>(capacity);
            
            foreach (var vehicle in vehicles)
            {
                garage.ParkVehicle(vehicle);
            }
            Console.WriteLine($"Created garage with maximum {capacity} capacity.");
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (garage == null)
            {
                Console.WriteLine("Create a garage first.");
                return;
            }

            if (garage.ParkVehicle(vehicle))
            {
                Console.WriteLine($"{vehicle.Type} parked.");
            }
            else
            {
                Console.WriteLine("Garage is full.");
            }
        }

        public void RemoveVehicle(string plate)
        {
            if (garage == null)
            {
                Console.WriteLine("Create a garage first.");
                return;
            }

            if (garage.RemoveVehicle(plate))
            {
                Console.WriteLine("Vehicle removed.");
            }
            else
            {
                Console.WriteLine("Could not find vehicle.");
            }
        }

        public void ListVehicles()
        {
            if (garage == null)
            {
                Console.WriteLine("Create a garage first.");
                return;
            }

            foreach (var vehicle in garage)
            {
                Console.WriteLine($"{vehicle.Type}, {vehicle.Model}, {vehicle.Year}, {vehicle.Color}, {vehicle.Plate}, {vehicle.NumberOfWheels} wheels\n");
            }
        }

        public void SearchVehicle(string plate)
        {
            if (garage == null)
            {
                Console.WriteLine("Create a garage first.");
                return;
            }

            foreach (var vehicle in garage)
            {
                if (vehicle.Plate.Equals(plate, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Found vehicle: {vehicle.Type}, {vehicle.Model}, {vehicle.Year}, {vehicle.Color}, {vehicle.Plate}");
                    return;
                }
            }
            Console.WriteLine("Vehicle not found.");
        }

        public void SearchByProperties(string? color = null, int? numberOfWheels = null)
        {
            if (garage == null)
            {
                Console.WriteLine("Create a garage first.");
                return;
            }

            
            foreach (var vehicle in garage)
            {
                if ((color == null || vehicle.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                    (numberOfWheels == null || vehicle.NumberOfWheels == numberOfWheels))
                {
                    Console.WriteLine($"{vehicle.Type}, {vehicle.Model}, {vehicle.Year}, {vehicle.Color}, {vehicle.Plate}");
                }
            }
        }

        public void SaveGarage(string filePath)
        {
            if (garage == null)
            {
                Console.WriteLine("Create a garage first.");
                return;
            }

            var json = JsonConvert.SerializeObject(garage.ToList());
            File.WriteAllText(filePath, json);
            Console.WriteLine("Garage saved.");
        }

        public void LoadGarage(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                List<Vehicles> loadedVehicles = JsonConvert.DeserializeObject<List<Vehicles>>(json) ?? new List<Vehicles>();
                vehicles = new List<IVehicle>(loadedVehicles); // Convert to List<IVehicle> because we cant do it directly
                CreateGarage(vehicles.Count + 10);
                Console.WriteLine("Garage loaded.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
