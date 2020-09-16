using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tournament_user_score_tracker.Models;
using tournament_user_score_tracker.Services;

namespace tournament_user_score_tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _context;
        public UserController(UserService context)
        {
            _context = context;
        }

        // GET http://localhost:5000/api/user/test
        [HttpGet("test")]
        public int getInt()
        {
            return 1;
        }
    }
}
