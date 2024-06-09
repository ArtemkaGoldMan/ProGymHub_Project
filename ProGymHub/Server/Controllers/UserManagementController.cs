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
    [Authorize]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserManagementRepository _userManagementRepository;

        public UserManagementController(IUserManagementRepository userManagementRepository)
        {
            _userManagementRepository = userManagementRepository;
        }

        [HttpGet("all-users")]
        public async Task<ActionResult<IEnumerable<UserDetailDTO>>> GetAllUsers()
        {
            var users = await _userManagementRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDetailDTO>> GetUserById(int userId)
        {
            var user = await _userManagementRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound(new GeneralResponse(false, "User not found"));
            }

            return Ok(user);
        }

        [HttpPut("update")]
        public async Task<ActionResult<GeneralResponse>> UpdateUser(UserDetailDTO userDetail)
        {
            var result = await _userManagementRepository.UpdateUserAsync(userDetail);
            if (!result.Flag)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("delete/{userId}")]
        public async Task<ActionResult<GeneralResponse>> DeleteUser(int userId)
        {
            var result = await _userManagementRepository.DeleteUserAsync(userId);
            return Ok(result);
        }
    }
}