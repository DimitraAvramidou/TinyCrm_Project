using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using TestTinyCrm.Options;
using TestTinyCrm.UpdateOptions;

namespace TestTinyCrm
{
    public class OrderService :IOrderService
    {
        private TinyCrmDbContext context_;
        private ICustomerService CustomerService;
        private IProductService ProductService;


        public OrderService(TinyCrmDbContext context,ICustomerService cServise, IProductService pService)
        {
            context_ = context;
            CustomerService = cServise;
            ProductService = pService;


        }
        public Order CreateOrder(CreateOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var customer = CustomerService.SearchCustomers(new SearchCustomerOptions()
            {
                CustomerId = options.CustomerId
            }).SingleOrDefault();
            if (customer == null)
            {
                return null;
            }
            var order = new Order()
            {
                DeliveryAddress = options.DeliveryAddress
            };
            foreach(var p in options.ProductIds)
            {
                var product = ProductService.SearchProducts(new SearchProductOptions()
                {
                    ProductId = p
                }).SingleOrDefault();
                Console.WriteLine($"To product pu zitithine einai:{product.Name}");
                if (product!=null)
                {
                    var orderProduct = new OrderProduct()
                    {
                        Product = product
                    };
                    order.OrderProducts.Add(orderProduct);
                    order.TotalAmount = order.TotalAmount + product.Price;
                }
                else
                {
                    return null;
                }
            }
            customer.OrderList.Add(order);
            context_.Update(customer);
            context_.SaveChanges();
            return order;          
        }

        public IQueryable<Order> SearchOrder(SearchOrderOptions options)
        {
            if(options==null)
            {
                return null;
            }
            var query = context_.Set<Order>().AsQueryable();
            if(options.OrderId!=null)
            {
                query = query.Where(o => o.OrderId == options.OrderId);
            }
            if(options.PriceFrom!=null)
            {
                query = query.Where(o => o.TotalAmount >= options.PriceFrom);
            }
            if(options.PriceTo!=null)
            {
                query = query.Where(o => o.TotalAmount <= options.PriceTo);
            }
            if(options.DeliveryAddress!=null)
            {
                query = query.Where(o => o.DeliveryAddress == options.DeliveryAddress);
            }
            return query;
        }

        public Order UpdateOrder(UpdateOrderOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var OrderExists = context_.Set<Order>()
                                      .Where(o => o.OrderId == options.OrderId)
                                      .Include(o => o.OrderProducts)
                                      .SingleOrDefault();
            if (OrderExists == null)
            {
                return null;
            }
            if(options.DeliveryAddress!=null)
            {
                OrderExists.DeliveryAddress = options.DeliveryAddress;
            }
            OrderExists.OrderProducts.Clear();
            OrderExists.TotalAmount = 0M;

            foreach (var pr in options.ProductIds)
            {
                var product = ProductService.GetProductById(pr);

                if (pr == null)
                {
                    return null;
                }
                OrderExists.OrderProducts.Add(new OrderProduct()
                {
                    Product = product,
                });

                OrderExists.TotalAmount = OrderExists.TotalAmount+ product.Price;
                
            }
            context_.SaveChanges();
            return OrderExists;
        }
    }
}
