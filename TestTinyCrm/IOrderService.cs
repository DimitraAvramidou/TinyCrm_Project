using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTinyCrm.Options;
using TestTinyCrm.UpdateOptions;

namespace TestTinyCrm
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderOptions options);
        IQueryable<Order> SearchOrder(SearchOrderOptions options);
        Order UpdateOrder(UpdateOrderOptions options);
        
    }
}
