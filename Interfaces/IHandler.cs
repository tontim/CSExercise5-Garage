using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSExercise5_Garage.Interfaces
{
    public interface IHandler
    {
        void CreateGarage(int capacity);
        void AddVehicle(IVehicle vehicle);
        void RemoveVehicle(string plate);
        void ListVehicles();
        void SearchVehicle(string plate);
        void SearchByProperties(string color = null, int? numberOfWheels = null);
        void SaveGarage(string filePath);
        void LoadGarage(string filePath);
    }
}
