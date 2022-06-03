using HotelListing.API.Contracts;
using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManager authManager;

        public AccountController(IAuthManager authManager)
        {
            this.authManager = authManager;
        }

        //POST:  api/Account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register ([FromBody]ApiUserDto apiUserDto)
        {
            var errors = await authManager.Register(apiUserDto);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);

                }

                return BadRequest(ModelState);
            }

            return Ok();
        }


        //POST:  api/Account/register
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var authResponse = await authManager.login(loginDto);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }



        //POST:  api/Account/refreshtoken
        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto authResponseDto)
        {
            var authResponse = await authManager.VerifyRefreshToken(authResponseDto);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }

    }
}
