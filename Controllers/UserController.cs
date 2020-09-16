using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using tournament_user_score_tracker.Models;
using tournament_user_score_tracker.Services;

namespace tournament_user_score_tracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService UserService)
        {
            _userService = UserService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPost]
        public ActionResult<User> Create(User User)
        {
            _userService.Create(User);

            return CreatedAtRoute("GetUser", new { id = User.Id.ToString() }, User);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User UserIn)
        {
            var User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _userService.Update(id, UserIn);

            return Ok(UserIn);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _userService.Remove(User.Id);

            return NoContent();
        }
    }
}