using Microsoft.AspNetCore.Mvc;
using VideoGameApiCharacter.Models;
using VideoGameApiCharacter.Services;

namespace VideoGameApiCharacter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VideoGameCharactersController(IVideoGameCharacterService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters() 
            => Ok(await service.GetAllCharactersAsync());

        [HttpGet("{id}")]

        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            return character is null ? NotFound("Character with the given Id was not found.") : Ok(character);
        }
    }
}
