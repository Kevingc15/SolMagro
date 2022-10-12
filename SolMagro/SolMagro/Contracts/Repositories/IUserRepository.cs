using SolMagro.Models.Request;
using SolMagro.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SolMagro.Models.Response;

namespace SolMagro.Contracts.Repositories
{
    public interface IUserRepository
    {
        bool UserLogin(UserLoginRequest userRequest);
        User GetUserData(UserLoginRequest userRequest);
        
    }
}
