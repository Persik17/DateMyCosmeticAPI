using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        public Task<UserDTO> GetUser<T>(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
