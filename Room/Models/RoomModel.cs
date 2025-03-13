namespace Room.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RoomModel
    {
        [Key]
        public int RoomID { get; set; }

        [Required]
        public string RoomType { get; set; } = null!; // Undviker nullable-varning

        public bool IsVacant { get; set; }

        [Required]
        [Range(0, 10000)] // Exempel på validering för priset
        public decimal Price { get; set; }

        public bool NeedCleaning { get; set; }
    }
}