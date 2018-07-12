using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principals
{
    // Consiste en crear interfaces para definir comportamientos y de esta manera lo puedas desacoplar libremente.
    // para que de esta manera si en un futuro queremos agregar una funcionalidad más solo debemos crear otra interface y luego nosotros 
    // decidiremos quien lo va a implementar.
    interface IFireSpell
    {
        void FireAttack();
    }

    interface ISummonSpell
    {
        void SummonAMonster();
    }

    interface ITimeStopSpell
    {
        void TimeStop();
    }




    class FireMage : IFireSpell
    {
        public void FireAttack()
        {  }
    }

    class Summoner : ISummonSpell
    {
        public void SummonAMonster()
        { }
    }

    class GrandMage : ITimeStopSpell, IFireSpell, ISummonSpell
    {
        public void FireAttack()
        { }

        public void SummonAMonster()
        { }

        public void TimeStop()
        { }
    }
}
