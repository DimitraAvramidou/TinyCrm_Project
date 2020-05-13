using System;
using System.Collections.Generic;
using System.Text;

namespace TestTinyCrm.UpdateOptions
{
    public class UpdateOrderOptions
    {
        public int? OrderId { get; set; }
        public List<string> ProductIds { get; set; }
        public string DeliveryAddress { get; set; }

        public UpdateOrderOptions()
        {
            ProductIds = new List<string>();
        }
    }
}
