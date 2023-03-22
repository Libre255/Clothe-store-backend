using backend.Models;
using backend.Services.ClotheService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClothesAPIController : Controller
    {
        private readonly IClotheService _clothesDB;
        public ClothesAPIController(IClotheService clothesDB)
        {
            _clothesDB = clothesDB;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAllClothes")]
        public async Task<ActionResult<ServiceResponse<List<Clothe>>>> GetAllClothes()
        {
            return Ok(await _clothesDB.GetAllClothes());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<Clothe>>> GetClotheById(int id)
        {
            var response = await _clothesDB.GetClotheById(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("AddClothe")]
        public async Task<ActionResult<ServiceResponse<List<Clothe>>>> AddClothe(Clothe IncomingClothe)
        {
            return Ok(await _clothesDB.AddClothe(IncomingClothe));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Clothe>>>> DeletClothe (int id) {
            var response = await _clothesDB.DeleteClotheById(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
