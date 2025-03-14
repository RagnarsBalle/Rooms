﻿namespace Room.Models;

public class RoomDto
{
    public int RoomID { get; set; }
    public string RoomType { get; set; } = null!;
    public bool IsVacant { get; set; }
    public decimal Price { get; set; }
    public bool NeedCleaning { get; set; }
}