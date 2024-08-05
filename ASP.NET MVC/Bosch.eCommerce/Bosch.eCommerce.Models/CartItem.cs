using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosch.eCommerce.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; } = 1;
        public int Size { get; set; } = 7;
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
