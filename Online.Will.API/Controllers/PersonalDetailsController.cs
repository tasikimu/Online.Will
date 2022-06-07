using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online.Will.API.Data;
using Online.Will.API.Models;

namespace Online.Will.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonalDetailsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddUser(PersonalDetails personalDetail)
        {
            /*Adding Personal Details to DB*/

            _context.PersonalDetails.Add(personalDetail);
            await _context.SaveChangesAsync();

            return Ok("You have been successfully registered");
        }
    }
}