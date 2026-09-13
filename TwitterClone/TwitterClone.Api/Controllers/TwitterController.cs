using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TwitterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("tweets")]
        public IActionResult GetTweets()
        {
            var tweets = new List<Tweet>
            {
                new Tweet(Guid.NewGuid(), "This is my first tweet!")
            };

            return Ok(tweets);
        }

        [HttpGet("app-info")]
        public IActionResult GetAppInfo()
        {
            var appName =
                _configuration.GetValue<string>("AppSettings:AppName");

            return Ok(new { AppName = appName });
        }
    }
}