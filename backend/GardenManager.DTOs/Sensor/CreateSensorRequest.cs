using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.DTOs.Sensor
{
    public class CreateSensorRequest
    {
        [Required(ErrorMessage = "Sensor type is required")]
        [RegularExpression("^(moisture|temperature)$", ErrorMessage = "Type must be 'moisture' or 'temperature'")]
        public string Type { get; set; }
        [Required(ErrorMessage = "External ID is required")]
        [MinLength(5, ErrorMessage = "External ID must be at least 5 characters")]
        [MaxLength(256, ErrorMessage = "External ID cannot exceed 256 characters")]
        public string ExternalId { get; set; }
        [MaxLength(256, ErrorMessage = "Name cannot exceed 256 characters")]
        public string Name { get; set; }
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }
        public string GardenPlotId { get; set; }
    }
}
