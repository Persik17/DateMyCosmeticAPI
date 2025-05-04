using AutoMapper;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using DataAccessLayer.DataModels;
using DataAccessLayer.Repositories;

namespace BusinessLayer.Services
{
    public class TelegramAccountService : ITelegramAccountService
    {
        private readonly TelegramAccountRepository _telegramAccountRepository;
        private readonly IMapper _mapper;

        public TelegramAccountService(TelegramAccountRepository telegramAccountRepository, IMapper mapper)
        {
            _telegramAccountRepository = telegramAccountRepository;
            _mapper = mapper;
        }

        public async Task<TelegramAccountDTO> GetTelegramAccountAsync(string telegramId)
        {
            var account = await _telegramAccountRepository.GetByIdAsync(telegramId);
            return _mapper.Map<TelegramAccountDTO>(account);
        }

        public async Task<TelegramAccountDTO> GetTelegramAccountByIdAsync(string id)
        {
            var account = await _telegramAccountRepository.GetByIdAsync(id);
            return _mapper.Map<TelegramAccountDTO>(account);
        }

        public async Task AddTelegramAccountAsync(TelegramAccountDTO accountDTO)
        {
            var account = _mapper.Map<TelegramAccount>(accountDTO);
            await _telegramAccountRepository.AddAsync(account);
        }

        public async Task UpdateTelegramAccountAsync(string id, TelegramAccountDTO accountDTO)
        {
            var account = _mapper.Map<TelegramAccount>(accountDTO);
            await _telegramAccountRepository.UpdateAsync(id, account);
        }

        public async Task DeleteTelegramAccountAsync(string id)
        {
            await _telegramAccountRepository.DeleteAsync(id);
        }
    }
}
