using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using AnimalShelterApi.Models;

namespace AnimalShelterApi.Controllers
{
  [Authorize]
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
      IEnumerable<Dog> query = _db.Dogs.AsQueryable();

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
      IEnumerable<IGrouping<string, Dog>> breedGroup = query.GroupBy(x => x.DogBreed);
      int maxCount = breedGroup.Max(g => g.Count());
      List<string> mostPopular = breedGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToList();
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
      IEnumerable<Dog> query = _db.Dogs.AsQueryable();

      if (breed != null)
      {
        query = query.Where(entry => entry.DogBreed.ToUpper() == breed.ToUpper());
      }

      return query.OrderByDescending(x => x.DogName).ToList();
    }

  }
}