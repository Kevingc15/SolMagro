using SolMagro.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolMagro.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TypeUser Type { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
