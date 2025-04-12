using Catalog.Core.Entities;
using Catalog.Infrustructure.Data;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrustructure
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<ProductBrand> Brands { get; }

        public IMongoCollection<ProductType> Types { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]); 
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            Brands = database.GetCollection<ProductBrand>(configuration["DatabaseSettings:BrandsCollectionName"]);
            Types = database.GetCollection<ProductType>(configuration["DatabaseSettings:TypesCollectionName"]);
            BrandContextSeed.SeedData(Brands);
            TypeContextSeed.SeedData(Types);
            CatalogContextSeed.SeedData(Products);


        }
    }
}
