using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
    public interface IRepository
    {
        // Métodos genéricos
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Métodos GET, que não são genéricos, pois possuem algo específico, no caso, Pin!
        Task<Pin[]> GetAllPinsAsync();
        Task<Pin> GetAllPinsAsyncById(int ID);

        Task<ImagemPin[]> GetAllImagesAsync();
        Task<ImagemPin> GetAllImagesAsyncById(int ID);

        Task<ImagemPin[]> GetAllImagesAsyncByIdPin(int ID);

        Task<Avaliacao[]> GetAllAvaliacoesAsync();
        Task<Avaliacao> GetAllAvaliacoesAsyncById(int ID);
    }
}