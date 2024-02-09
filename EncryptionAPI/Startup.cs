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
        app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/error");
        }

        app.UseDefaultFiles(); // Tala om för ASP.NET Core att använda standardfiler
        app.UseStaticFiles(); // Tala om för ASP.NET Core att tillhandahålla statiska filer

        app.UseRouting();

        app.UseCors("AllowAll");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html"); // Hantera alla andra förfrågningar med index.html
        });
        }
    }
}
