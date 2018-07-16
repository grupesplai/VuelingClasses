using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposiroryPattern_Example
{
    public interface IAlmacenRepository
    {
        //declaracion intefaz repositorio con todas las acciones para el Agregrado producto los repositorios
        //Declaracion del metodo para extraer todos los registros
        IEnumerable<Almacen> SelectAll();
        IAlmacenRepository SelectById(string id);
        void Insert(IAlmacenRepository almacen);
        void Update(IAlmacenRepository almacen);
        void Delete(string id);
        void save();
    }
}
