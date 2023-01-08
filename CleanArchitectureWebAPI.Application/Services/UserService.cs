using AutoMapper;
using CleanArchitectureWebAPI.Application.Interfaces;
using CleanArchitectureWebAPI.Application.ViewModels.User;
using CleanArchitectureWebAPI.Domain.Interfaces;
using CleanArchitectureWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWebAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public UserViewModel AddUser(UserViewModel userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            var addedUser = _userRepository.Add(user);

            _userRepository.SaveChanges();

            return _mapper.Map<UserViewModel>(addedUser);
        }

        public UserViewModel GetUserById(Guid id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserViewModel>(user);
        }

    }
}
