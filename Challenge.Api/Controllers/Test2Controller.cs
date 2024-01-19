using ChallengeApi.Authentication;
using ChallengeApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace ChallengeApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class Test2Controller : ControllerBase
    {

        private readonly IPersonService _personService;

        public Test2Controller(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet(nameof(PublicAction))]
        [SwaggerOperation("دسترسی با کاربر عادی")]
        public async Task<IActionResult> PublicAction() 
        {
            return Ok(); 
        }

        [HttpGet(nameof(PrivateAction))]
        [Authorize(Roles =UserRoles.Admin_Role)]
        [SwaggerOperation("دسترسی با کاربر ادمین")]
        public async Task<IActionResult> PrivateAction()
        {
            return Ok();
        }

        [HttpGet(nameof(GetAllPerson))]
        [AllowAnonymous]        
        public async Task<IActionResult> GetAllPerson()
        {
            return Ok(_personService.GetAll());   // Linq
            //return Ok(_personService.GetAllLambda());  // Lambda
            //return Ok(_personService.GetAllSQL());   // SQL 
        }
    }
}
