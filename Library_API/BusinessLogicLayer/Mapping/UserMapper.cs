using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Mapping
{
    public static class UserMapper
    {
        public static UserGetRequest UserToGetDto(this User user)
        {
            return new(
                user.FirstName,
                user.LastName,
                user.Phone,
                user.Email,
                user.IsBlocked);
        }

        public static void CreateRequestToUser(this UserCreateRequest request, User user) 
        {
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Phone = request.Phone;
            user.Email = request.Email;
            user.IsBlocked = request.IsBlocked;
        }

        public static void UpdateRequestToUser(this UserUpdateRequest request, User user)
        {
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Phone = request.Phone;
            user.Email = request.Email;
            user.IsBlocked = request.IsBlocked;
        }
    }
}
