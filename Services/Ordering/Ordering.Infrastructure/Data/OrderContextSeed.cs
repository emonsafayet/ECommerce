using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Ordering Database: {typeof(OrderContext).Name} seeded!!!");
            }
        }

        private static IEnumerable<Order> GetOrders()
        {
            return new List<Order>
            {
                new()
                {
                    UserName = "emonsafayet",
                    FirstName = "Safayet",
                    LastName = "Hosain",
                    EmailAddress = "emonsafayet@eCommerce.net",
                    AddressLine = "Chittagong",
                    Country = "Bangladesh",
                    TotalPrice = 750,
                    State = "CHA",
                    ZipCode = "4202",

                    CardName = "Visa",
                    CardNumber = "1234567890123456",
                    CreatedBy = "Safayet",
                    Expiration = "12/25",
                    Cvv = "123",
                    PaymentMethod = 1,
                    LastModifiedBy = "Safayet",
                    LastModifiedDate = new DateTime(),
                }
            };
        }
    }
}