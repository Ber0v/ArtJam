using ArtJamWebApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtJamWebApp.Data
{
    public class ArtJamDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ArtJamDbContext(DbContextOptions<ArtJamDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<ArtistProfile> ArtistProfiles { get; set; }
        public DbSet<ArtistImage> ArtistImages { get; set; }
        public DbSet<MusicianProfile> MusicianProfiles { get; set; }
        public DbSet<MusicianInstrument> MusicianInstruments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<AdminAction> AdminActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArtistImage>()
                .HasOne(ai => ai.ArtistProfile)
                .WithMany(ap => ap.ArtistImages)
                .HasForeignKey(ai => ai.ArtistProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            GroupMemberMetod(modelBuilder);

            modelBuilder.Entity<Record>()
                .HasOne(r => r.UploadedByGroup)
                .WithMany(g => g.UploadedRecords)
                .HasForeignKey(r => r.UploadedByGroupId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.Group)
                .WithMany(g => g.GroupEvents)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MusicianInstrument>()
                .HasOne(mi => mi.MusicianProfile)
                .WithMany(mp => mp.Instruments)
                .HasForeignKey(mi => mi.MusicianProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            UserFollowerMetod(modelBuilder);
        }

        private static void GroupMemberMetod(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupMember>()
                            .HasKey(gm => new { gm.GroupId, gm.MusicianId });

            modelBuilder.Entity<GroupMember>()
                 .HasOne(gm => gm.Group)
                 .WithMany(g => g.Members)
                 .HasForeignKey(gm => gm.GroupId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Musician)
                .WithMany(mp => mp.GroupMemberships)
                .HasForeignKey(gm => gm.MusicianId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private static void UserFollowerMetod(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFollower>()
                            .HasKey(uf => new { uf.FollowerId, uf.FollowedId });

            modelBuilder.Entity<UserFollower>()
                .HasOne(uf => uf.Follower)
                .WithMany()
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFollower>()
                .HasOne(uf => uf.Followed)
                .WithMany()
                .HasForeignKey(uf => uf.FollowedId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
