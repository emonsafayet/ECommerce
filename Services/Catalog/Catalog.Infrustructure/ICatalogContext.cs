using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrustructure
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<ProductBrands>  Brands { get; }
        IMongoCollection<ProductType>  Types { get; }

    }
}
