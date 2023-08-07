using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EndUserAPI.Models
{
    public class UserTwoFactor
    {

        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public string? String { get; set; }
    }
}
