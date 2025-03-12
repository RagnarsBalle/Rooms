namespace Rooms.Models
{

    using System;
    using System.ComponentModel.DataAnnotations;
    public class RoomsModel
    {
        public int RoomID { get; set; }
        public string RoomType { get; set; }
        public bool IsVacant { get; set; }
        public decimal Price { get; set; }
        public bool NeedCleaning { get; set; }
    }
}
