using System;
using System.Collections.Generic;
using System.Text;

namespace TestTinyCrm.UpdateOptions
{
    public class UpdateCustomerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsActive { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string Phone { get; set; }
        public List<Order> OrderList { get; set; }
        public int? CustomerId { get; set; }

        public UpdateCustomerOptions()
        {
            OrderList = new List<Order>();
        }
    }
}
