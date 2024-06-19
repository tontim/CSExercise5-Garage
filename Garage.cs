using System;
using System.Collections;
using System.Collections.Generic;

namespace CSExercise5_Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicles
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

        public bool ParkVehicle(T vehicle)
        {
            if (count < capacity)
            {
                vehicles[count++] = vehicle;
                return true;
            }
            return false;
        }

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
