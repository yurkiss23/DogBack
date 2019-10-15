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
    public class DogsController : ControllerBase
    {
        private readonly EFDbContext _context;
        
        public DogsController(EFDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult DogList()
        {
            var model = _context.Dogs.Select(d => new DogVM
            {
                Id=d.Id,
                Name=d.Name,
                Image=d.Image
            }).ToList();

            return Ok(model);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody]DogCreateVM model)
        {
            DbDog dog = new DbDog
            {
                BreedId = model.BreedId,
                Name = "No name",
                Image = "http://s3.amazonaws.com/37assets/svn/765-default-avatar.png"
            };
            _context.Dogs.Add(dog);
            _context.SaveChanges();
            return Ok(dog);
        }
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var res = _context.Dogs.FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                _context.Dogs.Remove(res);
                _context.SaveChanges();
            }
            return Ok();
        }
    }
}