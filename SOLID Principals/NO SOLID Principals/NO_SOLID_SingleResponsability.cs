using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NO_SOLID_Principals
{
    class NO_SOLID_SingleResponsability
    {
        static void Main(string[] args)
        {
            NO_SOLID_SingleResponsability user = new NO_SOLID_SingleResponsability();
            string userMoney = user.PayMyDebts(150);
            Console.WriteLine("Info about user in his/her bank: " + userMoney);
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
            if (money > 0)
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
