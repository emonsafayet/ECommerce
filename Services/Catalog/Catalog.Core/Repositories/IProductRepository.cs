using Catalog.Core.Entities;
using Catalog.Core.Spec;
using Catalog.Core.Specs;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    { 
        Task<Product> GetProduct (string id);
        Task<IEnumerable<Product>> GetProductsByName(string productName);
        Task<IEnumerable<Product>> GetProductsByBrand(string name);
        Task<Product>  CreateProduct (Product product); 
        Task<bool>  UpdateProduct (Product product);
        Task<bool>  DeleteProduct (string id);
        Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams);
    }
}
