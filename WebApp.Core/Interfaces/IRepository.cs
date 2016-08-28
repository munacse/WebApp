
using System.Collections.Generic;

namespace WebApp.Core
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        T Save(T obj);
        void Update(T obj);
        void Delete(int id);
        //IList<T> GetAll();
    }
}
