using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Dog
  {

    public int DogId { get; set; }

    [Required]
    [StringLength(20)]
    public string DogName { get; set; }

    [Required]
    public string DogBreed { get; set; }

    [Required]
    [Range(0, 20, ErrorMessage = "Age must be between 0 and 20")]
    public int DogAge { get; set; }

    [Required]
    public string DogDetails { get; set; }

  }
}