using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndUserAPI.Models
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        public int PassId { get; set; }
        [ForeignKey("PassId")]
        public User? User { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
