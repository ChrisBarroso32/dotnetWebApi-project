using VideoGameApiCharacter.Models;

namespace VideoGameApiCharacter.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<Character>> GetAllCharactersAsync();

        Task<Character?> GetCharacterByIdAsync(int id);

        Task<Character> AddCharacterAsync(Character character);

        Task<bool> UpdateCharacterAsync(int id, Character character);

        Task<bool> DeleteCharacterAsync(int id);
    }
}
