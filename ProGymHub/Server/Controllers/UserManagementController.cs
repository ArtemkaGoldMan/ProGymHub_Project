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
    [Authorize(Roles = "Admin")]
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

        [HttpDelete("delete/{userId}")]
        public async Task<ActionResult<GeneralResponse>> DeleteUser(int userId)
        {
            var result = await _userManagementRepository.DeleteUserAsync(userId);
            return Ok(result);
        }
    }
}