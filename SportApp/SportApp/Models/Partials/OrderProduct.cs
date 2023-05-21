using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp.Models
{
    public partial class OrderProduct
    {
        public double Total
        {
            get
            {
                return Count * Product.GetPriceWithDiscount;
            }
        }
    }
}
