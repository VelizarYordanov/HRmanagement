using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRmanagement.BLL.DTO.Users
{
    public class AuthenticationResponseDto
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}
