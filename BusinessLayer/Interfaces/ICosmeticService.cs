using BusinessLayer.DTOs;

namespace BusinessLayer.Interfaces
{
    public interface ICosmeticService
    {
        Task<CosmeticDTO> GetCosmeticAsync(string id);
        Task<IEnumerable<CosmeticDTO>> GetAllCosmeticsAsync();
        Task AddCosmeticAsync(CosmeticDTO cosmetic);
        Task UpdateCosmeticAsync(string id, CosmeticDTO cosmetic);
        Task DeleteCosmeticAsync(string id);
    }
}
