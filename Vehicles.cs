using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSExercise5_Garage
{
    public class Vehicles
    {
        public required string type { get; set; }
        public required string model { get; set; }
        public required string year { get; set; }
        public required string color { get; set; }
    }

}
