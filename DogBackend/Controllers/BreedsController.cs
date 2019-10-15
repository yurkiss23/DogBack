using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogBackend.DAL.Entities;
using DogBackend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BreedsController : ControllerBase
    {
        private readonly EFDbContext _context;

        public BreedsController(EFDbContext context)
        {
            _context = context;
        }
        [HttpGet("select")]
        public IActionResult BreedSelectList()
        {
            var model = _context.Breeds
                .Where(b=>b.IsShow)
                .Select(b => new BreedSelectVM
            {
                Id = b.Id,
                Name = b.Name
            }).ToList();

            return Ok(model);
        }
    }
}