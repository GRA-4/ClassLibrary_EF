using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary_EF;

public partial class KinoDbnewContext : DbContext
{
    public KinoDbnewContext()
    {
    }

    public KinoDbnewContext(DbContextOptions<KinoDbnewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=(localdb)\\LocalZh;Database=KinoDBNew1_1;Trusted_Connection=True;TrustServerCertificate=True");
    => optionsBuilder.UseSqlServer("Server=DESKTOP-T5P3GVP;Database=KinoDBNew1;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(e => e.ParentCommentId, "IX_Comments_ParentCommentId");

            entity.HasIndex(e => e.PostId, "IX_Comments_PostId");

            entity.HasIndex(e => e.UserId, "IX_Comments_UserId");

            entity.Property(e => e.DateTime).HasColumnName("dateTime");

            entity.HasOne(d => d.ParentComment).WithMany(p => p.InverseParentComment).HasForeignKey(d => d.ParentCommentId);

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.User).WithMany(p => p.Comments).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasMany(d => d.TitlesTitles).WithMany(p => p.GenresGenres)
                .UsingEntity<Dictionary<string, object>>(
                    "GenreTitle",
                    r => r.HasOne<Title>().WithMany().HasForeignKey("TitlesTitleId"),
                    l => l.HasOne<Genre>().WithMany().HasForeignKey("GenresGenreId"),
                    j =>
                    {
                        j.HasKey("GenresGenreId", "TitlesTitleId");
                        j.ToTable("GenreTitle");
                        j.HasIndex(new[] { "TitlesTitleId" }, "IX_GenreTitle_TitlesTitleId");
                    });
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Lists_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Lists)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(d => d.TitlesTitles).WithMany(p => p.ListsLists)
                .UsingEntity<Dictionary<string, object>>(
                    "ListTitle",
                    r => r.HasOne<Title>().WithMany().HasForeignKey("TitlesTitleId"),
                    l => l.HasOne<List>().WithMany().HasForeignKey("ListsListId"),
                    j =>
                    {
                        j.HasKey("ListsListId", "TitlesTitleId");
                        j.ToTable("ListTitle");
                        j.HasIndex(new[] { "TitlesTitleId" }, "IX_ListTitle_TitlesTitleId");
                    });
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasIndex(e => e.TitleId, "IX_Posts_TitleId");

            entity.HasIndex(e => e.UserId, "IX_Posts_UserId");

            entity.Property(e => e.NamePost).HasDefaultValueSql("(N'')");

            entity.HasOne(d => d.Title).WithMany(p => p.Posts)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_Users_RoleId");

            entity.HasIndex(e => e.UserName, "IX_Users_UserName").IsUnique();

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
