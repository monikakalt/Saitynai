using challenge.Application.main.users.dto;
using System.Collections.Generic;

namespace challenge.Application.main.users
{
    public interface IUsersService
    {
        IEnumerable<UsersDto> GetAllUsers();
        UsersDto GetUserById(int id);
        void Save(UsersDto user);
        void UpdateUser(UsersDto user, string password = null);
        UsersDto Authenticate(string username, string password);
    }
}