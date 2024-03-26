using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsUpMon.Api.Models
{
    public class Device
    {

        [Key] // Denotes the primary key of this entity
        public int DeviceId { get; set; }

        [Required] // Marks the Name as a required field
        [MaxLength(100)] // Specifies the maximum length of the Name
        public string Name { get; set; } = string.Empty;

        [Required] // Marks the IPAddress as a required field
        [MaxLength(15)] // Specifies the maximum length of the IPAddress
        public string IPAddress { get; set; } = string.Empty;

        [Required] // Marks the Username as a required field
        [MaxLength(50)] // Specifies the maximum length of the Username
        public string Username { get; set; } = string.Empty;

        [Required] // Marks the Password as a required field
        [MaxLength(50)] // Specifies the maximum length of the Password
        public string Password { get; set; } = string.Empty;

        // Foreign key for DeviceType
        [Required] // Indicates that DeviceTypeId is a required field
        public int DeviceTypeId { get; set; }

        // Navigation property for the one-to-many relationship with DeviceType
        [ForeignKey("DeviceTypeId")] // Specifies the foreign key in the relationship
        public DeviceType? DeviceType { get; set; }

        // Navigation property for the many-to-many relationship with Map
        public List<Map> Maps { get; set; } = new List<Map>();

    }
}