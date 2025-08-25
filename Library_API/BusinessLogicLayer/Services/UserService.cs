using Azure.Core;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Facet.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserService: IUserService
    {
        public readonly IUserRepository _repository;
        private readonly IPasswordHelper _passwordHelper;

        public UserService(IUserRepository repository, IPasswordHelper passwordHelper) 
        { 
            _repository = repository;
            _passwordHelper = passwordHelper;
        }

        public async Task CreateUserAsync(UserCreateRequest request)
        {
            User user = new User();
            request.CreateRequestToUser(user);
            user.HashedPassword = _passwordHelper.GeneratePassword(user, request.Password);
            await _repository.CreateAsync(user);
        }

        public async Task<UserGetRequest?> DeleteUserAsync(Guid id)
        {
            var user = await _repository.GetAsync(id);

            if (user == null)
            {
                return null;
            }

            await _repository.DeleteAsync(user);

            return user.ToFacet<User, UserGetRequest>();
        }

        public async Task<IEnumerable<UserGetRequest>> GetAllUsersAsync()
        {
            var users =  await _repository.GetAllAsync();
            var userDtos = users.Select(u => u.ToFacet<User, UserGetRequest>()).ToList();
            return userDtos;
        }

        public async Task<UserGetRequest?> GetUserAsync(Guid id)
        {
            var user = await _repository.GetAsync(id);
            return user == null ? null : user.ToFacet<User, UserGetRequest>();
        }

        public async Task<UserGetRequest?> UpdateUserAsync(Guid id, UserUpdateRequest user_info)
        {
            var user = await _repository.GetAsync(id);

            if (user == null)
            {
                return null;
            }

            user_info.UpdateRequestToUser(user);
       
            await _repository.UpdateAsync();

            return user.ToFacet<User, UserGetRequest>();
        }

    }
}
