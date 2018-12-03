using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdPostingApi.Models
{
    public class AdInfoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }

    }
}
