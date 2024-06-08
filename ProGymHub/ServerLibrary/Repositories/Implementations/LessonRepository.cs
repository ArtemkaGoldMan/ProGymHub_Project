using BaseLibrary.DTOs;
using BaseLibrary.Entities;
using BaseLibrary.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponse> CreateLessonAsync(LessonDTO lessonDto)
        {
            var lesson = new Lesson
            {
                Name = lessonDto.Name,
                Description = lessonDto.Description,
                ImageUrl = lessonDto.ImageUrl,
                Day = lessonDto.Day,
                StartTime = lessonDto.StartTime,
                EndTime = lessonDto.EndTime
            };

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            lessonDto.Id = lesson.Id;
            return new GeneralResponse(true, "Lesson created successfully");
        }

        public async Task<GeneralResponse> UpdateLessonAsync(LessonDTO lessonDto)
        {
            var lesson = await _context.Lessons.FindAsync(lessonDto.Id);
            if (lesson == null)
            {
                return new GeneralResponse(false, "Lesson not found");
            }

            lesson.Name = lessonDto.Name;
            lesson.Description = lessonDto.Description;
            lesson.ImageUrl = lessonDto.ImageUrl;
            lesson.Day = lessonDto.Day;
            lesson.StartTime = lessonDto.StartTime;
            lesson.EndTime = lessonDto.EndTime;

            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();

            return new GeneralResponse(true, "Lesson updated successfully");
        }

        public async Task<GeneralResponse> DeleteLessonAsync(int lessonId)
        {
            var lesson = await _context.Lessons.FindAsync(lessonId);
            if (lesson == null)
            {
                return new GeneralResponse(false, "Lesson not found");
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return new GeneralResponse(true, "Lesson deleted successfully");
        }

        public async Task<IEnumerable<LessonDTO>> GetLessonsAsync()
        {
            return await _context.Lessons.Select(lesson => new LessonDTO
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Description = lesson.Description,
                ImageUrl = lesson.ImageUrl,
                Day = lesson.Day,
                StartTime = lesson.StartTime,
                EndTime = lesson.EndTime
            }).ToListAsync();
        }

        public async Task<IEnumerable<UserLessonDTO>> GetUserLessonsAsync(int userId)
        {
            return await _context.UserLessons
                .Where(ul => ul.UserId == userId)
                .Include(ul => ul.Lesson)
                .Select(ul => new UserLessonDTO
                {
                    UserId = ul.UserId,
                    LessonId = ul.LessonId,
                    Lesson = new LessonDTO
                    {
                        Id = ul.Lesson!.Id,
                        Name = ul.Lesson.Name,
                        Description = ul.Lesson.Description,
                        ImageUrl = ul.Lesson.ImageUrl,
                        Day = ul.Lesson.Day,
                        StartTime = ul.Lesson.StartTime,
                        EndTime = ul.Lesson.EndTime
                    }
                }).ToListAsync();
        }

        public async Task<GeneralResponse> EnrollAsync(UserLessonDTO userLessonDto)
        {
            var userLesson = new UserLesson
            {
                UserId = userLessonDto.UserId,
                LessonId = userLessonDto.LessonId
            };

            _context.UserLessons.Add(userLesson);
            await _context.SaveChangesAsync();

            return new GeneralResponse(true, "Enrolled successfully");
        }

        public async Task<GeneralResponse> CancelAsync(UserLessonDTO userLessonDto)
        {
            var userLesson = await _context.UserLessons
                .FirstOrDefaultAsync(ul => ul.UserId == userLessonDto.UserId && ul.LessonId == userLessonDto.LessonId);

            if (userLesson == null)
            {
                return new GeneralResponse(false, "Enrollment not found");
            }

            _context.UserLessons.Remove(userLesson);
            await _context.SaveChangesAsync();

            return new GeneralResponse(true, "Enrollment cancelled successfully");
        }
    }
}
