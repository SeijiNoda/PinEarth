using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImagemPinController : Controller
    {
        public IRepository Repo { get; }

        public ImagemPinController(IRepository repo)
        {
            this.Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.Repo.GetAllImagesAsync();
            return Ok(result);
        }

        [HttpGet("{ImagemID}")]
        public async Task<IActionResult> Get(int ImagemID)
        {
            try
            {
                var result = await this.Repo.GetAllImagesAsyncById(ImagemID);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(ImagemPin model)
        {
            try
            {
                this.Repo.Add(model);
                
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/ImagemPin/{model.IdImagem}", model);
                }

            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{ImagemID}")]
        public async Task<IActionResult> put(int ImagemID, ImagemPin model)
        {
            try
            {
                this.Repo.Update(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    //pegar o pin novamente, agora alterado para devolver pela rota abaixo
                    imagem = await this.Repo.GetAllImagesAsyncById(ImagemID);
                    return Created($"/ImagemPin/{model.IdImagem}", imagem);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados. Verifique se a imagem realmente existe!");
            }

            return BadRequest();
        }

        [HttpDelete("{ImagemID}")]
        public async Task<IActionResult> delete(int ImagemID)
        {
            try
            {
                //verifica se existe pin a ser excluído
                var imagem = await this.Repo.GetAllImagesAsyncById(ImagemID);
                if (imagem == null)
                    return NotFound(); //método do EF
                this.Repo.Delete(imagem);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
            return BadRequest();
        }
    }
}
