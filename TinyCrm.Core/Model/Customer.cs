using System;
using System.Collections.Generic;
using System.Text;

namespace TinyCrm.Core.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset Dob { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public List<Order> OrderList { get; set; }
        public Customer()
        {
            OrderList = new List<Order>();
            CreatedDate = DateTime.Now;
        }
    }
}
