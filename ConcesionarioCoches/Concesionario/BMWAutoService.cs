﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario
{
    public class BMWAutoService : IAutoService
    {
        public void getService()
        {
            Console.WriteLine("You chose BMW auto service");
        }
    }
}
