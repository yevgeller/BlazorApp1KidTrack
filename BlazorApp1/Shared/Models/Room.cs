using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    [DebuggerDisplay("${ForDisplay}")]
    public class Room
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Room name too long.")]
        public string Name { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "Max Capacity must be a number between 1 and 20")]
        public int MaxCapacity { get; set; }
        
        public List<Person> Teachers { get; set; }

        public string Description { get; set; }
        public string ForDisplay()
        {
            return $"{Id}-{Name}-{MaxCapacity}-{Description}";
        }
    }
}
