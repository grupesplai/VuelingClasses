using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principals
{
    // Inyecion de dependencias dice que para evitar trabajar con las instancias dentro de nuestro código.
    // Debemos trabajar con una interfaz de esta manera no nos interesa quien es el proveedor solo nos i/nteresa que el comportamiento sea el mismo.
    // Esto es caso de modificar por ejemplo el nombre de algun método.
    interface IEmailProvider
    {
        void Send();
    }

    class Mailchimp : IEmailProvider
    {
        public void Send()
        {

        }
    }

    class Sendgrid : IEmailProvider
    {
        public void Send()
        {

        }
    }

    class EmailService
    {
        private readonly IEmailProvider _emailProvider;

        public EmailService(
            IEmailProvider emailProvider
        )
        {
            _emailProvider = emailProvider;
        }

        public void Send()
        {
            _emailProvider.Send();
        }
    }
}
