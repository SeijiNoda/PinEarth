using System.Threading.Tasks;

namespace backend.Data
{
    public interface IRepository
    {
         // Métodos genéricos
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveChangesAsync();
    }
}