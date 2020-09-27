using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokoMobile.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> cartLines = new List<CartLine>();
        public void AddToCart(Product product, int quantity)
        {
            CartLine cartLine = cartLines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (cartLine == null)
            {
                cartLines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += 1;
            }
        }

        public void RemoveCartLine(Product product)
        {
            cartLines.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public double TotalValue()
        {
            return cartLines.Sum(s => s.Product.Price * s.Quantity);
        }

        public void ClearCart()
        {
            cartLines.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return cartLines; }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

