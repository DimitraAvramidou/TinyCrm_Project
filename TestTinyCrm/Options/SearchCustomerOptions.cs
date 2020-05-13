using System;
using System.Collections.Generic;
using System.Text;

namespace TestTinyCrm.Options
{
    public class SearchCustomerOptions
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VatNumber { get; set; }
        public DateTimeOffset? CreateFrom { get; set; }
        public DateTimeOffset? CreateTo { get; set; }
        public int? CustomerId { get; set; }

    }
}
