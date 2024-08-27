using Microsoft.EntityFrameworkCore;
using Projeto01_OrdersManager.Core.Models;

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
                        new Product(id: "Veja", name: "Veja Multiuso", description: "Desinfetante multiuso para limpeza", price: 5.0),
                        new Product(id: "Omo", name: "Omo Desinfetante", description: "Desinfetante para pisos e superfícies", price: 6.5),
                        new Product(id: "Bombril", name: "Bombril Esponja", description: "Esponja de aço para limpeza de panelas", price: 2.5),
                        new Product(id: "Trakinas", name: "Biscuits Recheado Trakinas", description: "Biscoito recheado com chocolate", price: 4.5),
                        new Product(id: "Bono", name: "Biscuits Recheado Bono", description: "Biscoito recheado com morango", price: 4.5),
                        new Product(id: "Coca_Cola", name: "Coca-Cola", description: "Refrigerante sabor cola", price: 5.0),
                        new Product(id: "Fanta", name: "Fanta Laranja", description: "Refrigerante sabor laranja", price: 5.0),
                        new Product(id: "Tal_Qual", name: "Tal & Qual", description: "Adoçante light para café", price: 8.0),
                        new Product(id: "Liza_Light", name: "Óleo de Cozinha Liza Light", description: "Óleo de cozinha light", price: 8.5),
                        new Product(id: "Dove", name: "Dove Sabonete Líquido", description: "Sabonete líquido para mãos", price: 4.5),
                        new Product(id: "Pantene", name: "Pantene Shampoo", description: "Shampoo hidratante", price: 10.0),
                        new Product(id: "Nivea", name: "Nivea Condicionador", description: "Condicionador para cabelos secos", price: 10.5),
                        new Product(id: "Club_Social", name: "Club Social Biscoito Salgado", description: "Biscoito salgado para lanches", price: 3.5),
                        new Product(id: "Qboa", name: "Qboa Água Sanitária", description: "Água sanitária para limpeza", price: 4.5),
                        new Product(id: "Guaraná_Antarctica", name: "Guaraná Antarctica", description: "Refrigerante sabor guaraná", price: 5.0),
                        new Product(id: "Snack_Açaí", name: "Snack Light Açaí", description: "Snack light para dieta", price: 7.5),
                        new Product(id: "Neutrogena", name: "Neutrogena Sabonete Facial", description: "Sabonete facial para pele oleosa", price: 7.5),
                        new Product(id: "Ypê", name: "Desinfetante Ypê", description: "Desinfetante com aroma de lavanda", price: 7.0),
                        new Product(id: "Marilan", name: "Biscoito Integral Marilan", description: "Biscoito integral com grãos", price: 5.5),
                        new Product(id: "Pepsi_Diet", name: "Pepsi Diet", description: "Refrigerante diet sem açúcar", price: 6.0)
                    );
                }

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer(id: "Maria_Silva", name: "Maria Silva", email: "maria.silva@example.com", phoneNumber: "11987654321"),
                        new Customer(id: "João_Souza", name: "João Souza", email: "joao.souza@example.com", phoneNumber: "21912345678"),
                        new Customer(id: "Ana_Pereira", name: "Ana Pereira", email: "ana.pereira@example.com", phoneNumber: "31998765432"),
                        new Customer(id: "Carlos_Oliveira", name: "Carlos Oliveira", email: "carlos.oliveira@example.com", phoneNumber: "41987651234"),
                        new Customer(id: "Fernanda_Costa", name: "Fernanda Costa", email: "fernanda.costa@example.com", phoneNumber: "51932148765")
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
