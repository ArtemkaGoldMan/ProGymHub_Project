using BaseLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public string? FileName { get; set; }
        public string? JobName { get; set; } //worker or visitor
        public string? Addres { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Photo { get; set; }
        public string? Other { get; set; }

        public Lesson? Lessons { get; set; }
        public int LessonsId { get; set; }

        public Attendance? Attendance { get; set; }
        public int AttendanceId { get; set; }
    }
}
