using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = new List<User>
            {
                new User("Tanvir Ahmed Swapnil", "tanvir@example.com"),
                new User("Ali Hayder Shuvo", "ali@example.com"),
                new User("Shomirul Hayder Shourav", "shomirul@example.com")
            };

            users[0].UpdateBio("Full-stack developer");

            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetUser(Guid id)
        {
            var user = new User("Placeholder", "placeholder@example.com");
            return Ok(user);
        }
    }
}
