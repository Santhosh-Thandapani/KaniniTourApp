using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndUserAPI.Models
{
    public class TourAgent
    {
        [Key]
        public int Id { get; set; }
        public int TourAgentId { get; set; }
        [ForeignKey("TourAgentId")]
        public User? User { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string? Gender { get;set; }
        public string? Email { get; set; }
        public string? Picture { get; set; }
        public string? Address { get; set; }

    }
}
