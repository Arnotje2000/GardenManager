using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Core.Models
{
    public class Sensor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid GardenId { get; set; }
        public Guid? GardenPlotId { get; set; }
        public string Type { get; set; } // moisture, temperature
        public string ExternalId { get; set; } // Device identifier (MAC address, etc.)
        public string Status { get; set; } = "active"; // active, inactive, error
        public DateTime? LastReadingAt { get; set; }
        public double? LastReadingValue { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? BatteryLevel { get; set; } // for wireless sensors
        public DateTime? LastSyncAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Garden Garden { get; set; }
        public GardenPlot GardenPlot { get; set; }
        public ICollection<SensorReading> Readings { get; set; } = new
        List<SensorReading>();
        public ICollection<SensorAlert> Alerts { get; set; } = new
        List<SensorAlert>();
    }
}
