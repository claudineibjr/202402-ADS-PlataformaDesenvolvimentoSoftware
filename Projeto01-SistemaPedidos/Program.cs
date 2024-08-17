namespace Projeto01_SistemaPedidos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configura��o do Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                // Inicializa��o do Swagger
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
