using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Models
{
   public partial class Order
    {
        public decimal TotalCost
        {
            get
            {
                decimal total = 0;
                foreach (OrderProduct orderProduct in OrderProducts)
                    total += orderProduct.Count * orderProduct.Product.ProductCost;
                return total;
            }
        }
    }
}
