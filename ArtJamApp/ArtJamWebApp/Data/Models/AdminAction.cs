using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtJamWebApp.Data.Models
{
    public class AdminAction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Admin")]
        public required string AdminId { get; set; }
        public required IdentityUser Admin { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Action type cannot be longer than 200 characters.")]
        public required string ActionType { get; set; }

        [Required]
        public int TargetEntityId { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}