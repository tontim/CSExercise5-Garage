using CSExercise5_Garage.Interfaces;

namespace CSExercise5_Garage
{
    public class Vehicles : IVehicle
    {
        public required string Type { get; set; }
        public required string Model { get; set; }
        public required string Year { get; set; }
        public required string Color { get; set; }
        public required string Plate { get; set; }
        public required int NumberOfWheels { get; set; } 
        //TODO: Probably should remove required since boats dont have wheels
    }

    //Vehicles with unique properties
    public class Airplane : Vehicles
    {
        public int NumberOfEngines { get; set; }
    }

    public class Motorcycle : Vehicles
    {
        public int CylinderVolume { get; set; }
    }

    public class Car : Vehicles
    {
        public string? FuelType { get; set; } 
    }

    public class Bus : Vehicles
    {
        public int NumberOfSeats { get; set; }
    }

    public class Boat : Vehicles
    {
        public int Length { get; set; }
    }
}
