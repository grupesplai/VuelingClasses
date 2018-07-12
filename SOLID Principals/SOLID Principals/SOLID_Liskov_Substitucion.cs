using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principals
{
    // Liskov Substitution dice que cada clase que hereda de otra clase puede usarse como padre sin conocer la diferencia entre ellas.
    // Para usar la clase base e instanciar las otras clases sin que nuestro código sea afectado.
    class SOLID_Liskov_Substitucion
    {
        public static void Main(string[] args)
        {
            Robot robot1 = new Robot2017();
            Console.WriteLine(robot1.Attack().ToString());// valor devuelto: 150

            Robot robot2 = new Robot2018();
            Console.WriteLine(robot2.Attack().ToString()); // valor devuelto: 175
        }
    }
    abstract class Robot
    {
        public virtual int Attack()
        {
            return 100; //valor inicial de la clase abstracta
        }
    }
    class Robot2017 : Robot
    {
        public override int Attack()
        {
            return 150; // valor sobrescrito
        }
    }

    class Robot2018 : Robot
    {
        public override int Attack()
        {
            return 175; // valor sobrescrito
        }
    }
}
