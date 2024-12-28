using IleriWebProje.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace IleriWebProje.Models
{
    public class Platforms : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        public string PlatformLogo { get; set; }

        [Display(Name = "Platform Name")]
        public string PlatformName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        // Relationships
        public List<Skills>? Skills { get; set; }
    }
}
