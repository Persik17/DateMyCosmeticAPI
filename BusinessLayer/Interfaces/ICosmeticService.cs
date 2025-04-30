using BusinessLayer.DTOs;

namespace BusinessLayer.Interfaces
{
    public interface ICosmeticService
    {
        Task<UserDTO> AddCosmetic<T>(Guid userId);
        Task<UserDTO> GetCosmeticsByUserId(Guid userId);
    }
}
