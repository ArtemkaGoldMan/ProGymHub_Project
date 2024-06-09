using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDTO>>> GetAllLessons()
        {
            var lessons = await _lessonRepository.GetLessonsAsync();
            return Ok(lessons);
        }

        [HttpGet("my-lessons/{userId}")]
        public async Task<ActionResult<IEnumerable<UserLessonDTO>>> GetUserLessons(int userId)
        {
            var lessons = await _lessonRepository.GetUserLessonsAsync(userId);
            return Ok(lessons);
        }

        [Authorize/*(Roles = "Admin")*/]
        [HttpPost("create")]
        public async Task<ActionResult<GeneralResponse>> CreateLesson(LessonDTO lessonDto)
        {
            var result = await _lessonRepository.CreateLessonAsync(lessonDto);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update/{id}")]
        public async Task<ActionResult<GeneralResponse>> UpdateLesson(int id, LessonDTO lessonDto)
        {
            if (id != lessonDto.Id)
            {
                return BadRequest("Lesson ID mismatch");
            }

            var result = await _lessonRepository.UpdateLessonAsync(lessonDto);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<GeneralResponse>> DeleteLesson(int id)
        {
            var result = await _lessonRepository.DeleteLessonAsync(id);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("enroll")]
        public async Task<ActionResult<GeneralResponse>> EnrollInLesson(UserLessonDTO userLessonDto)
        {
            var result = await _lessonRepository.EnrollAsync(userLessonDto);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("cancel")]
        public async Task<ActionResult<GeneralResponse>> CancelEnrollment(UserLessonDTO userLessonDto)
        {
            var result = await _lessonRepository.CancelAsync(userLessonDto);
            return Ok(result);
        }
    }
}
