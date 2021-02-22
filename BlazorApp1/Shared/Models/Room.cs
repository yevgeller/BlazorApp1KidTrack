using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BlazorApp1.Shared.Models
{
    [DebuggerDisplay("{ForDisplay}")]
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public string Description { get; set; }
        public string ForDisplay()
        {
            return $"{Id}-{Name}-{MaxCapacity}-{Description}";
        }
    }
}
