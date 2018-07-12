using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principals
{
    // Cada módulo de la aplicación tiene que tener una sola responsabilidad, por lo tanto no debería ser mutli tarea. 
    // Permite separar responsabilidades y escalar al departamento correspondiente(em este caso BankService).
    class SOLID_SingleResponsability
    {
        class UserService
        {
            private readonly BankService _bankService;

            public UserService(BankService bankService)
            {
                _bankService = bankService;
            }

            public bool PayMyDebts(string userID)
            {
                var success = false;
                if (_bankService.HasMoneyAtBank(userID))
                {
                    success = true;
                }

                return success;
            }
        }

        class BankService
        {
            public bool HasMoneyAtBank(string userId)
            {
                return true;
            }
        }
    }
}
