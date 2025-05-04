using BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer.Services
{
    public class TelegramAuthService : ITelegramAuthService
    {
        private readonly string _botToken;

        public TelegramAuthService(IConfiguration configuration)
        {
            _botToken = configuration["TelegramBotToken"];
        }

        public bool ValidateTelegramWebAppHash(string initData, string hash)
        {
            if (string.IsNullOrEmpty(initData) || string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(_botToken))
            {
                return false;
            }

            try
            {
                using (HMACSHA256 hmac = new(Encoding.UTF8.GetBytes(_botToken)))
                {
                    byte[] calculatedHashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(initData));
                    string calculatedHash = BitConverter.ToString(calculatedHashBytes).Replace("-", "").ToLower();

                    return calculatedHash.Equals(hash, StringComparison.CurrentCultureIgnoreCase);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validating hash: {ex.Message}");
                return false;
            }
        }
    }
}
