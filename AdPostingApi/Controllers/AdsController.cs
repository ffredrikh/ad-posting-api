using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdPostingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdPostingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private IAdsRepository _repo;

        public AdsController(IAdsRepository repo)
        {
            _repo = repo;
        }

        // GET api/ads
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAds());
        }

        // GET api/ads/5
        [HttpGet("{id}")]
        public ActionResult<int> Get(int id)
        {
            return id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}