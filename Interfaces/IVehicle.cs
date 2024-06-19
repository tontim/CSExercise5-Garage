using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSExercise5_Garage;

namespace CSExercise5_Garage.Interfaces
{
    public interface IVehicle
    {
        string Type { get; set; }
        string Model {  get; set; }
        string Year { get; set; }
        string Color { get; set; }
        string Plate { get; set; }
        int NumberOfWheels { get; set; }
    }
}
