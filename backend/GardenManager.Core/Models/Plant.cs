using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Core.Models
{
    public class Plant
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string Type { get; set; } // vegetable, herb, flower, fruit
        public string SowingMonths { get; set; } // JSON array: [3,4,5]
        public string HarvestMonths { get; set; } // JSON array: [6,7,8,9]
        public int DaysToMaturity { get; set; }
        public double OptimalTempMin { get; set; } // in Celsius
        public double OptimalTempMax { get; set; } // in Celsius
        public double OptimalMoistureMin { get; set; } // in percentage
        public double OptimalMoistureMax { get; set; } // in percentage
        public string FertilizerRequirements { get; set; } 
        public int Spacing { get; set; } // in cm
        public string Sunlight { get; set; } // full-sun, partial-shade, shade
        public string WaterNeeds { get; set; } // low, medium, high
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<GardenPlot> GardenPlots { get; set; } = new
        List<GardenPlot>();
        public ICollection<FertilizationPlan> FertilizationPlans { get; set; }
        = new List<FertilizationPlan>();
        public ICollection<PlantCompanion> CompanionPlantsA { get; set; } = new
        List<PlantCompanion>();
        public ICollection<PlantCompanion> CompanionPlantsB { get; set; } = new
        List<PlantCompanion>();
    }
}
