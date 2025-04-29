namespace DateMyCosmeticAPI.Configuration
{
    public class TelegramAppPolicy
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("TelegramAppPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            services.AddControllers();
        }
    }
}
