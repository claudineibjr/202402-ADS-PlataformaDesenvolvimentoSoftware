using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Models;

namespace Projeto01_OrdersManager.Repositories.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OrdersDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OrdersDbContext>>()))
            {
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product { Id = "Veja", Name = "Veja Multiuso", Description = "Desinfetante multiuso para limpeza", Price = 5.0 },
                        new Product { Id = "Omo", Name = "Omo Desinfetante", Description = "Desinfetante para pisos e superfícies", Price = 6.5 },
                        new Product { Id = "Bombril", Name = "Bombril Esponja", Description = "Esponja de aço para limpeza de panelas", Price = 2.5 },
                        new Product { Id = "Trakinas", Name = "Biscuits Recheado Trakinas", Description = "Biscoito recheado com chocolate", Price = 4.5 },
                        new Product { Id = "Bono", Name = "Biscuits Recheado Bono", Description = "Biscoito recheado com morango", Price = 4.5 },
                        new Product { Id = "Coca_Cola", Name = "Coca-Cola", Description = "Refrigerante sabor cola", Price = 5.0 },
                        new Product { Id = "Fanta", Name = "Fanta Laranja", Description = "Refrigerante sabor laranja", Price = 5.0 },
                        new Product { Id = "Tal_Qual", Name = "Tal & Qual", Description = "Adoçante light para café", Price = 8.0 },
                        new Product { Id = "Liza_Light", Name = "Óleo de Cozinha Liza Light", Description = "Óleo de cozinha light", Price = 8.5 },
                        new Product { Id = "Dove", Name = "Dove Sabonete Líquido", Description = "Sabonete líquido para mãos", Price = 4.5 },
                        new Product { Id = "Pantene", Name = "Pantene Shampoo", Description = "Shampoo hidratante", Price = 10.0 },
                        new Product { Id = "Nivea", Name = "Nivea Condicionador", Description = "Condicionador para cabelos secos", Price = 10.5 },
                        new Product { Id = "Club_Social", Name = "Club Social Biscoito Salgado", Description = "Biscoito salgado para lanches", Price = 3.5 },
                        new Product { Id = "Qboa", Name = "Qboa Água Sanitária", Description = "Água sanitária para limpeza", Price = 4.5 },
                        new Product { Id = "Guaraná_Antarctica", Name = "Guaraná Antarctica", Description = "Refrigerante sabor guaraná", Price = 5.0 },
                        new Product { Id = "Snack_Açaí", Name = "Snack Light Açaí", Description = "Snack light para dieta", Price = 7.5 },
                        new Product { Id = "Neutrogena", Name = "Neutrogena Sabonete Facial", Description = "Sabonete facial para pele oleosa", Price = 7.5 },
                        new Product { Id = "Ypê", Name = "Desinfetante Ypê", Description = "Desinfetante com aroma de lavanda", Price = 7.0 },
                        new Product { Id = "Marilan", Name = "Biscoito Integral Marilan", Description = "Biscoito integral com grãos", Price = 5.5 },
                        new Product { Id = "Pepsi_Diet", Name = "Pepsi Diet", Description = "Refrigerante diet sem açúcar", Price = 6.0 }
                    );
                }

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer { Id = "Maria_Silva", Name = "Maria Silva", Email = "maria.silva@example.com", PhoneNumber = "11987654321" },
                        new Customer { Id = "João_Souza", Name = "João Souza", Email = "joao.souza@example.com", PhoneNumber = "21912345678" },
                        new Customer { Id = "Ana_Pereira", Name = "Ana Pereira", Email = "ana.pereira@example.com", PhoneNumber = "31998765432" },
                        new Customer { Id = "Carlos_Oliveira", Name = "Carlos Oliveira", Email = "carlos.oliveira@example.com", PhoneNumber = "41987651234" },
                        new Customer { Id = "Fernanda_Costa", Name = "Fernanda Costa", Email = "fernanda.costa@example.com", PhoneNumber = "51932148765" }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
