using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtJamWebApp.Data.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Group name cannot be longer than 100 characters.")]
        public required string GroupName { get; set; }

        [StringLength(1000, ErrorMessage = "UserBio cannot be longer than 1000 characters.")]
        public string? GroupBio { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Genre cannot be longer than 50 characters.")]
        public required string Genre { get; set; }

        [Required]
        [ForeignKey("CreatedByMusician")]
        public int CreatedBy { get; set; }
        public required MusicianProfile CreatedByMusician { get; set; }

        [Required]
        public bool IsLookingForArtist { get; set; }

        [Required]
        public bool IsLookingForMusicians { get; set; }

        public required ICollection<GroupMember> Members { get; set; }

        public ICollection<Record>? UploadedRecords { get; set; }

        public required ICollection<Event> GroupEvents { get; set; }
    }
}