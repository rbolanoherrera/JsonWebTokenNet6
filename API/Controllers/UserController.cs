using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Usuario> list = new List<Usuario>();
            
            list.Add(new Usuario() {  Username= "rafls", Email= "ralfs1@hotmail.com" });
            list.Add(new Usuario() {  Username= "Andrea", Email= "acarobola@hotmail.com" });
            list.Add(new Usuario() {  Username= "Vanessa", Email= "vanessatohu@hotmail.com" });

            return Ok(list);
        }
    }
}
