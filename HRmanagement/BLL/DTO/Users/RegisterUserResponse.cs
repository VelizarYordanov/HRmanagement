using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRmanagement.BLL.DTO.Users
{
    public enum UserInsertFailReason
    {
        Success,
        UserOrEmailExists,
        UserNameNotAllowed,
        DatabaseInsertionError,
        PasswordsDontMatch
    }
    public class RegisterUserResponse
    {
        public bool Success { get; set; }
        public UserInsertFailReason FailReason { get; set; }
        public string ErrorMessage { get; set; }
    }
}
