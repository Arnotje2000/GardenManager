using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Core.Models
{
    public class GardenPlot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid GardenId { get; set; }
        public Guid PlantId { get; set; }
        public double X { get; set; } // position in meters
        public double Y { get; set; } // position in meters
        public double Width { get; set; } // in meters
        public double Height { get; set; } // in meters
        public DateTime PlantedDate { get; set; }
        public DateTime? ExpectedHarvestDate { get; set; }
        public DateTime? ActualHarvestDate { get; set; }
        public int Quantity { get; set; } = 1; // number of plants
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Garden? Garden { get; set; }
        public Plant Plant { get; set; }
        public ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
        public ICollection<FertilizationPlan> FertilizationPlans { get; set; }
        = new List<FertilizationPlan>();
    }
}
