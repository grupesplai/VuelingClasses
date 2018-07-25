using log4net;
using System;

namespace Log4netWithInyeccinDependencias
{
    public class CalculadoraController
    {
        private readonly log4net.ILog _logger;
        public CalculadoraController(ILog logger)
        {
            _logger = logger;
        }

        public int Divide(int num1 , int num2)
        {
            int total = 0;
            try
            {
                _logger.Debug("Intentando dividir");
                total = num1 / num2;
                return total;
            }
            catch (DivideByZeroException)
            {
                _logger.Error("Error al dividir. " + num1 + " / " + num2 + ". ");
                throw new DivideByZeroException("No se puede dividir"); // this is what it'll return in instanciation line
            }
            
        }
    }
}
