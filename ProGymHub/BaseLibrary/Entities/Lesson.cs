using System;
using System.Collections.Generic;

namespace BaseLibrary.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DayOfWeek Day { get; set; }  // Day of the week
        public TimeSpan StartTime { get; set; }  // Start time of the lesson
        public TimeSpan EndTime { get; set; }    // End time of the lesson

        // Navigation property
        public ICollection<UserLesson>? UserLessons { get; set; }
    }
}
