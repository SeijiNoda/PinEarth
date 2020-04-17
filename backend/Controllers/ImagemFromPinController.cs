using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Http;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImagemFromPinController : Controller
    {
        public IRepository Repo { get; }

        public ImagemFromPinController(IRepository repo)
        {
            this.Repo = repo;
        }

        [HttpGet("{PinID}")]
        public async Task<IActionResult> Get(int PinID)
        {
            try
            {
                var result = await this.Repo.GetAllImagesAsyncByIdPin(PinID);
                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no acesso ao banco de dados.");
            }
        }
    }
}