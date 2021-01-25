using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Apresentacao.Repositories
{
    public class UserRepository
    {
        public static UserEntity Get(string username, string password) 
        {
            var users = new List<UserEntity>();
            users.Add(new UserEntity { Id = 1, Username = "marcio.freitas", Password = "1234" });
            return users.Where(u => u.Username.ToLower() == username.ToLower() && u.Password == u.Password).FirstOrDefault();
        }
    }
}
