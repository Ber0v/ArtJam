using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtJamWebApp.Data.Models
{
    public class MusicianInstrument
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("MusicianProfile")]
        public int MusicianProfileId { get; set; }
        public required MusicianProfile MusicianProfile { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Instrument name cannot be longer than 100 characters.")]
        public required string InstrumentName { get; set; }
    }
}
