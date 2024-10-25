using Microsoft.AspNetCore.Identity;

namespace ArtJamWebApp.Data.Models
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            this.Id = Guid.NewGuid();
        }

    }
}
