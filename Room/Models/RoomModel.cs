namespace Room.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RoomModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment för RoomID
        public int RoomID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")] // Säkerställ att RoomNumber sparas som sträng
        public string RoomNumber { get; set; } = string.Empty; // Undviker null-värden

        [Required]
        [Column(TypeName = "nvarchar(50)")] // Lägg till specifik datatyp för RoomType
        public string RoomType { get; set; } = string.Empty; // Undviker null-värden

        public bool IsVacant { get; set; } = true; // Standardvärde för lediga rum

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Validering för prisformat
        public decimal Price { get; set; } = 0.00m; // Standardvärde

        public bool NeedCleaning { get; set; } = false; // Standardvärde
    }
}
