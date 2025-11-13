using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Core.Models
{
    public class SensorAlert
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SensorId { get; set; }
        public string Type { get; set; } // moisture_low, moisture_high,temperature_low, temperature_high
        public double Value { get; set; }
        public double Threshold { get; set; }
        public string Message { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ResolvedAt { get; set; }
        public Sensor Sensor { get; set; }
    }
}
