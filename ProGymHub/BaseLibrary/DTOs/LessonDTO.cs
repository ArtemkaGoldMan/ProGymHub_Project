namespace BaseLibrary.DTOs
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
