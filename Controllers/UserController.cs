using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tournament_user_score_tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace tournament_user_score_tracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public UserController(ApplicationContext context)
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
