using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReposiroryPattern_Example
{
    public class TesstAlmacenRepository : IAlmacenRepository
    {
        private readonly List<Almacen> _data = new List<Almacen>();
        public void Delete(string id) => _data.Remove(_data.Find(m => m.IdAlmacen = id));
        public void Insert(IAlmacenRepository almacen) => _data.Add(almacen);

        public void save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Almacen> SelectAll() => _data;

        public IAlmacenRepository SelectById(string id) => _data.Find(m => m.IdAlmacen == id);
        
        public void Update(IAlmacenRepository almacen) => _data.Find(m => m.IdAlmacen == almacen);
    }
}
