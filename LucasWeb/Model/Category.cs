using System.ComponentModel.DataAnnotations;

namespace LucasWeb.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Display Order")]
        [Range(1,100,ErrorMessage ="The display order should be in the range of 1-100")]
        public int DisplayOrder { get; set; }
    }
}
