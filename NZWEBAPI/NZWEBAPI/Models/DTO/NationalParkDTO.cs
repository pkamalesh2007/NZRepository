using System.ComponentModel.DataAnnotations;

namespace NZWEBAPI.Models.DTO
{
    public class NationalParkDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string State { get; set; }

        public DateTime Created { get; set; }

        public DateTime Establish { get; set; }
    }
}
