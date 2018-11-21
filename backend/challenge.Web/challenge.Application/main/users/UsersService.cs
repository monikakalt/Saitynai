using AutoMapper;
using challenge.Application.helpers;
using challenge.Application.main.users.dto;
using challenge.EF.entities;
using challenge.EF.repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge.Application.main.users
{
    public class UsersService: IUsersService
    {
        protected readonly IUsersRepository _usersRepository;
        protected readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UsersService(IUsersRepository usersRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public UsersDto Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;
            var user = _usersRepository.Authenticate(username, password);

            // check if username exists
            if (user == null)
                return null;

            var userDto = _mapper.Map<UsersDto>(user);
            // authentication successful
            return userDto;
        }

        public void UpdateUser(UsersDto user, string password = null)
        {

        }
        public IEnumerable<UsersDto> GetAllUsers()
        {
            var list = _usersRepository.GetUsers();
            var listDto = _mapper.Map<List<UsersDto>>(list);
            return listDto;
        }

        public UsersDto GetUserById(int id) {
            var user = _usersRepository.GetUserById(id);
            var userDto = _mapper.Map<UsersDto>(user);
            return userDto;
        }

        public void Save (UsersDto user)
        {
            var userNormal = _mapper.Map<Users>(user);
            _usersRepository.Save(userNormal);
        }
    }
}
