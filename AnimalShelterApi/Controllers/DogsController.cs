using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DogsController : ControllerBase
  {
    private AnimalShelterApiContext _db;

    public DogsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Dog>> Get()
    {
      var query = _db.Dogs.AsQueryable();

      return query.OrderByDescending(x => x.DogName).ToList();
    }

    [HttpPost]
    public void Post([FromBody] Dog dog)
    {
      _db.Dogs.Add(dog);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Dog> Get(int id)
    {
      return _db.Dogs.FirstOrDefault(entry => entry.DogId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Dog dog)
    {
      dog.DogId = id;
      _db.Entry(dog).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Dog dogToDelete = _db.Dogs.FirstOrDefault(entry => entry.DogId == id);
      _db.Dogs.Remove(dogToDelete);
      _db.SaveChanges();
    }

    [HttpGet("popular")]
    public ActionResult<IEnumerable<Dog>> GetMostPopularBreed()
    {
      IEnumerable<Dog> query = _db.Dogs.AsQueryable();
      var breedGroup = query.GroupBy(x => x.DogBreed);
      var maxCount = breedGroup.Max(g => g.Count());
      var mostPopular = breedGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToList();
      query = query.Where(entry => entry.DogBreed == mostPopular[0]);
      return query.OrderByDescending(x => x.DogAge).ToList();
    }

    [HttpGet("random")]
    public ActionResult<Dog> GetRandom()
    {
      List<Dog> allDogs = _db.Dogs.ToList();
      Random rand = new Random();
      int temp = rand.Next(0, allDogs.Count());
      return allDogs[temp];
    }

    [HttpGet("search")]
    public ActionResult<IEnumerable<Dog>> GetSearch(string breed)
    {
      var query = _db.Dogs.AsQueryable();

      if (breed != null)
      {
        query = query.Where(entry => entry.DogBreed.ToUpper() == breed.ToUpper());
      }

      return query.OrderByDescending(x => x.DogName).ToList();
    }

  }
}