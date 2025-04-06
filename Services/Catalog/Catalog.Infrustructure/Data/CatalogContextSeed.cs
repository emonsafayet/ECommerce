using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrustructure.Data
{ 
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productDataCollection)
        {
            bool existProduct = productDataCollection.Find(p => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!existProduct)
            {
                var productData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                if (products != null)
                {
                    foreach (var item in products)
                    {
                        productDataCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }


}
