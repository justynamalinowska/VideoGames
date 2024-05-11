﻿using Core;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class VideoGamesContext : DbContext, IVideoGamesContext
{
    public VideoGamesContext() { }

    public VideoGamesContext(DbContextOptions<VideoGamesContext> options) : base(options) { }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GamePlatform> GamePlatforms { get; set; }

    public virtual DbSet<GamePublisher> GamePublishers { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<RegionSale> RegionSales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=video_games;Integrated Security=true;TrustServerCertificate=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__game__3213E83F556E8A0B");

            entity.ToTable("game");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GameName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("game_name");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");

            entity.HasOne(d => d.Genre).WithMany(p => p.Games)
                .HasForeignKey(d => d.GenreId)
                .HasConstraintName("fk_gm_gen");
        });

        modelBuilder.Entity<GamePlatform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__game_pla__3213E83F0C21C8C8");

            entity.ToTable("game_platform");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GamePublisherId).HasColumnName("game_publisher_id");
            entity.Property(e => e.PlatformId).HasColumnName("platform_id");
            entity.Property(e => e.ReleaseYear).HasColumnName("release_year");

            entity.HasOne(d => d.GamePublisher).WithMany(p => p.GamePlatforms)
                .HasForeignKey(d => d.GamePublisherId)
                .HasConstraintName("fk_gpl_gp");

            entity.HasOne(d => d.Platform).WithMany(p => p.GamePlatforms)
                .HasForeignKey(d => d.PlatformId)
                .HasConstraintName("fk_gpl_pla");
        });

        modelBuilder.Entity<GamePublisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__game_pub__3213E83FA80D39F3");

            entity.ToTable("game_publisher");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");

            entity.HasOne(d => d.Game).WithMany(p => p.GamePublishers)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("fk_gpu_gam");

            entity.HasOne(d => d.Publisher).WithMany(p => p.GamePublishers)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("fk_gpu_pub");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__genre__3213E83FA1519B8A");

            entity.ToTable("genre");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.GenreName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genre_name");
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__platform__3213E83F0859CEDF");

            entity.ToTable("platform");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PlatformName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("platform_name");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__publishe__3213E83F7D6A6C65");

            entity.ToTable("publisher");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("publisher_name");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__region__3213E83FB0C8E8DB");

            entity.ToTable("region");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.RegionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("region_name");
        });

        modelBuilder.Entity<RegionSale>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("region_sales");

            entity.Property(e => e.GamePlatformId).HasColumnName("game_platform_id");
            entity.Property(e => e.NumSales)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("num_sales");
            entity.Property(e => e.RegionId).HasColumnName("region_id");

            entity.HasOne(d => d.GamePlatform).WithMany()
                .HasForeignKey(d => d.GamePlatformId)
                .HasConstraintName("fk_rs_gp");

            entity.HasOne(d => d.Region).WithMany()
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("fk_rs_reg");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
