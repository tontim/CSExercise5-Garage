using System;
using System.Collections;
using System.Collections.Generic;
using CSExercise5_Garage.Interfaces;

namespace CSExercise5_Garage
{
    public class Garage<T> : IGarage<T> where T : IVehicle
    {
        private T[] vehicles;
        private int capacity;
        private int count;

        public Garage(int capacity)
        {
            this.capacity = capacity;
            vehicles = new T[capacity];
            count = 0;
        }

        //Check for capacity and add if true
        public bool ParkVehicle(T vehicle)
        {
            if (count < capacity)
            {
                vehicles[count++] = vehicle;
                return true;
            }
            return false;
        }

        //Look for plate numbers and remove that vehicle
        public bool RemoveVehicle(string plate)
        {
            for (int i = 0; i < count; i++)
            {
                if (vehicles[i].Plate.Equals(plate, StringComparison.OrdinalIgnoreCase))
                {
                    vehicles[i] = vehicles[count - 1];
                    vehicles[count - 1] = default; 
                    count--;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //Public capacity so we can test it
        public int Capacity => capacity;
    }
}
