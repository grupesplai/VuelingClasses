using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Aplication.Services.Contrats
{
    public interface IService<T>
    {
        T Add(T model);
        T Update(T model);
        List<T> GetAll();
        T GetById(int id);
        int Delete(int id);
    }
}
