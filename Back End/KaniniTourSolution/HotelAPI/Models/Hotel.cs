﻿using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public int HouseNo { get; set; }
        public string? Street { get; set; }
        public string? Landmark { get; set; }   
        public string? City { get; set; }
    }
}
