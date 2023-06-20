using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAGPDemoWebAPI.Models;

namespace NAGPDemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NAGPDemoUserController : ControllerBase
    {
        private readonly DemoUserDbContext _userDbContext;

        public NAGPDemoUserController(DemoUserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NAGPDemoUser>> GetDemoUsers()
        {
            return _userDbContext.DemoUsers;
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> DeleteUser(int Id)
        {
            var user = await _userDbContext.DemoUsers.FindAsync(Id);
            _userDbContext.DemoUsers.Remove(user);
            await _userDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(NAGPDemoUser user)
        {
            await _userDbContext.DemoUsers.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
            return Ok();
        }

       

    }
}
