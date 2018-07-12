using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NO_SOLID_Principals
{
    // Fijese que existen dos métodos que hacen lo mismo.
    class Mailchimp
    {
        public void Send()
        {

        }
    }

    class Sendgrid
    {
        public void Send()
        {

        }
    }

    class EmailService
    {
        public void SendAnEmailUsingSendGrid(Sendgrid mailProvider)
        {
            mailProvider.Send();
        }

        public void SendAnEmailUsingMailchimp(Mailchimp mailProvider)
        {
            mailProvider.Send();
        }
    }
}
