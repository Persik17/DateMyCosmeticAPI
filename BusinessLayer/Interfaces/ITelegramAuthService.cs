namespace BusinessLayer.Interfaces
{
    public interface ITelegramAuthService
    {
        bool ValidateTelegramWebAppHash(string initData, string hash);
    }
}
