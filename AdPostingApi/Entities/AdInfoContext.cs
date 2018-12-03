using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdPostingApi.Entities
{
    public class AdInfoContext : DbContext
    {
        public DbSet<AdInfo> Ads { get; set; }

        public AdInfoContext(DbContextOptions<AdInfoContext> options) : base(options)
        {
            Database.Migrate();

            if (!Ads.Any())
            {
                AddMockupData();
            }
        }

        private void AddMockupData()
        {
            var ads = new List<AdInfo>()
            {
                new AdInfo(){
                    Title = "Test title 1", Text = "Test text 1", Category = "Test category 1",
                    Pictures = new List<AdPicture>(){ new AdPicture() { AdId = 1, Title = "Test picture 1", Url = "Test url 1" }}
                },

                new AdInfo(){
                    Title = "Test title 2", Text = "Test text 2", Category = "Test category 2",
                    Pictures = new List<AdPicture>(){ new AdPicture() { AdId = 2, Title = "Test picture 2", Url = "Test url 2" }}
                }
            };

            Ads.AddRange(ads);
            this.SaveChanges();
        }
    }
}
