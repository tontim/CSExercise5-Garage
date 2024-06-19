using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSExercise5_Garage.Interfaces
{
    public interface IGarage<T> : IEnumerable<T> where T : IVehicle
    {
        bool ParkVehicle(T vehicle);
        bool RemoveVehicle(string plate);
        int Capacity { get; }
    }
}
