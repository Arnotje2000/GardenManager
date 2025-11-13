using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Core.Models
{    public class Garden
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Width { get; set; } // in meters
        public double Height { get; set; } // in meters
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? SoilType { get; set; } 
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public User? User { get; set; }
        public ICollection<GardenPlot> Plots { get; set; } = new
        List<GardenPlot>();
        public ICollection<Sensor> Sensors { get; set; } = new List<Sensor>();
    }
}
