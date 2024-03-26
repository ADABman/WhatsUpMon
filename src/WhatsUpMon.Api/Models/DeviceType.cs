using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsUpMon.Api.Models
{
    public class DeviceType
    {
        [Key] // Denotes the primary key of this entity
        public int DeviceTypeId { get; set; }

        [Required] // Marks the Name as a required field
        [MaxLength(50)] // Specifies the maximum length of the Name
        public string Name { get; set; } = string.Empty;

        // Navigation property for the one-to-many relationship with Device
        public List<Device> Devices { get; set; } = new List<Device>();
    }
}