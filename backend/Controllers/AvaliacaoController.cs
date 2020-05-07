using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AvaliacaoController : Controller
    {
        public IRepository Repo { get; }
        public AvaliacaoController(IRepository repo)
        {
            this.Repo = repo;
            //construtor
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.Repo.GetAllAvaliacoesAsync();
            return Ok(result);
        }

        [HttpGet("{AvaliacaoID}")]
        public async Task<IActionResult> Get(int AvaliacaoID)
        {
            try
            {
                var result = await this.Repo.GetAllAvaliacoesAsyncById(AvaliacaoID);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Avaliacao model)
        {
            try
            {
                this.Repo.Add(model);
                
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/Avaliacao/{model.idAvaliacao}", model);
                }

            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{AvaliacaoID}")]
        public async Task<IActionResult> put(int AvaliacaoID, Avaliacao model)
        {
            try
            {
                this.Repo.Update(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    //pegar a avaliacao novamente, agora alterada para devolver pela rota abaixo
                    var avaliacao = await this.Repo.GetAllAvaliacoesAsyncById(AvaliacaoID);
                    return Created($"/Avaliacao/{model.idAvaliacao}", avaliacao);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados. Verifique se o Avaliacao realmente existe!");
            }

            return BadRequest();
        }

        [HttpDelete("{AvaliacaoID}")]
        public async Task<IActionResult> delete(int AvaliacaoID)
        {
            try
            {
                //verifica se existe avaliacao a ser excluída
                var avaliacao = await this.Repo.GetAllAvaliacoesAsyncById(AvaliacaoID);
                if (avaliacao == null)
                    return NotFound(); //método do EF
                this.Repo.Delete(avaliacao);
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