using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsUpMon.Api.Models
{
    public class Map
    {
        [Key] // Denotes the primary key of this entity
        public int MapId { get; set; }

        [Required] // Marks the Name as a required field
        [MaxLength(100)] // Specifies the maximum length of the Name to ensure data integrity
        public string Name { get; set; } = string.Empty;

        [Required] // Indicates that SizeX is a required field
        [Range(100, 9999)]
        public int SizeX { get; set; } = 5000;

        [Required] // Indicates that SizeY is a required field
        [Range(100, 9999)]
        public int SizeY { get; set; } = 5000;

        // Navigation property for the many-to-many relationship with Device
        public List<Device> Devices { get; set; } = new List<Device>();

    }

}