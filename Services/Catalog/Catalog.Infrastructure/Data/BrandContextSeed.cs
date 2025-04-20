using Catalog.Core.Entities;
using MongoDB.Driver;
 using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class BrandContextSeed
    {
        public static void SeedData (IMongoCollection<ProductBrand> brandCollection)
        {
            bool existProductBrands = brandCollection.Find(p => true).Any();
            //string path = Path.Combine("Data","SeedData","brands.json");
            string json = File.ReadAllText("../Catalog.Infrastructure/Data/SeedData/brands.json"); 

            if (!existProductBrands)
            {
                try
                {
                    //var json = File.ReadAllText(jsonFilePath);
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(json);
                    if (brands != null)
                    {
                        foreach (var item in brands)
                        {
                            brandCollection.InsertOneAsync(item);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}

 
