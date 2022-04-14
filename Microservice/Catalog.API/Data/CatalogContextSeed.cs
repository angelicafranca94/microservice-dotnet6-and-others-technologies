using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        bool existsProduct = productCollection.Find(p => true).Any();

        if (!existsProduct)
            productCollection.InsertManyAsync(GetMyProducts());
    }

    private static IEnumerable<Product> GetMyProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id = "LpAj7FWXpX5lFmXWcfMO6KxB",
                Name = "Iphone X",
                Description = "Phone Apple Industries",
                Image= "product1.png",
                Price = 11.000M,
                Category = "Phone Mobile"
                
            },
            new Product()
            {
                Id = "EGH4Js6Qs2akqxmorEDqq2xT",
                Name = "OnePlus8T",
                Description = "Phone Oneplus Industries",
                Image= "product1.png",
                Price = 3.000M,
                Category = "Phone Mobile"

            },
             new Product()
            {
                Id = "TsJUHzbpPyn0HPJ6gFYhSPEk",
                Name = "Travasumg",
                Description = "Phone Samsung Industries",
                Image= "product1.png",
                Price = 100M,
                Category = "Phone Mobile"

            }
        };
    }
}
