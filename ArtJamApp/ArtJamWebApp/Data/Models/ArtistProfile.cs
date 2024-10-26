using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtJamWebApp.Data.Models
{
    public class ArtistProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public required User User { get; set; }

        [StringLength(1000, ErrorMessage = "ArtistBio cannot be longer than 1000 characters.")]
        public string? ArtistBio { get; set; }

        public required ICollection<ArtistImage> ArtistImages { get; set; } = new List<ArtistImage>();
    }
}
