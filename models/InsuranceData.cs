using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VehicleInsuranceAPI.Models
{
    public class InsuranceData
    {
        [Required]
        public string Age { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string DrivingExperience { get; set; } = string.Empty;

        [Required]
        public string Education { get; set; } = string.Empty;

        [Required]
        public string Income { get; set; } = string.Empty;

        [Required]
        public string VehicleYear { get; set; } = string.Empty;

        [Required]
        public string VehicleType { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public double AnnualMileage { get; set; }

        [JsonIgnore]
        public decimal CreditScore { get; set; }
    }
}
