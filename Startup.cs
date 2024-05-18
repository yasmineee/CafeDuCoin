using CafeDuCoin.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CafeDuCoin
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
            // Configuration de la connexion à la base de données
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            // Ajout du support pour les services
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IGameHistoryService, GameHistoryService>();

            // Ajout du support pour les contrôleurs API
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:8080")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Afficher les pages d'erreur détaillées en mode développement
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Gérer les erreurs d'une manière plus conviviale en production
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Activer la gestion des requêtes HTTP
            app.UseRouting();

            app.UseCors("AllowOrigin");
            // Activer l'authentification et l'autorisation (si nécessaire)
            // app.UseAuthentication();
            // app.UseAuthorization();

            // Définir les points de terminaison pour les contrôleurs API
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
