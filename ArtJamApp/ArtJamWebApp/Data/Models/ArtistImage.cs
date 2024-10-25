using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtJamWebApp.Data.Models
{
    public class ArtistImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ArtistProfile")]
        public int ArtistProfileId { get; set; }
        public required ArtistProfile ArtistProfile { get; set; }

        [Required]
        public required byte[] ImageData { get; set; }

        [Required]
        public required string ImageMimeType { get; set; }

        [StringLength(1000, ErrorMessage = "UserBi cannot be longer than 1000 characters.")]
        public string? UserBi { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
    }
}