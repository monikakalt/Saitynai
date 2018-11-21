using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace challenge.EF.entities
{
    public partial class challengeContext : DbContext
    {
        //konstruktorius
        public challengeContext(DbContextOptions<challengeContext> options)
        : base(options)
        { }

        public virtual DbSet<ChallengeCategories> ChallengeCategories { get; set; }
        public virtual DbSet<Challenges> Challenges { get; set; }
        public virtual DbSet<ChallengeSubcategories> ChallengeSubcategories { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersChallenges> UsersChallenges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=challenge;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChallengeCategories>(entity =>
            {
                entity.ToTable("challenge_categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Challenges>(entity =>
            {
                entity.ToTable("challenges");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.CompletedBy)
                    .HasColumnName("completedBy")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DaysNeeded).HasColumnName("daysNeeded");

                entity.Property(e => e.Difficulty).HasColumnName("difficulty");

                entity.Property(e => e.ImgUrl)
                    .HasColumnName("imgUrl")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Instructions)
                    .IsRequired()
                    .HasColumnName("instructions")
                    .HasColumnType("text");

                entity.Property(e => e.Reward).HasColumnName("reward");

                entity.Property(e => e.Subcategory).HasColumnName("subcategory");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.Challenges)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__challenge__categ__29572725");

                //entity.HasOne(d => d.SubcategoryNavigation)
                // //   .WithMany(p => p.Challenges)
                //    .HasForeignKey(d => d.Subcategory)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__challenge__subca__2A4B4B5E");
            });

            modelBuilder.Entity<ChallengeSubcategories>(entity =>
            {
                entity.ToTable("challenge_subcategories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("fullName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasColumnName("imgUrl")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash).HasColumnName("passwordHash");

                entity.Property(e => e.PasswordSalt).HasColumnName("passwordSalt");
            });

            modelBuilder.Entity<UsersChallenges>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ChallengeId });

                entity.ToTable("users_challenges");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.ChallengeId).HasColumnName("challenge_id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("endDate")
                    .HasColumnType("date");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Challenge)
                    .WithMany(p => p.UsersChallenges)
                    .HasForeignKey(d => d.ChallengeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users_cha__chall__31EC6D26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersChallenges)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users_cha__user___32E0915F");
            });
        }
    }
}
