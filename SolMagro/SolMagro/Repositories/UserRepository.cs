using SolMagro.Contracts.Repositories;
using SolMagro.Models;
using SolMagro.Models.Request;
using SolMagro.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SolMagro.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User GetUserData(UserLoginRequest userRequest)
        {
            foreach (User user in Users)
            {
                if (userRequest.Email == user.Email)
                {
                    return user;
                }
            }
            return null;
        }

        public bool UserLogin(UserLoginRequest userRequest)
        {
            try
            {
                foreach(User user in Users)
                {
                    if (userRequest.Email == user.Email
                        && userRequest.Password == user.Password)
                    {
                        return true;
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return false;
        }


        private List<User> Users = new List<User>()
            {
                new User(){ Id = 1,
                            Name = "Kevin",
                            Email = "kevingcorrea@gmail.com",
                            Password ="kevin123",
                            Type = Enumerations.TypeUser.Worker,
                            Jobs = new List<Job>()
                            {
                                new Job()
                                {
                                       Id = 1,
                                       Title= "Pintar pared",
                                       Description = "Pintar pared lateral de la finca",
                                       Place = "Finca la maria",
                                       Category = "Pintar",
                                       State = Enumerations.JobState.Pending,
                                       Date = new DateTime (2022, 10, 10),
                                       PhotosLink = new List<string>(),
                                       Comments = new List<string>()
                                },
                                new Job()
                                {
                                       Id = 2,
                                       Title= "Sembrar arboles",
                                       Description = "Sembrar 200 arboles",
                                       Place = "Finca la maria",
                                       Category = "Siembra",
                                       State = Enumerations.JobState.Pending,
                                       Date = new DateTime (2022, 10, 15),
                                       PhotosLink = new List<string>(),
                                       Comments = new List<string>()
                                       {
                                           "Comprar aras antes de empezar"
                                       }
                                }
                            }
                },
                new User()
                {
                    Id = 2,
                    Name = "Daniel",
                    Email = "daniel@technium.dev",
                    Password = "daniel123",
                    Type = Enumerations.TypeUser.Worker,
                    Jobs = new List<Job>()
                            {
                                new Job()
                                {
                                       Id = 1,
                                       Title= "Pintar pared",
                                       Description = "Pintar pared lateral de la finca",
                                       Place = "Finca la maria",
                                       Category = "Pintar",
                                       State = Enumerations.JobState.Pending,
                                       Date = new DateTime (2022, 10, 10),
                                       PhotosLink = new List<string>(),
                                       Comments = new List<string>()
                                },
                                new Job()
                                {
                                       Id = 2,
                                       Title= "Sembrar arboles",
                                       Description = "Sembrar 200 arboles",
                                       Place = "Finca la maria",
                                       Category = "Siembra",
                                       State = Enumerations.JobState.Pending,
                                       Date = new DateTime (2022, 10, 15),
                                       PhotosLink = new List<string>(),
                                       Comments = new List<string>()
                                       {
                                           "Comprar aras antes de empezar"
                                       }
                                }
                            }
                }
            };
    }
}
