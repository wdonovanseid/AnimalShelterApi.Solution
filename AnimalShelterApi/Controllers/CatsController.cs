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
  public class CatsController : ControllerBase
  {
    private AnimalShelterApiContext _db;

    public CatsController(AnimalShelterApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get(string search)
    {
      var query = _db.Cats.AsQueryable();

      return query.OrderByDescending(x => x.CatName).ToList();
    }

    [HttpPost]
    public void Post([FromBody] Cat cat)
    {
      _db.Cats.Add(cat);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Cat> Get(int id)
    {
      return _db.Cats.FirstOrDefault(entry => entry.CatId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Cat cat)
    {
      cat.CatId = id;
      _db.Entry(cat).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      Cat catToDelete = _db.Cats.FirstOrDefault(entry => entry.CatId == id);
      _db.Cats.Remove(catToDelete);
      _db.SaveChanges();
    }

    [HttpGet("popular")]
    public ActionResult<IEnumerable<Cat>> GetMostPopularBreed()
    {
      IEnumerable<Cat> query = _db.Cats.AsQueryable();
      var breedGroup = query.GroupBy(x => x.CatBreed);
      var maxCount = breedGroup.Max(g => g.Count());
      var mostPopular = breedGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToList();
      query = query.Where(entry => entry.CatBreed == mostPopular[0]);
      return query.OrderByDescending(x => x.CatAge).ToList();
    }

    [HttpGet("random")]
    public ActionResult<Cat> GetRandom()
    {
      List<Cat> allCats = _db.Cats.ToList();
      Random rand = new Random();
      int temp = rand.Next(0, allCats.Count()-1);
      return allCats[temp];
    }

  }
}