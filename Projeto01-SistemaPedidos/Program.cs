using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Repositories.Data;

namespace Projeto01_OrdersManager
{
    public class Program
    {
        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void InjectRepositoryDependency(IHostApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<OrdersDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            builder.Services.AddControllers();
        }

        private static void InitializeSwagger(WebApplication app) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        private static void SeedOnInitialize(WebApplication app)
        {
            // Configura o banco de dados com dados de seed
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<OrdersDbContext>();
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    // Log error
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureSwagger(builder.Services);
            InjectRepositoryDependency(builder);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Inicialização do Swagger
                InitializeSwagger(app);
            }

            SeedOnInitialize(app);

            app.MapControllers();

            app.Run();
        }
    }
}
