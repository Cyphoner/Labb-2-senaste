using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_senaste
{

    internal class customers
    {
        private string _username;
        private string _password;
        private ShoppingCart _shoppingcart;

        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } }

        public ShoppingCart ShoppingCart { get { return _shoppingcart; } set { _shoppingcart = value; } }

        public customers(string username, string password)
        {
            Username = _username;
            Password = _password;
            ShoppingCart = new ShoppingCart();
        }

        internal decimal DiscountGiven(decimal totalPrice)
        {
            throw new NotImplementedException();
        }
    }
}
