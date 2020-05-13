using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using TestTinyCrm.Options;
using System.Diagnostics.Tracing;
using TestTinyCrm.UpdateOptions;

namespace TestTinyCrm
{
    public class Program
    {
        static void Main(string[] args)
        {


            //using var contextDb = new TinyCrmDbContext() ;

            //    List<string> ProductListFromFile = new List<string>();
            //    List<string> IdCodes = new List<string>();
            //    List<Product> list = new List<Product>();
            //    var rand = new Random();

            //    foreach (var Line in File.ReadLines("products.csv"))
            //    {
            //        string[] value;
            //        var count = IdCodes.Count;
            //        ProductListFromFile.Add(Line);

            //        value = Line.Split(';');
            //        var ProductCode = value[0];

            //        var IsDublicate = IdCodes.SingleOrDefault(prod => prod.Equals(ProductCode));
            //        if (IsDublicate != null)
            //        {
            //            continue;
            //        }

            //        IdCodes.Add(ProductCode);

            //        list.Add(new Product());
            //        list[count].ProductId = value[0];
            //        //Console.WriteLine(list[count].ProductId);
            //        list[count].Name = value[1];
            //        list[count].Description = value[2];
            //        var item = new decimal(rand.NextDouble() * 100);
            //        list[count].Price = Math.Round(item, 2);

            //       // contextDb.Set<Product>().Add(list[count]);
            //       // contextDb.SaveChanges();
            //    }


            
            using (var context = new TinyCrmDbContext())
            {
                ICustomerService customerService = new CustomerService(
                    context);
                IProductService productService = new ProductService(context);
                IOrderService orderService = new OrderService(context, customerService, productService);

                var results = customerService.SearchCustomers(
                    new SearchCustomerOptions()
                    {
                       CustomerId = 2
                    }).SingleOrDefault();
                Console.WriteLine($"The customer is:{results.FirstName} {results.LastName}");
                //----------------------------Create a Customer--------------------------------------
                //customerService.CreateCustomer(new CreateCustomerOptions()
                //{
                //    FirstName = "Dimitra",
                //    LastName = "Avramidou",
                //    Email = "avramidou@mail.com",
                //    VatNumber = "123456789"
                //});
                //-----------------------------------------------------------------------------------

                //----------------------------Create a Product--------------------------------------
                //IProductService productService = new ProductService(
                //    context);
                //productService.CreateProduct(new CreateProductOptions()
                //{
                //    ProductId = "PR1",
                //    Name = "iPhone 10",
                //    Description = "white color",
                //    Price = 1000M,
                //    Category = ProductCategory.Mobiles
                //});
                //-----------------------------------------------------------------------------------


                var result =productService.SearchProducts(
                    new SearchProductOptions()
                    {
                        ProductId = "PR7"
                    }).SingleOrDefault();

                    Console.WriteLine($"The product is:{result.ProductId} {result.Name}");

                //------------Create an Order---------------------------------------------------
                //var orderOptions = new CreateOrderOptions();
                //orderOptions.CustomerId = 2;
                //orderOptions.ProductIds.Add("PR1");
                //orderOptions.ProductIds.Add("PR7");
                //orderOptions.DeliveryAddress="Ermou 5";
                //orderService.CreateOrder(orderOptions);
                //-------------------------------------------------------------------------------

                //-------------------Customer Update----------------------------------------------
                //var cust= customerService.UpdateCustomer(new UpdateCustomerOptions()
                // {
                //     CustomerId = 2,
                //     Email = "dimav95@hotmail.com",
                //     Phone="6987249839",
                //     VatNumber="123454321"
                // });
                // Console.WriteLine($"Customer update:{cust.FirstName} {cust.LastName} {cust.Email}");
                //-------------------------------------------------------------------------------

                //--------------------------------Get Customer by ID-----------------------------------------------------
                //var customer = customerService.GetCustomerById(2);
                //Console.WriteLine($"The customer with the id that you asked is: {customer.FirstName} {customer.LastName}");
                //-------------------------------------------------------------------------------------------------------

                //------------------------Search Order ------------------------------------------
                //var order_result =orderService.SearchOrder(new SearchOrderOptions()
                //{
                //    PriceFrom = 100
                //}).SingleOrDefault();
                //if(order_result==null)
                //{
                //    Console.WriteLine("There is not such an order");
                //}
                //else
                //{
                //    Console.WriteLine($"The order id is : {order_result.OrderId}");
                //}
                //-------------------------------------------------------------------------------------------------------

                //----------------------------------------------Update Product ------------------------------------------
                //productService.UpdateProduct(new UpdateProductOptions()
                //{
                //    ProductId = "PR1",
                //    Price = 1500M
                //});
                //-------------------------------------------------------------------------------------------------------

                //----------------------------------------------Update Order ------------------------------------------
                //var upOptions = new UpdateOrderOptions();
                //upOptions.OrderId = 1;
                //upOptions.ProductIds.Add("PR1");
                //orderService.UpdateOrder(upOptions);
                //-------------------------------------------------------------------------------------------------------
            }
        }

    }
}
