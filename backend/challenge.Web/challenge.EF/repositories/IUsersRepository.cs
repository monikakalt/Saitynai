using challenge.EF.entities;
using System.Collections.Generic;

namespace challenge.EF.repositories
{
    public interface IUsersRepository
    {
        List<Users> GetUsers();
        Users GetUserById(int id);
        void Save(Users user);

        Users Authenticate(string username, string password);
    }
}