namespace DemoProject.DTOs
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
