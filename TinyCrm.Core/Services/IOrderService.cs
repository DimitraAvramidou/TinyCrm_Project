using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTinyCrm.Options;
using TestTinyCrm.UpdateOptions;
using TinyCrm.Core.Data;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderOptions options);
        IQueryable<Order> SearchOrder(SearchOrderOptions options);
        Order UpdateOrder(UpdateOrderOptions options);
        
    }
}
