using System.ComponentModel.DataAnnotations;

namespace Hospital.Entities.Resources
{
    public class HospitalSaveResource
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public int FreeUnits { get; set; }
    }
}
