using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Core.Models
{
    public class SensorReading
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SensorId { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; } // %, °C
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Sensor Sensor { get; set; }
    }
}
