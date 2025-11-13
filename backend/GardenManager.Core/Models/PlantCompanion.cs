using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.Core.Models
{
    public class PlantCompanion
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PlantAId { get; set; }
        public Guid PlantBId { get; set; }
        public string Compatibility { get; set; } // good, bad, neutral
        public string Notes { get; set; }
        public Plant PlantA { get; set; }
        public Plant PlantB { get; set; }
    }
}
