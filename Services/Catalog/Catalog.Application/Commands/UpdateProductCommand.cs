using Catalog.Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MediatR;

namespace Catalog.Application.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public ProductBrand Brands { get; set; }
        public ProductType Types { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }
    }
}
