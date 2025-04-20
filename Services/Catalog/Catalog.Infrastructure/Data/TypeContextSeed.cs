using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{ 
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typeDataCollection)
        {
            bool existProductType = typeDataCollection.Find(p => true).Any();
            //string path = Path.Combine("Data", "SeedData", "types.json");
            string json = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/types.json"); 
            if (!existProductType)
            {
                //var typeData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(json);
                if (types != null)
                {
                    foreach (var item in types)
                    {
                        typeDataCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}
