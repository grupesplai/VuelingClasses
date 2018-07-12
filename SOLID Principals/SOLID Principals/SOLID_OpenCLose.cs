using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principals
{
    // Este principio dice que una clase u objeto debe estar disponible para su extensión pero no para su modificación.
    // Open Close significa abierto para la extensión pero cerrado para la modificación.
    abstract class BaseUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Admin : BaseUser { }

    class User : BaseUser { }

    class UserFeatures
    {
        public bool CanMakeAPayment(BaseUser user)
        {
            // Lógica para que user y admin puedan hacer pagos.
            return true;
        }
    }
}
