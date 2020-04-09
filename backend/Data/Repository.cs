using System.Threading.Tasks;
using backend.Models;
using backend.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> SaveChangesAsync()
        {
            // Como é tipo Task vai gerar thread, então vamos definir o método como assíncrono (async)
            // Por ser assíncrono, o return deve esperar (await) se tem alguma coisa para salvar no BD
            // Ainda verifica se fez alguma alteração no BD, se for maior que 0 retorna true ou false
            return (await this.Context.SaveChangesAsync() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            //throw new System.NotImplementedException();
            this.Context.Update(entity);
        }

        public async Task<Pin[]> GetAllPinsAsync()
        {
            //throw new System.NotImplementedException();
            //Retornar para uma query qualquer do tipo Pin
            IQueryable<Pin> consultaPins = this.Context.Pin;
            consultaPins = consultaPins.OrderBy(a => a.IdPin);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaPins.ToArrayAsync();
        }

        public async Task<Pin> GetAllPinsAsyncById(int ID)
        {
            //throw new System.NotImplementedException();
            //Retornar para uma query qualquer do tipo Pin
            IQueryable<Pin> consultaPins = this.Context.Pin;
            consultaPins = consultaPins.OrderBy(a => a.IdPin).Where(pin => pin.IdPin == ID);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaPins.FirstOrDefaultAsync();
        }

        public async Task<ImagemPin[]> GetAllImagesAsync()
        {
            //throw new System.NotImplementedException();
            //Retornar para uma query qualquer do tipo Pin
            IQueryable<ImagemPin> consultaImagens = this.Context.ImagemPin;
            consultaImagens = consultaImagens.OrderBy(a => a.IdImagem);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaImagens.ToArrayAsync();
        }

        public async Task<ImagemPin> GetAllImagesAsyncById(int ID)
        {
            //throw new System.NotImplementedException();
            //Retornar para uma query qualquer do tipo Pin
            IQueryable<ImagemPin> consultaImagens = this.Context.ImagemPin;
            consultaImagens = consultaImagens.OrderBy(a => a.IdImagem).Where(ImagemPin => ImagemPin.IdImagem == ID);
            // aqui efetivamente ocorre o SELECT no BD
            return await consultaImagens.FirstOrDefaultAsync();
        }
    }
}