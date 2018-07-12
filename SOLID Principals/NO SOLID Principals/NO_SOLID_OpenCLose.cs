using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principals
{
    class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class UserFeatures
    {
        public bool UserCanMakeAPayment(User user)
        {
            // Lógica para que User pueda hacer pagos.
            return true;
        }

        public bool AdminCanMakeAPayment(Admin user)
        {
            // Lógica para que sdmin pueda hacer pagos.
            return true;
        }
    }
}
