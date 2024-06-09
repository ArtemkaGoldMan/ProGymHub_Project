namespace BaseLibrary.DTOs
{
    public class UserWithLessonsDTO
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public ICollection<LessonDTO>? Lessons { get; set; }
    }
}