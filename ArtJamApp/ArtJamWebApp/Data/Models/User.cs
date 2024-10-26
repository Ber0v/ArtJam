using Microsoft.AspNetCore.Identity;

namespace ArtJamWebApp.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            this.Id = Guid.NewGuid();
        }

        public string? ProfilePicture { get; set; }

        public bool IsMusician { get; set; }

        public MusicianProfile? MusicianProfile { get; set; }
        public ArtistProfile? ArtistProfile { get; set; }
    }
}
