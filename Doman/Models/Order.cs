﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doman.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }

        public Member Member { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
