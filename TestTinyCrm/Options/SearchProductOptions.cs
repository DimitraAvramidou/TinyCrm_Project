﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestTinyCrm.Options
{
    public class SearchProductOptions
    {
        public string ProductId { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public ProductCategory? Category { get; set; }
    }
}
