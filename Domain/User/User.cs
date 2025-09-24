using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class User
    {
        public int Id { get; init; }
        public string Email { get; set; }
        public string Language { get; set; }

        public User(string email, string language)
        {
            Email = email;
            Language = language;
        }
    }
}
