using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdPostingApi.Entities;
using AdPostingApi.Models;
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
            var ads = AutoMapper.Mapper.Map<IEnumerable<AdInfoDto>>(_repo.GetAds());
            return Ok(ads);
        }

        // GET api/ads/x
        [HttpGet("{id}", Name = "GetAd")]
        public ActionResult<AdInfoDto> Get(int id)
        {
            return Ok(_repo.GetAd(id));
        }

        // POST api/ads
        [HttpPost]
        public IActionResult Post([FromBody] AdInfoDto adInfoDto)
        {
            if (adInfoDto == null)
                return BadRequest();

            if (string.IsNullOrWhiteSpace(adInfoDto.Title))
                ModelState.AddModelError("Description", "Title is missing.");

            if (string.IsNullOrWhiteSpace(adInfoDto.Text))
                ModelState.AddModelError("Description", "Text is missing.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Use automapper
            var adInfo = new AdInfo()
            {
                Title = adInfoDto.Title,
                Text = adInfoDto.Text,
                Category = adInfoDto.Category,
                Pictures = adInfoDto.Pictures
            };

            _repo.AddAd(adInfo);
            return CreatedAtRoute("GetAd", new { Id = adInfo.Id }, adInfo);
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