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
                // Verifica se há dados na tabela de produtos
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product { Name = "Veja Multiuso", Description = "Desinfetante multiuso para limpeza", Price = 5.0 },
                        new Product { Name = "Omo Desinfetante", Description = "Desinfetante para pisos e superfícies", Price = 6.5 },
                        new Product { Name = "Bombril Esponja", Description = "Esponja de aço para limpeza de panelas", Price = 2.5 },
                        new Product { Name = "Biscuits Recheado Trakinas", Description = "Biscoito recheado com chocolate", Price = 4.5 },
                        new Product { Name = "Biscuits Recheado Bono", Description = "Biscoito recheado com morango", Price = 4.5 },
                        new Product { Name = "Coca-Cola", Description = "Refrigerante sabor cola", Price = 5.0 },
                        new Product { Name = "Fanta Laranja", Description = "Refrigerante sabor laranja", Price = 5.0 },
                        new Product { Name = "Tal & Qual", Description = "Adoçante light para café", Price = 8.0 },
                        new Product { Name = "Óleo de Cozinha Liza Light", Description = "Óleo de cozinha light", Price = 8.5 },
                        new Product { Name = "Dove Sabonete Líquido", Description = "Sabonete líquido para mãos", Price = 4.5 },
                        new Product { Name = "Pantene Shampoo", Description = "Shampoo hidratante", Price = 10.0 },
                        new Product { Name = "Nivea Condicionador", Description = "Condicionador para cabelos secos", Price = 10.5 },
                        new Product { Name = "Club Social Biscoito Salgado", Description = "Biscoito salgado para lanches", Price = 3.5 },
                        new Product { Name = "Qboa Água Sanitária", Description = "Água sanitária para limpeza", Price = 4.5 },
                        new Product { Name = "Guaraná Antarctica", Description = "Refrigerante sabor guaraná", Price = 5.0 },
                        new Product { Name = "Snack Light Açaí", Description = "Snack light para dieta", Price = 7.5 },
                        new Product { Name = "Neutrogena Sabonete Facial", Description = "Sabonete facial para pele oleosa", Price = 7.5 },
                        new Product { Name = "Desinfetante Ypê", Description = "Desinfetante com aroma de lavanda", Price = 7.0 },
                        new Product { Name = "Biscoito Integral Marilan", Description = "Biscoito integral com grãos", Price = 5.5 },
                        new Product { Name = "Pepsi Diet", Description = "Refrigerante diet sem açúcar", Price = 6.0 }
                    );
                }

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Name = "Maria Silva",
                            Email = "maria.silva@example.com",
                            PhoneNumber = "11987654321"
                        },
                        new Customer
                        {
                            Name = "João Souza",
                            Email = "joao.souza@example.com",
                            PhoneNumber = "21912345678"
                        },
                        new Customer
                        {
                            Name = "Ana Pereira",
                            Email = "ana.pereira@example.com",
                            PhoneNumber = "31998765432"
                        },
                        new Customer
                        {
                            Name = "Carlos Oliveira",
                            Email = "carlos.oliveira@example.com",
                            PhoneNumber = "41987651234"
                        },
                        new Customer
                        {
                            Name = "Fernanda Costa",
                            Email = "fernanda.costa@example.com",
                            PhoneNumber = "51932148765"
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
