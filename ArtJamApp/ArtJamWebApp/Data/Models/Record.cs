using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtJamWebApp.Data.Models
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Title cannot be longer than 200 characters.")]
        public required string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Genre cannot be longer than 50 characters.")]
        public required string Genre { get; set; }

        [Required]
        public required byte[] FileData { get; set; }

        [Required]
        public required string FileMimeType { get; set; }

        [ForeignKey("UploadedByMusician")]
        public int? UploadedByMusicianId { get; set; }
        public MusicianProfile? UploadedByMusician { get; set; }

        [ForeignKey("UploadedByGroup")]
        public int? UploadedByGroupId { get; set; }
        public Group? UploadedByGroup { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        public string? RecordType { get; set; }
    }
}
