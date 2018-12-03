using AdPostingApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdPostingApi.Services
{
    public interface IAdsRepository
    {
        IEnumerable<AdInfo> GetAds();
    }
}
