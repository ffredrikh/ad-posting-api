using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdPostingApi.Entities
{
    public class AdInfoContext : DbContext
    {
        public List<AdInfo> Ads { get; set; }

        public AdInfoContext()
        {
            InitMockupData();
        }

        private void InitMockupData()
        {
            Ads = new List<AdInfo>()
            {
                new AdInfo(){ Id = 1, Title = "Car", Text = "Excellent condition.", Category = "Vehicle" },
                new AdInfo(){ Id = 2, Title = "Airplane", Text = "Terrible condition.", Category = "Vehicle" },
                new AdInfo(){ Id = 3, Title = "Dog", Text = "Not very friendly.", Category = "Pet" },
                new AdInfo(){ Id = 4, Title = "Cat", Text = "Likes to cuddle.", Category = "Pet" },
                new AdInfo(){ Id = 5, Title = "Boots", Text = "Good for long walks.", Category = "Shoes" }
            };
         
        }


    }
}
