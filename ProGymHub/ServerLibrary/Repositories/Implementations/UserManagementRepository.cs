﻿using BaseLibrary.DTOs;
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
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly AppDbContext _context;

        public UserManagementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDetailDTO>> GetAllUsersAsync()
        {
            return await _context.ApplicationUsers.Select(user => new UserDetailDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhotoUrl = user.PhotoUrl
            }).ToListAsync();
        }

        public async Task<UserDetailDTO> GetUserByIdAsync(int userId)
        {
            var user = await _context.ApplicationUsers.FindAsync(userId);
            if (user == null) return null;

            return new UserDetailDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhotoUrl = user.PhotoUrl
            };
        }

        public async Task<GeneralResponse> UpdateUserAsync(UserDetailDTO userDetail)
        {
            var user = await _context.ApplicationUsers.FindAsync(userDetail.Id);
            if (user == null)
            {
                return new GeneralResponse(false, "User not found");
            }

            user.FullName = userDetail.FullName;
            user.Email = userDetail.Email;
            user.PhotoUrl = userDetail.PhotoUrl;

            _context.ApplicationUsers.Update(user);
            await _context.SaveChangesAsync();

            return new GeneralResponse(true, "User updated successfully");
        }

        public async Task<GeneralResponse> DeleteUserAsync(int userId)
        {
            var user = await _context.ApplicationUsers.FindAsync(userId);
            if (user == null)
            {
                return new GeneralResponse(false, "User not found");
            }

            _context.ApplicationUsers.Remove(user);
            await _context.SaveChangesAsync();

            return new GeneralResponse(true, "User deleted successfully");
        }
    }
}