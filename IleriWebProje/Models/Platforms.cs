using System.ComponentModel.DataAnnotations;

namespace IleriWebProje.Models
{
    public class Platforms
    {
        [Key]
        public int PlatformID { get; set; }
        public string PlatformLogo { get; set; }
        public string PlatformName { get; set; }
        public string Description { get; set; }

        // Relationships
        public List<Skills> Skills { get; set; }
    }
}
