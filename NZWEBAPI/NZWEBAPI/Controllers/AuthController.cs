using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWEBAPI.Repositories;

namespace NZWEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository,ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Models.DTO.UserRequest userRequest)
        {
           

            var userObjDTO=  await  userRepository.AuthenticateAsync(userRequest.UserName, userRequest.Password);
            if(userObjDTO!=null)
            {
               var token= await  tokenHandler.CreateTokenAsync(userObjDTO);
                return Ok(token);
            }
            return BadRequest("User name and Password not valid");
        }
    }
}
