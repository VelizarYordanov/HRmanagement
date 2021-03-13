using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using HRmanagement.BLL.DTO.Users;
using HRmanagement.DAO;
using HRmanagement.Models;

namespace HRmanagement.BLL
{
    public class UserBLL
    {
        public RegisterUserResponse Register(string Email, string UserName, string Password, string ConfirmPassword)
        {
            if (CheckIfUserExists(Email, UserName))
            {
                return new RegisterUserResponse()
                {
                    Success = false,
                    FailReason = UserInsertFailReason.UserOrEmailExists
                };
            }

            if (!Password.Equals(ConfirmPassword))
            {
                return new RegisterUserResponse()
                {
                    Success = false,
                    FailReason = UserInsertFailReason.PasswordsDontMatch
                };
            }

            // Hash the password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(Password);

            User newUser = new User()
            {
                Email = Email,
                UserName = UserName,
                PasswordHash = passwordHash
            };

            try
            {
                // Insert the user
                UserDAO userDao = new UserDAO();
                ulong userId = userDao.Insert(newUser);

                // Connect the user to a role
                UserRole userRole = new UserRole()
                {
                    UserID = (int)userId,
                    RoleID = 3 // Role of ordinary user is 3
                };
                UserRoleDAO dao = new UserRoleDAO();
                dao.Insert(userRole);

            }
            catch (Exception e)
            {
                return new RegisterUserResponse()
                {
                    Success = false,
                    FailReason = UserInsertFailReason.DatabaseInsertionError,
                    ErrorMessage = e.Message
                };
            }

            return new RegisterUserResponse()
            {
                Success = true,
                FailReason = UserInsertFailReason.Success,
                ErrorMessage = null
            };
        }
        private bool CheckIfUserExists(string Email, string UserName)
        {
            UserDAO dao = new UserDAO();

            return dao.GetAll().Any(u => u.Email == Email || u.UserName == UserName);
        }

        public AuthenticationResponseDto LoginAuthentication(string UserName, string Password)
        {
            // Get user
            UserDAO userDao = new UserDAO();
            User user = userDao.Get("username", UserName);
            if (user == null || user.PasswordHash != Password)
            {
                return new AuthenticationResponseDto()
                {
                    Success = false,
                    ErrorMessage = "Wrong username or password."
                };
            }

            AuthenticationResponseDto dto = new AuthenticationResponseDto();
            dto.Success = true;
            dto.ErrorMessage = null;
            dto.Claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            dto.Claims.Add(new Claim(ClaimTypes.Email, user.Email));

            // TODO: add role to identity claims
            return dto;
        }
    }
}
