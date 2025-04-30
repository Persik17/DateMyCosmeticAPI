using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CosmeticService : ICosmeticService
    {
        public Task<UserDTO> AddCosmetic<T>(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetCosmeticsByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
