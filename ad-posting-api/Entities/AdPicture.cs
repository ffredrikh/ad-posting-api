using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdPostingApi.Entities
{
    public class AdPicture
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AdInfoId")]
        public int AdInfoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
