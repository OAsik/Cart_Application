using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cart_Administration.Models
{
    public class CartModel
    {
        private Dictionary<int, ProductModel> _cart = new Dictionary<int, ProductModel>();

        public List<ProductModel> ProductList
        {
            get
            {
                return _cart.Values.ToList();
            }
        }

        public void AddCart(ProductModel obj)
        {
            if (!_cart.ContainsKey(obj.ID))
            {
                _cart.Add(obj.ID, obj);
            }
            else
            {
                _cart[obj.ID].Quantity++;
            }
        }

        public void IncreaseCart(int id)
        {
            _cart[id].Quantity++;
        }

        public void DecreaseCart(int id)
        {
            _cart[id].Quantity--;

            if (_cart[id].Quantity <= 0)
            {
                _cart.Remove(id);
            }
        }

        public void RemoveCart(int id)
        {
            _cart.Remove(id);
        }
    }
}