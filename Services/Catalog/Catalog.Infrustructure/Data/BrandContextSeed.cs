using Catalog.Core.Entities;
using MongoDB.Driver;
 using System.Text.Json;

namespace Catalog.Infrustructure.Data
{
    public static class BrandContextSeed
    {
        public static void SeedData (IMongoCollection<ProductBrand> brandCollection)
        {
            bool existProductBrands = brandCollection.Find(p => true).Any();
            string path = Path.Combine("Data","SeedData","brands.json");
            if (!existProductBrands)
            {
                var brandData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                if (brands != null)
                {
                    foreach (var item in brands)
                    {
                        brandCollection.InsertOneAsync(item);
                    }
                }
            }
        }
    }
}
