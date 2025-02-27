﻿// <auto-generated />
using System;
using LearnTop.Modules.Blogs.Infrastructure.ReadDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnTop.Modules.Blogs.Infrastructure.ReadDb.Migrations
{
    [DbContext(typeof(BlogViewsDbContext))]
    partial class BlogViewsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Blogs")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LearnTop.Modules.Blogs.Domain.Articles.Views.ArticleTagView", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ArticleId", "TagId");

                    b.ToTable("ArticleTagViews", "Blogs");
                });

            modelBuilder.Entity("LearnTop.Modules.Blogs.Domain.Articles.Views.ArticleView", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ArticleViews", "Blogs");
                });

            modelBuilder.Entity("LearnTop.Modules.Blogs.Domain.Articles.Views.ArticleTagView", b =>
                {
                    b.HasOne("LearnTop.Modules.Blogs.Domain.Articles.Views.ArticleView", "ArticleView")
                        .WithMany("TagViews")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArticleView");
                });

            modelBuilder.Entity("LearnTop.Modules.Blogs.Domain.Articles.Views.ArticleView", b =>
                {
                    b.Navigation("TagViews");
                });
#pragma warning restore 612, 618
        }
    }
}
