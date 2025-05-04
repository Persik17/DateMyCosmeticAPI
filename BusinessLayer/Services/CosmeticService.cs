using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using DataAccessLayer.DataModels;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class CosmeticService : ICosmeticService
    {
        private readonly CosmeticRepository _cosmeticRepository;
        private readonly IMapper _mapper;

        public CosmeticService(CosmeticRepository cosmeticRepository, IMapper mapper)
        {
            _cosmeticRepository = cosmeticRepository;
            _mapper = mapper;
        }

        public async Task<CosmeticDTO> GetCosmeticAsync(string id)
        {
            var cosmetic = await _cosmeticRepository.GetByIdAsync(id);
            return _mapper.Map<CosmeticDTO>(cosmetic);
        }

        public async Task<IEnumerable<CosmeticDTO>> GetAllCosmeticsAsync()
        {
            var cosmetics = await _cosmeticRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CosmeticDTO>>(cosmetics);
        }

        public async Task AddCosmeticAsync(CosmeticDTO cosmeticDTO)
        {
            var cosmetic = _mapper.Map<Cosmetic>(cosmeticDTO);
            await _cosmeticRepository.AddAsync(cosmetic);
        }

        public async Task UpdateCosmeticAsync(string id, CosmeticDTO cosmeticDTO)
        {
            var cosmetic = _mapper.Map<Cosmetic>(cosmeticDTO);
            await _cosmeticRepository.UpdateAsync(id, cosmetic);
        }

        public async Task DeleteCosmeticAsync(string id)
        {
            await _cosmeticRepository.DeleteAsync(id);
        }
    }
}
