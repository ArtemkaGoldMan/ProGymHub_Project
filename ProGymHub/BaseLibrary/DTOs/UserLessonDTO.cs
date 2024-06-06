namespace BaseLibrary.DTOs
{
    public class UserLessonDTO
    {
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public LessonDTO? Lesson { get; set; }
    }
}
