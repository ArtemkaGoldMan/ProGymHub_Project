using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class UserLesson
    {
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int LessonId { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
