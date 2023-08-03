using System.ComponentModel.DataAnnotations.Schema;

namespace EndUserAPI.Models
{
    public class Passenger
    {
        public int PassId { get; set; }
        [ForeignKey("PassengerId")]
        public User? User { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
