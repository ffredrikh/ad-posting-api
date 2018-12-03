using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdPostingApi.Entities;

namespace AdPostingApi.Services
{
    public class AdsRepository : IAdsRepository
    {
        private AdInfoContext _context;

        public AdsRepository(AdInfoContext context)
        {
            _context = context;
        }

        public AdInfo AddAd(AdInfo adInfo)
        {
            throw new NotImplementedException();
        }

        public AdInfo GetAd(int id)
        {
            return _context.Ads.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<AdInfo> GetAds()
        {
            return _context.Ads.OrderBy(a => a.Title);
        }
    }
}
