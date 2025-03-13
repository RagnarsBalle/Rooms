namespace Room.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RoomModel
    {
        [Key]
        public int RoomID { get; set; }

        [Required]
        public string RoomType { get; set; } = null!; // Undviker nullable-varning

        public bool IsVacant { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Exempel på validering för priset
        public decimal Price { get; set; }

        public bool NeedCleaning { get; set; }
    }
}