using System.ComponentModel.DataAnnotations;

namespace AnimalShelterApi.Models
{
  public class Cat
  {

    public int CatId { get; set; }

    [Required]
    [StringLength(20)]
    public string CatName { get; set; }

    [Required]
    public string CatBreed { get; set; }

    [Required]
    [Range(0, 20, ErrorMessage = "Age must be between 0 and 20")]
    public int CatAge { get; set; }

    [Required]
    public string CatDetails { get; set; }

  }
}