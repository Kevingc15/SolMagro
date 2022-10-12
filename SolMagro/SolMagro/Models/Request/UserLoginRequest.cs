using System;
using System.Collections.Generic;
using System.Text;

namespace SolMagro.Models.Request
{
    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
