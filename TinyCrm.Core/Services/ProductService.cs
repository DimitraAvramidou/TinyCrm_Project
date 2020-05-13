using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTinyCrm.Options;
using TestTinyCrm.UpdateOptions;
using TinyCrm.Core.Model;
using TinyCrm.Core.Data;

namespace TinyCrm.Core.Services
{
    public class ProductService: IProductService
    {
        private TinyCrmDbContext context_;
        public ProductService(TinyCrmDbContext context)
        {
            context_ = context;
        }
        public Product CreateProduct(CreateProductOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var checkForExistingProduct = context_
                .Set<Product>()
                .Where(p => p.ProductId == options.ProductId)
                .SingleOrDefault();
            if(checkForExistingProduct!=null)
            {
                throw new Exception("The product exists");
            }
            var product = new Product()
            {
                ProductId = options.ProductId,
                Name = options.Name,
                Description=options.Description,
                Price=options.Price,
                Category= options.Category 
            };
            context_.Add(product);
            context_.SaveChanges();
            return product;
        }

        public IQueryable<Product> SearchProducts(SearchProductOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var query = context_.Set<Product>().AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(options.ProductId))
            {                  
                query = query.Where(c => c.ProductId.Equals(options.ProductId));                 
            }
            if (options.PriceFrom != null)
            {
                query = query.Where(c => c.Price >= options.PriceFrom);
            }
            if (options.PriceTo != null)
            {
                query = query.Where(c => c.Price <= options.PriceTo);
            }
            if (options.Category != null)
            {
                query = query.Where(x => x.Category == options.Category);
            }

            return query;
        }

        public Product UpdateProduct(UpdateProductOptions options)
        {
            if(options==null)
            {
                return null;
            }
            var product = context_.Set<Product>()
                                  .Where(pr => pr.ProductId == options.ProductId)
                                  .SingleOrDefault();
            if (product == null)
            {
                return null;
            }

            if (options.Name != null)
            {
                product.Name = options.Name;
            }
            if (options.Description != null)
            {
                product.Description = options.Description;
            }
            if (options.Price != null)
            {
                product.Price = (decimal)options.Price;
            }
            if (options.Category != null)
            {
                product.Category =(ProductCategory) options.Category;
            }
            context_.SaveChanges();
            return product;

        }

        public Product GetProductById(string productId)
        {
            var productExists = context_.Set<Product>()
                                       .Where(p => p.ProductId == productId)
                                       .SingleOrDefault();
            if (productExists==null)
            {
                return null;
            }
            return productExists;
        }
    }
}
