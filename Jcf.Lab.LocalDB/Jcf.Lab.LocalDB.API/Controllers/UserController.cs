using Jcf.Lab.LocalDB.API.Data.Repositories;
using Jcf.Lab.LocalDB.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Jcf.Lab.LocalDB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRecord user)
        {
            try
            {
                var r = await _userRepository.AddAsync(new User(user.Name, user.Email, user.Password));
                if(r == null)
                {
                    return BadRequest(new { message = "Error", obj = user });
                }

                return CreatedAtAction(nameof(Get), r);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { message = ex.Message, obj = user });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _userRepository.ListAsync();
                if (!list.Any())
                {
                    return  NoContent();
                }

                return Ok(list);
            }catch(Exception ex) { return BadRequest(new { message = ex.Message }); }
        }
    }
}
