﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario
{
    public class HondaAutoService : IAutoService
    {
        public void getService()
        {
            Console.WriteLine("You chose Honda auto service");
        }
    }
}
