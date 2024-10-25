using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtJamWebApp.Data.Models
{
    public class GroupMember
    {
        [Required]
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public required Group Group { get; set; }

        [Required]
        [ForeignKey("Musician")]
        public int MusicianId { get; set; }
        public required MusicianProfile Musician { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}
