using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtJamWebApp.Data.Models
{
    public class MusicianProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public required User User { get; set; }

        [StringLength(1000, ErrorMessage = "UserBio cannot be longer than 1000 characters.")]
        public string? MusicianBio { get; set; }

        public ICollection<MusicianInstrument> Instruments { get; set; } = new List<MusicianInstrument>();

        [Required]
        public bool LookingForGroup { get; set; }

        public ICollection<Group>? CreatedGroups { get; set; }
        public ICollection<GroupMember>? GroupMemberships { get; set; }
        public ICollection<Record>? UploadedRecords { get; set; }
    }
}