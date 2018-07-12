using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploAbstractFactory
{
    // AbstractFactory
    interface IMobilePhone
    {
        ISmartPhone GetSmartPhone();
        INormalPhone GetNormalPhone();
    }





    // AbstractProduct: ISmartPhone
    interface ISmartPhone
    {
        string GetModelDetails();
    }

    /// AbstractProduct: INormalPhone
    interface INormalPhone
    {
        string GetModelDetails();
    }
}
