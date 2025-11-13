using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenManager.DTOs.Garden
{
    public class CreateGardenRequest
    {
        [Required(ErrorMessage = "Garden name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(256, ErrorMessage = "Name cannot exceed 256 characters")]
        public string Name { get; set; }
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Width is required")]
        [Range(0.1, 1000, ErrorMessage = "Width must be between 0.1 and 1000 meters")]
        public double Width { get; set; }
        [Required(ErrorMessage = "Height is required")]
        [Range(0.1, 1000, ErrorMessage = "Height must be between 0.1 and 1000 meters")]
        public double Height { get; set; }
        [Range(-90, 90, ErrorMessage = "Invalid latitude")]
        public double? Latitude { get; set; }
        [Range(-180, 180, ErrorMessage = "Invalid longitude")]
        public double? Longitude { get; set; }
        public string SoilType { get; set; }
    }
}
