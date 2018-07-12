using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principals
{
    //Consiste en crear interfaces para definir comportamientos y de esta manera lo puedas desacoplar libremente.

    interface SpecialPower
    {
        void FireAttack();
        void SummonAMonster();
        void TimeStop();
    }

    class FireMage : SpecialPower
    {
        public void FireAttack()
        { }

        public void SummonAMonster()
        {
            throw new Exception("Can't use this");
        }

        public void TimeStop()
        {
            throw new Exception("Can't use this");
        }
    }

    class Summoner : SpecialPower
    {
        public void FireAttack()
        {
            throw new Exception("Can't use this");
        }

        public void SummonAMonster()
        {

        }

        public void TimeStop()
        {
            throw new Exception("Can't use this");
        }
    }

    class GrandMage : SpecialPower
    {
        public void FireAttack()
        {

        }

        public void SummonAMonster()
        {

        }

        public void TimeStop()
        {

        }
    }
}
