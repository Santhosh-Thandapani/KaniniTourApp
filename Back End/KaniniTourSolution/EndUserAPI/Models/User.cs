﻿using System.ComponentModel.DataAnnotations;

namespace EndUserAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? PhoneNo { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
        public byte[]? PasswordHash { get; set; }   
        public byte[]? PasswordKey { get; set; }
    }
}

