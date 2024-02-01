namespace AESWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Controllers för MVC
            services.AddControllers();

            // Service för AES-kryptering som en Singleton
            services.AddSingleton<IAESEncryptionService, AESEncryptionService>();

            // CORS-konfiguration
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin() // Tillåt alla ursprung
                            .AllowAnyMethod() // Tillåt alla metoder (GET, POST, PUT, etc.)
                            .AllowAnyHeader(); // Tillåt alla rubriker
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Visa detaljerad felinformation i utvecklingsmiljön
                app.UseDeveloperExceptionPage();
            }

            // Aktivera routing
            app.UseRouting();

            // Använd CORS-policyen "AllowAll"
            app.UseCors("AllowAll");

            // Slutpunkt för controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
