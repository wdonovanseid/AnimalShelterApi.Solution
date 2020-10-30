using Microsoft.EntityFrameworkCore;

namespace AnimalShelterApi.Models
{
  public class AnimalShelterApiContext : DbContext
  {
    public AnimalShelterApiContext(DbContextOptions<AnimalShelterApiContext> options)
        : base(options)
    {
    }

    public DbSet<Cat> Cats { get; set; }
    public DbSet<Dog> Dogs { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Cat>()
          .HasData(
              new Cat { CatId = 1, CatName = "Snowball", CatBreed = "Persian", CatAge= 3, CatDetails = "Likes knocking things over"}
          );

      builder.Entity<Dog>()
          .HasData(
              new Dog { DogId = 1, DogName = "Sam", DogBreed = "Pitbull", DogAge= 2, DogDetails = "Chases own shadow"}
          );
    }
  }
}