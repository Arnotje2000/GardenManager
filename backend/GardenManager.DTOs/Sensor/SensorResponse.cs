using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.DTOs.Sensor
{
    public class SensorResponse
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string ExternalId { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? LastReadingValue { get; set; }
        public DateTime? LastReadingAt { get; set; }
        public double? BatteryLevel { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
