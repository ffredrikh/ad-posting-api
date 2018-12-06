using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdPostingApi.Entities
{
    public class AdInfoContext : DbContext
    {
        public DbSet<AdInfo> AdsInfo { get; set; }
        public DbSet<AdPicture> AdPictures { get; set; }

        public AdInfoContext(DbContextOptions<AdInfoContext> options) : base(options)
        {
            Database.Migrate();         
        }
      
    }
}
