using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdPostingApi.Entities
{
    public class AdInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        public ICollection<AdPicture> Pictures { get; set; } = new List<AdPicture>();
    }
}
