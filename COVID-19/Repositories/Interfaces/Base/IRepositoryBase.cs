using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid19.Repositories.Interfaces.Base
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T ent);
        void Delete(int id);
        T Update(T ent);
        IEnumerable<T> BuscarTodos();
        T BuscarPacienteUnico(int id);
    }
}
