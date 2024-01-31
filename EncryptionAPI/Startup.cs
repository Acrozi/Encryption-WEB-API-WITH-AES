using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddControllers();

<<<<<<< HEAD
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            //Service för AES-kryptering
=======
            // service för AES-kryptering
>>>>>>> Stashed changes
=======
            // service för AES-kryptering
>>>>>>> Stashed changes
=======
            //Service för AES-kryptering
>>>>>>> bd4571502cf47a9f531528644e135bdd862d8d53
            services.AddSingleton<IAESEncryptionService, AESEncryptionService>();

            // CORS-konfiguration
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

<<<<<<< HEAD
            // CORS-policyen
=======
            // Använd CORS-policyen
>>>>>>> bd4571502cf47a9f531528644e135bdd862d8d53
            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
