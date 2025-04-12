using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MongoDB.Driver;

namespace Catalog.Infrustructure.Repositories
{
    public class ProductRepository : IProductRepository, IBrandRepository, ITypesRepository
    {
        public ICatalogContext _context { get; }

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }


        async Task<Product> IProductRepository.GetProduct(string id)
        {
            return await _context.Products
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
        async Task<IEnumerable<Product>> IProductRepository.GetProducts()
        {
            return await _context.Products
                .Find(p => true)
                .ToListAsync();
        }
        async Task<IEnumerable<Product>> IProductRepository.GetProductByBrand(string productName)
        {
            return await _context.Products
                .Find(p => p.Name.ToLower() == productName.ToLower())
                .ToListAsync();
        }
        async Task<IEnumerable<Product>> IProductRepository.GetProductByName(string brandName)
        {
            return await _context
               .Products
               .Find(p => p.Brands.Name.ToLower() == brandName.ToLower())
               .ToListAsync();
        }
        async Task<Product> IProductRepository.CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
            return product;
        }

        async Task<bool> IProductRepository.DeleteProduct(string id)
        {
            var deleteResult = _context.Products.DeleteOne(p => p.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
        async Task<bool> IProductRepository.UpdateProduct(Product product)
        {
            var updateResult = _context.Products.ReplaceOne(p => p.Id == product.Id, product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
        async Task<IEnumerable<ProductBrand>> IBrandRepository.GetAllBrands()
        {
            return await _context.Brands
                .Find(b => true)
                .ToListAsync();
        }

        async Task<IEnumerable<ProductType>> ITypesRepository.GetAllTypes()
        {
            return await _context.Types
                .Find(t => true)
                .ToListAsync();
        }

    }
}
