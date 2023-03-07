using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RickAndMorty.Models.Schema;
using RickAndMorty.Services.Interface;

namespace RickAndMorty.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class RickAndMortyController : Controller
    {
        private readonly IRickAndMortyService _rickAndMortyService;
        private readonly IMemoryCache _memoryCache;

        public RickAndMortyController(IRickAndMortyService rickAndMortyService, IMemoryCache memoryCache)
        {
            _rickAndMortyService = rickAndMortyService;
            _memoryCache = memoryCache;
        }

        [HttpGet("person")]
        public async Task<IActionResult> GetPerson([FromQuery] string name)
        {
            if (_memoryCache.TryGetValue(name, out object result))
                return Ok(result);

            var character = await _rickAndMortyService.GetCharacterByNameAsync(name);

            if (character == null)
                return NotFound();

            _memoryCache.Set(name, character);

            return Ok(character);
        }

        [HttpPost("check-person")]
        public async Task<IActionResult> CheckPerson(CheckPersonSchema checkPersonSchema)
        {
            if (_memoryCache.TryGetValue(checkPersonSchema.ToString(), out object result))
                return Ok(result);

            var isPersonInEpisode = await _rickAndMortyService.CheckPersonInEpisodeAsync(checkPersonSchema.PersonName, checkPersonSchema.EpisodeName);

            if(isPersonInEpisode == null)
                return NotFound();

            _memoryCache.Set(checkPersonSchema.ToString(), isPersonInEpisode);

            return Ok(isPersonInEpisode.Value);
        }
    }
}
