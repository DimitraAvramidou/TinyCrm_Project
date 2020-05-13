using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestTinyCrm.Options;
using TestTinyCrm.UpdateOptions;
using System.Dynamic;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services
{
    public interface IProductService
    {
        public Product CreateProduct(CreateProductOptions options);
        public IQueryable<Product> SearchProducts(SearchProductOptions options);
        public Product UpdateProduct(UpdateProductOptions options);
        public Product GetProductById(string productId);

    }
}
