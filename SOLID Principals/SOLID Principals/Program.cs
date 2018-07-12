using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principals
{
    class Program
    {
        static void Main(string[] args)
        {
            Program user = new Program();
            string userMoney = user.PayMyDebts(150);
            Console.WriteLine("Info about user in his/her bank: "+ userMoney):
        }
        public string PayMyDebts(int money)
        {
            if (HasMoneyAtBank(money))
            {
                return "User has money in his/her bank.";
            }
            else
            {
                return "User has NO money in his/her bank.";
            }
        }

        public bool HasMoneyAtBank(int money)
        {
            if (money >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
