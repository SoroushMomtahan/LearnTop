﻿// <auto-generated />
using System;
using LearnTop.Modules.Blogs.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnTop.Modules.Blogs.Infrastructure.Data.WriteDb.Migrations
{
    [DbContext(typeof(BlogsDbContext))]
    partial class BlogsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Blogs")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LearnTop.Modules.Blogs.Domain.Articles.Models.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CoverName")
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

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Articles", "Blogs");
                });

            modelBuilder.Entity("LearnTop.Modules.Blogs.Domain.Articles.Models.Article", b =>
                {
                    b.OwnsOne("LearnTop.Modules.Blogs.Domain.Articles.ValueObjects.Content", "Content", b1 =>
                        {
                            b1.Property<Guid>("ArticleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Content");

                            b1.HasKey("ArticleId");

                            b1.ToTable("Articles", "Blogs");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.OwnsOne("LearnTop.Modules.Blogs.Domain.Articles.ValueObjects.ShortContent", "ShortContent", b1 =>
                        {
                            b1.Property<Guid>("ArticleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ShortContent");

                            b1.HasKey("ArticleId");

                            b1.ToTable("Articles", "Blogs");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.OwnsOne("LearnTop.Modules.Blogs.Domain.Articles.ValueObjects.Title", "Title", b1 =>
                        {
                            b1.Property<Guid>("ArticleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Title");

                            b1.HasKey("ArticleId");

                            b1.ToTable("Articles", "Blogs");

                            b1.WithOwner()
                                .HasForeignKey("ArticleId");
                        });

                    b.Navigation("Content")
                        .IsRequired();

                    b.Navigation("ShortContent")
                        .IsRequired();

                    b.Navigation("Title")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
