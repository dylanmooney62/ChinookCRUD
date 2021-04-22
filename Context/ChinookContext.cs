using Entities;
using Microsoft.EntityFrameworkCore;


namespace Context
{
    public class ChinookContext : DbContext
    {
        public ChinookContext(DbContextOptions<ChinookContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.AlbumId);

                entity.ToTable("albums");

                entity.HasIndex(e => e.ArtistId)
                    .HasName("IFK_AlbumArtistId");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(160)");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.ArtistId);

                entity.ToTable("artists");

                entity.Property(e => e.Name).HasColumnType("NVARCHAR(120)");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.ToTable("genres");

                entity.Property(e => e.Name).HasColumnType("NVARCHAR(120)");
            });

            modelBuilder.Entity<MediaType>(entity =>
            {
                entity.HasKey(e => e.MediaTypeId);

                entity.ToTable("media_types");

                entity.Property(e => e.Name).HasColumnType("NVARCHAR(120)");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.HasKey(e => e.TrackId);

                entity.ToTable("tracks");

                entity.HasIndex(e => e.AlbumId)
                    .HasName("IFK_TrackAlbumId");

                entity.HasIndex(e => e.GenreId)
                    .HasName("IFK_TrackGenreId");

                entity.HasIndex(e => e.MediaTypeId)
                    .HasName("IFK_TrackMediaTypeId");

                entity.Property(e => e.Composer).HasColumnType("NVARCHAR(220)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("NVARCHAR(200)");

                entity.Property(e => e.UnitPrice)
                    .IsRequired()
                    .HasColumnType("NUMERIC(10,2)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.AlbumId);

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.GenreId);

                entity.HasOne(d => d.MediaType)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.MediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}