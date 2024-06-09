using BaseLibrary.DTOs;
using BaseLibrary.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Contracts
{
    public interface IUserManagementRepository
    {
        Task<IEnumerable<UserDetailDTO>> GetAllUsersAsync();
        Task<UserDetailDTO> GetUserByIdAsync(int userId);
        Task<GeneralResponse> UpdateUserAsync(UserDetailDTO userDetail);
        Task<GeneralResponse> DeleteUserAsync(int userId);
    }
}