using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtJamWebApp.Data.Models
{
    public class UserFollower
    {
        [Required]
        [ForeignKey("Follower")]
        public required string FollowerId { get; set; }
        public required IdentityUser Follower { get; set; }

        [Required]
        [ForeignKey("Followed")]
        public required string FollowedId { get; set; }
        public required IdentityUser Followed { get; set; }
    }
}