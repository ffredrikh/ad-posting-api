﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdPostingApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdPostingApi.Services
{
    public class AdsRepository : IAdsRepository
    {
        private AdInfoContext _context;

        public AdsRepository(AdInfoContext context)
        {
            _context = context;

            if (!_context.AdsInfo.Any())
                AddAdMockupData();
        }

        public AdInfo AddAd(AdInfo adInfo)
        {
            throw new NotImplementedException();
        }

        public AdInfo GetAd(int id)
        {
            return _context.AdsInfo.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<AdInfo> GetAds()
        {
            return _context.AdsInfo.Include(p => p.Pictures).OrderBy(a => a.Title).ToList();
        }

        private void AddAdMockupData()
        {
            var ads = new List<AdInfo>()
            {
                new AdInfo(){
                    Title = "Test title 1", Text = "Test text 1", Category = "Test category 1",
                    Pictures = new List<AdPicture>(){
                        new AdPicture() { Title = "Test picture 1", Url = "Test url 1" },
                        new AdPicture() { Title = "Test picture 2", Url = "Test url 2" }
                    }
                },

                new AdInfo(){
                    Title = "Test title 3", Text = "Test text 3", Category = "Test category 3",
                    Pictures = new List<AdPicture>(){ new AdPicture() { Title = "Test picture 2", Url = "Test url 2" }}
                }
            };

            _context.AdsInfo.AddRange(ads);
            _context.SaveChanges();
        }
    }
}
