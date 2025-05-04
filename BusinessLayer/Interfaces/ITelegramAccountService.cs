using BusinessLayer.DTOs;

namespace BusinessLayer.Interfaces
{
    public interface ITelegramAccountService
    {
        Task<TelegramAccountDTO> GetTelegramAccountAsync(string telegramId);
        Task<TelegramAccountDTO> GetTelegramAccountByIdAsync(string id);
        Task AddTelegramAccountAsync(TelegramAccountDTO account);
        Task UpdateTelegramAccountAsync(string id, TelegramAccountDTO account);
        Task DeleteTelegramAccountAsync(string id);
    }
}
