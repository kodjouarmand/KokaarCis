using System;
using KokaarCis.Api.Initializer;
using KokaarCis.Domain.Contexts;
using KokaarCis.Domain.Entities;
using KokaarCis.Infrastructure.Contracts;
using KokaarCis.Utility.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KokaarCis.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DbInitializerController : ControllerBase
    {

        private readonly IDbInitializer _dbInitializer;
        public DbInitializerController(IDbInitializer dbInitializer)
        {
            _dbInitializer = dbInitializer;
        }

        [HttpPost("{ensureDeleted}")]
        public IActionResult Post(bool ensureDeleted = false)
        {
            try
            {
                _dbInitializer.Initialize(ensureDeleted);
                return Ok("Database initialization succeed");
            }
            catch (Exception)
            {
                return BadRequest("Database initialization failed. Please checks the log files for more information about the error.");
            }
        }
    }
}
