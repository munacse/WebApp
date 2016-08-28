
using System.Threading.Tasks;

namespace WebApp.Core
{
    public interface IRepository<T> where T : class
    {
        T Get(long id);
        //T Save(T obj);
        void InsertOrUpdate(T obj);
        Task Delete(long id);
        //IList<T> GetAll();
    }
}
