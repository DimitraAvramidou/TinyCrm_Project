using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using TestTinyCrm.Options;
using TestTinyCrm.UpdateOptions;

namespace TestTinyCrm
{
    public class CustomerService: ICustomerService
    {
        private TinyCrmDbContext context_;
        public CustomerService(TinyCrmDbContext context)
        {
            context_ = context;
        }

        public Customer CreateCustomer(CreateCustomerOptions options)
        {
            if (options == null)
            {
                return null;
            }
            var customer = new Customer()
            {
                FirstName = options.FirstName,
                LastName = options.LastName,
                Email = options.Email,
                VatNumber=options.VatNumber
            };
            context_.Add(customer);
            context_.SaveChanges();
            return customer;
        }

        public IQueryable<Customer> SearchCustomers(SearchCustomerOptions options)
        {
            var query = context_.Set<Customer>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(options.FirstName))
            {
                query = query.Where(c => c.FirstName.Equals(options.FirstName));
            }
            if (!string.IsNullOrWhiteSpace(options.LastName))
            {
                query = query.Where(c => c.LastName.Equals(options.LastName));
            }
            if (options.CustomerId != null)
            {
                query = query.Where(c => c.CustomerId.Equals(options.CustomerId));
            }
            if (options.CreateFrom != null)
            {
                query = query.Where(c => c.CreatedDate >= options.CreateFrom);
            }
            if (options.CreateTo != null)
            {
                query = query.Where(c => c.CreatedDate <= options.CreateTo);
            }
            if (!string.IsNullOrWhiteSpace(options.VatNumber))
            {
                query = query.Where(c => c.VatNumber.Equals(options.VatNumber));
            }

            return query.Take(500);
        }

        public Customer UpdateCustomer(UpdateCustomerOptions options)
        {
            if(options==null)
            {
                return null;
            }
            var customer = context_.Set<Customer>().Where(c=>c.CustomerId ==options.CustomerId).SingleOrDefault();

            if(options.FirstName!=null)
            {
                customer.FirstName = options.FirstName;
            }
            if(options.Email!=null)
            {
                customer.Email = options.Email;
                Console.WriteLine("mpika edo");
            }
            if(options.VatNumber!=null)
            {
                customer.VatNumber = options.VatNumber;
            }
            if(options.LastName!=null)
            {
                customer.LastName = options.LastName;
            }
            if(options.Phone!=null)
            {
                customer.Phone =options.Phone;
            }
            if (options.Address != null)
            {
                customer.Address = options.Address;
            }
            if (options.IsActive != null)
            {
                customer.IsActive =(Boolean) options.IsActive;
            }
            context_.SaveChanges();
            return (customer);
        }

        public Customer GetCustomerById(int id)
        {
            var customerWithThisId = context_.Set<Customer>().Where(cust => cust.CustomerId == id).SingleOrDefault();
            if(customerWithThisId!=null)
            {
                return customerWithThisId;
            }
            else
            {
                return null;
            }
        }
    }
}
