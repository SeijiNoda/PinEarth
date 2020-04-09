using System.Threading.Tasks;

namespace backend.Data
{
    public class Repository : IRepository
    {
        public MundoContext Context { get; }
        public Repository(MundoContext context)
        {
            this.Context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            //throw new System.NotImplementedException();
            this.Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            //throw new System.NotImplementedException();
            this.Context.Remove(entity);
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}