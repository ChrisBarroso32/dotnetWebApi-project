namespace VideoGameApiCharacter.Dtos
{
    public class CreateCharacterRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Game { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}
