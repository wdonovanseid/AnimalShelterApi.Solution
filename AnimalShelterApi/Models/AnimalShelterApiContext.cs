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
              new Cat { CatId = 1, CatName = "Snowball", CatBreed = "Persian", CatAge= 3, CatDetails = "Likes knocking things over"},
              new Cat { CatId = 2, CatName = "Baseball", CatBreed = "American", CatAge= 6, CatDetails = "Really Likes knocking things over"},
              new Cat { CatId = 3, CatName = "Football", CatBreed = "Persian", CatAge= 9, CatDetails = "Super Likes knocking things over"}

          );

      builder.Entity<Dog>()
          .HasData(
              new Dog { DogId = 1, DogName = "Sam", DogBreed = "Pitbull", DogAge= 2, DogDetails = "Chases own shadow"},
              new Dog { DogId = 2, DogName = "Sammy", DogBreed = "Pitbull", DogAge= 1, DogDetails = "Chases own shadow sometimes"},
              new Dog { DogId = 3, DogName = "Sammuel", DogBreed = "Pitbull", DogAge= 20, DogDetails = "Chases own shadow all the time"}
          );
    }
  }
}