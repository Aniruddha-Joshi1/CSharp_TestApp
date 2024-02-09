using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TestApp.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Catgeory Name")]
    [MaxLength(40,ErrorMessage ="Maximum number of charavters allowed is 40")]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1,100,ErrorMessage ="Entered number is out of range")]
    public int DisplayOrder {  get; set; }
}
