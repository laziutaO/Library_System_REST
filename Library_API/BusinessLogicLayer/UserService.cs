using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserService: IUserService
    {
        public readonly IBaseRepository<User> _repository;

        public UserService(IBaseRepository<User> repository) 
        { 
            _repository = repository;
        }

        public async Task CreateUserAsync(User user)
        {
            await _repository.CreateAsync(user);
        }

        public async Task<User> DeleteUserAsync(Guid id)
        {
            var user = await _repository.GetAsync(id);

            if (user == null)
            {
                return null;
            }

            await _repository.DeleteAsync(user);

            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<User> UpdateUserAsync(Guid id, User user_info)
        {
            var user = await _repository.GetAsync(id);

            if (user == null)
            {
                return null;
            }

            user.FirstName = user_info.FirstName;
            user.LastName = user_info.LastName;
            user.Phone = user_info.Phone;

            await _repository.UpdateAsync();

            return user;
        }
    }
}
