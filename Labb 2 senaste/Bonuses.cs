using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_senaste
{
    internal class Bonuses : customers 
    {

        public enum Discounts
        {
            Gold,
            Silver,
            Bronze
        }

        private Discounts _membershipLevels { get; set; }
        public string Membershiplevel { get; }
        
        public Discounts Membershiplevels { get {  return _membershipLevels; } set { _membershipLevels = value; } }

        public Bonuses(string Username, string Password, Discounts membershiplevels): base(Username, Password) 
        {
            Membershiplevels = membershiplevels;
            this.Username = Username;
            this.Password = Password;
            this.ShoppingCart = new ShoppingCart();
        }

        public Bonuses(string username, string password, string membershiplevel) : base(username, password)
        {
            Membershiplevel = membershiplevel;
            this.Username = username;
            this.Password = password;
            this.ShoppingCart = new ShoppingCart();
        }

        public override string ToString()
        {
           return $"{Username}\n{Password}\n{Membershiplevels}\n*******************";
        }

        public decimal DiscountGiven(decimal price)
        {
            decimal discount = 1.0m;

            switch (Membershiplevels)
            {
                case Discounts.Gold:
                    discount = 0.85m;
                    break;
                case Discounts.Silver:
                    discount = 0.90m;
                    break;
                case Discounts.Bronze:
                    discount = 0.95m;
                    break;

            }
            return discount * price;
        }

     



    }
}
