using VideoGameApiCharacter.Models;
using VideoGameApiCharacter.Data;
using Microsoft.EntityFrameworkCore;
using VideoGameApiCharacter.Dtos;

namespace VideoGameApiCharacter.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {
        public async Task<CharacterResponse> AddCharacterAsync(CreateCharacterRequest character)
        {
            var newCharacter = new Character
            {
                Name = character.Name,
                Game = character.Game,
                Rol = character.Rol,
            };

            context.Characters.Add(newCharacter);
            await context.SaveChangesAsync();

            return new CharacterResponse
            {
                Id = newCharacter.Id,
                Name = newCharacter.Name,
                Game = newCharacter.Game,
                Rol = newCharacter.Rol,
            };
        }

        public async Task<List<CharacterResponse>> GetAllCharactersAsync() 
            => await context.Characters.Select(c => new CharacterResponse
            {
                Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                Rol = c.Rol,
            }).ToListAsync();

        public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
        {
            var result = await context.Characters
                .Where(c => c.Id == id)
                .Select(c => new CharacterResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Game = c.Game,
                    Rol = c.Rol
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterRequest character)
        {
            var existingCharacter = await context.Characters.FindAsync(id);
            if (existingCharacter is null) 
                return false;

            existingCharacter.Name = character.Name;
            existingCharacter.Game = character.Game;
            existingCharacter.Rol = character.Rol;

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var characterToDelete = await context.Characters.FindAsync(id);

            if (characterToDelete is null) return false;

            context.Characters.Remove(characterToDelete);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
