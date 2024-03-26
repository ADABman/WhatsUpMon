using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WhatsUpMon.Api.Models
{
    [Table("People")] // Specifies the table name in the database
    public class BsExampleClass
    {
        [Key] // Marks the property as a primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configures the property to be auto-generated by the database
        public Guid PersonId { get; set; }

        [Required] // Specifies that the field is required
        [StringLength(100)] // Sets a maximum length for the string
        public string FirstName { get; set; } = default!; // Default! is used to suppress nullable warnings

        [Required] // Specifies that the field is required
        [StringLength(100)] // Sets a maximum length for the string
        public string LastName { get; set; } = default!; // Default! is used to suppress nullable warnings

        [Column(TypeName = "varchar(10)")]
        public string? Gender { get; set; } // Nullable string, '?' indicates that the property can hold null

        [Range(0, 150)]
        public int Age { get; set; } // Integer properties are non-nullable by default

        [EmailAddress]
        public string? Email { get; set; } // Email can be null

        [Phone]
        public string? PhoneNumber { get; set; } // Phone number can be null

        public DateTime BirthDate { get; set; } // Non-nullable DateTime, assuming a birthdate is always known

        [NotMapped] // This property is not mapped to any column in the database
        public string FullName => $"{FirstName} {LastName}"; // Calculated property, not stored in the database

        [ConcurrencyCheck] // Used to prevent data overwrites in concurrent scenarios
        public string? SSN { get; set; } // Social Security Number can be null

        public Address? HomeAddress { get; set; } // Navigation property, can be null if no address is associated

        [ForeignKey("HomeAddress")] // Specifies the foreign key property
        public int HomeAddressId { get; set; } // Foreign key for HomeAddress

        [Timestamp] // Used for concurrency tracking
        public byte[]? RowVersion { get; set; } // Used to track the row version for concurrency

        [EnumDataType(typeof(OccupationType))]
        public OccupationType Occupation { get; set; } // Enum type, non-nullable by default

        // A collection navigation property. EF Core interprets a collection as a one-to-many relationship.
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    }

    public class Address
    {
        [Key] // Primary key
        public int AddressId { get; set; }

        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }

    public class Skill
    {
        [Key] // Primary key
        public int SkillId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        [Range(1, 10)]
        public int Proficiency { get; set; } // A proficiency level from 1 to 10

        public Guid PersonId { get; set; }
        public BsExampleClass? Person { get; set; } // Navigation back to the person
    }

    public enum OccupationType
    {
        Unemployed,
        Student,
        Employed,
        SelfEmployed
    }
}