using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    public class Participant
    {
        public int Id { get; set; }
        
        [Required]
        [Range(1, 100, ErrorMessage = "Name must be between 1 and 100 characters")]
        public string Name { get; set; }

        public string Information { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int RoomId { get; set; }
    }
}
