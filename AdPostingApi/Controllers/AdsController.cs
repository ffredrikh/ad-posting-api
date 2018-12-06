using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdPostingApi.Entities;
using AdPostingApi.Models;
using AdPostingApi.Services;
using AdPostingApi.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdPostingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private IAdsRepository _repo;
        private ILogger<AdsController> _logger; 

        public AdsController(IAdsRepository repo, ILogger<AdsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET api/ads
        [HttpGet]
        public IActionResult Get()
        {
            var ads = AutoMapper.Mapper.Map<IEnumerable<AdInfoDto>>(_repo.GetAds());
            return Ok(ads);
        }

        public object Setup(Func<object, object> p)
        {
            throw new NotImplementedException();
        }


        // GET api/ads/x
        [HttpGet("{id}", Name = "GetAd")]
        public ActionResult<AdInfoDto> Get(int id)
        {
            if (!_repo.AdExists(id))
            {
                _logger.LogInformation($"Ad with id {id} was not found.");
                return NotFound();
            }

            var ad = AutoMapper.Mapper.Map<AdInfoDto>(_repo.GetAd(id));
            return Ok(ad);
        }


        // POST api/ads
        [HttpPost]
        public IActionResult Post([FromBody] AdInfoDto adInfoDto)
        {
            if (adInfoDto == null)
                return BadRequest();

            RequestValidation.ValidateAdInfoDto(adInfoDto, ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ad = AutoMapper.Mapper.Map<AdInfo>(adInfoDto);
            _repo.AddAd(ad);
            if (!_repo.Save())
                return StatusCode(500, "Post request could not be handled.");

            return CreatedAtRoute("GetAd", new { ad.Id }, ad);
        }


        // PATCH api/ads/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<AdInfoDto> adInfoDtoPatch)
        {
            if (adInfoDtoPatch == null)
                return BadRequest();          

            if (!_repo.AdExists(id))
                return NotFound();

            var adInfo = _repo.GetAd(id);
            if (adInfo == null)
                return NotFound();

            var adInfoDto = AutoMapper.Mapper.Map<AdInfoDto>(adInfo);

            adInfoDtoPatch.ApplyTo(adInfoDto, ModelState);

            RequestValidation.ValidateAdInfoDto(adInfoDto, ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AutoMapper.Mapper.Map(adInfoDto, adInfo);
            if (!_repo.Save())
                return StatusCode(500, "Patch request could not be handled.");
         
            return NoContent();
        }


        // PUT api/ads/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AdInfoDto adInfoDtoPut)
        {
            if (adInfoDtoPut == null)
                return BadRequest();

            RequestValidation.ValidateAdInfoDto(adInfoDtoPut, ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_repo.AdExists(id))
                return NotFound();

            var adInfo = _repo.GetAd(id);

            if (adInfo == null)
                return NotFound();

            AutoMapper.Mapper.Map(adInfoDtoPut, adInfo);

            if (!_repo.Save())
                return StatusCode(500, "Put request could not be handled.");

            return NoContent();
        }


        // DELETE api/ads/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repo.AdExists(id))
                return NotFound();

            var adInfo = _repo.GetAd(id);

            if (adInfo == null)
                return NotFound();

            _repo.DeleteAd(adInfo);

            if (!_repo.Save())
                return StatusCode(500, "Delete request could not be handled.");

            return NoContent();
        }

    }
}