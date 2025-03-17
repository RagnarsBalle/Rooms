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
        public string RoomNumber { get; set; } = null!; // Undviker null-värden

        [Required]
        public string RoomType { get; set; } = null!; // Undviker null-värden

        public bool IsVacant { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Validering för prisformat
        public decimal Price { get; set; }

        public bool NeedCleaning { get; set; }
    }
}
