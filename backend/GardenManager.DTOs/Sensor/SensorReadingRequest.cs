using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.DTOs.Sensor
{
    public class SensorReadingRequest
    {
        [Required(ErrorMessage = "Value is required")]
        [Range(-50, 150, ErrorMessage = "Value must be between -50 and 150")]
        public double Value { get; set; }
    }
}
