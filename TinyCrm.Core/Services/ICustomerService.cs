using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTinyCrm.Options;
using TestTinyCrm.UpdateOptions;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Services
{
    public interface ICustomerService
    {
        public IQueryable<Customer> SearchCustomers(SearchCustomerOptions options);
        public Customer CreateCustomer(CreateCustomerOptions options);
        public Customer UpdateCustomer(UpdateCustomerOptions options);
        public Customer GetCustomerById(int id);
    }
}
