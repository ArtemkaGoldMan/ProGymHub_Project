using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Passsword { get; set; }
        public string? PhotoUrl { get; set; }

        // Navigation property
        public ICollection<UserLesson>? UserLessons { get; set; }

    }
}
