namespace Room.Models;

public class RoomDto
{
    public string RoomNumber { get; set; } = string.Empty;
    public string RoomType { get; set; } = string.Empty;
    public bool IsVacant { get; set; }
    public decimal Price { get; set; } = 0.00m;
    public bool NeedCleaning { get; set; } = false;
}
