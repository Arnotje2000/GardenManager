using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Core.Models
{
    public class FertilizationPlan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid GardenPlotId { get; set; }
        public Guid PlantId { get; set; }
        public string FertilizerType { get; set; }
        public string NPKRatio { get; set; } // JSON: {nitrogen, phosphorus, potassium}
        public DateTime ApplicationDate { get; set; }
        public DateTime NextApplicationDate { get; set; }
        public int FrequencyDays { get; set; } // how often to apply
        public string Notes { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public GardenPlot GardenPlot { get; set; }
        public Plant Plant { get; set; }
    }
}
