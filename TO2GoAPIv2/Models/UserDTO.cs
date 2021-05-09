using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Models
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

    }

    public class UserDTO : LoginUserDTO
    {
        public string Nick { get; set; }
    }

    public class GetUserDTO
    {
        public string Id { get; set; }
        public string Nick { get; set; }
    }
}
