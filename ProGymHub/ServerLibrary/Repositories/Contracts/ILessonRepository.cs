using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Contracts
{
    public interface ILessonRepository
    {
        Task<GeneralResponse> CreateLessonAsync(LessonDTO lessonDto);
        Task<GeneralResponse> UpdateLessonAsync(LessonDTO lessonDto);
        Task<GeneralResponse> DeleteLessonAsync(int lessonId);
        Task<IEnumerable<LessonDTO>> GetLessonsAsync();
        Task<IEnumerable<UserLessonDTO>> GetUserLessonsAsync(int userId);
        Task<GeneralResponse> EnrollAsync(UserLessonDTO userLessonDto);
        Task<GeneralResponse> CancelAsync(UserLessonDTO userLessonDto);
    }
}
