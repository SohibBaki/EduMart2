using IleriWebProje.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace IleriWebProje.Models
{
    public class Platforms : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Platform Logo is required")]
        public string PlatformLogo { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Platform Name is required")]
        public string PlatformName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        // Relationships
        public List<Skills> ? Skills { get; set; }
    }
}
