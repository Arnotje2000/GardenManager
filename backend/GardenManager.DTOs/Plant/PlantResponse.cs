using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.DTOs.Plant
{
    public class PlantResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Type { get; set; }
        public int DaysToMaturity { get; set; }
        public double OptimalTempMin { get; set; }
        public double OptimalTempMax { get; set; }
        public double OptimalMoistureMin { get; set; }
        public double OptimalMoistureMax { get; set; }
        public string Sunlight { get; set; }
        public string WaterNeeds { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
