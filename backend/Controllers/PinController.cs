using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinController : Controller
    {
        public IRepository Repo { get; }
        public PinController(IRepository repo)
        {
            this.Repo = repo;
            //construtor
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.Repo.GetAllPinsAsync();
            return Ok(result);
        }

        [HttpGet("{PinID}")]
        public async Task<IActionResult> Get(int PinID)
        {
            try
            {
                var result = await this.Repo.GetAllPinsAsyncById(PinID);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Pin model)
        {
            try
            {
                this.Repo.Add(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    return Created($"/api/pin/{model.idPin}", model);
                }

            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpPut("{PinID}")]
        public async Task<IActionResult> put(int PinID, Pin model)
        {
            try
            {
                //verifica se existe pin a ser alterado
                var pin = await this.Repo.GetAllPinsAsyncById(PinID);
                if (pin == null)
                    return NotFound(); //método do EF
                this.Repo.Update(model);
                //
                if (await this.Repo.SaveChangesAsync())
                {
                    //return Ok();
                    //pegar o pin novamente, agora alterado para devolver pela rota abaixo
                    pin = await this.Repo.GetAllPinsAsyncById(PinID);
                    return Created($"/api/pin/{model.idPin}", pin);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }

            return BadRequest();
        }

        [HttpDelete("{PinID}")]
        public async Task<IActionResult> delete(int PinID)
        {
            try
            {
                //verifica se existe pin a ser excluído
                var pin = await this.Repo.GetAllPinsAsyncById(PinID);
                if (pin == null)
                    return NotFound(); //método do EF
                this.Repo.Delete(pin);
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