using VideoGameApiCharacter.Dtos;

namespace VideoGameApiCharacter.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponse>> GetAllCharactersAsync();

        Task<CharacterResponse?> GetCharacterByIdAsync(int id);

        Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character);

        Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character);

        Task<bool> DeleteCharacterAsync(int id);
    }
}
