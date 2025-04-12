using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrustructure
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<ProductBrand>  Brands { get; }
        IMongoCollection<ProductType>  Types { get; }

    }
}
