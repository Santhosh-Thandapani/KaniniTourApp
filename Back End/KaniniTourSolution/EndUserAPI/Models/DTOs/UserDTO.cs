﻿namespace EndUserAPI.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? Status { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
    }
}
