using Microsoft.AspNetCore.Mvc;
using Subscriber.CORE.DTO;
using Subscriber.CORE.Interface_Service;
using Subscriber.CORE.Response;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Subscriber.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Weight_WatchersController : ControllerBase
    {
        Weight_WatchersService _Weight_WatchersService;
        public Weight_WatchersController(Weight_WatchersService Weight_WatchersService)
        {
            _Weight_WatchersService = Weight_WatchersService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseGeneric<CardResponse>>> GetCardById(int id)
        {
            var response = await _Weight_WatchersService.GetCardDetails(id);
            if (response.Succeed == false)
                return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<BaseResponseGeneric<int>>> Login([FromBody] string email, string password)
        {
            var response = await _Weight_WatchersService.Login(email, password);
            if (response.Succeed)
                return Ok(response);
            return BadRequest(response);

        }
        [HttpPost]
        public async Task<ActionResult<BaseResponseGeneric<bool>>> Register([FromBody] SubscribersDTO SubscribersDTO)
        {
            var response = await _Weight_WatchersService.Register(SubscribersDTO);
            if (response.Succeed)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
