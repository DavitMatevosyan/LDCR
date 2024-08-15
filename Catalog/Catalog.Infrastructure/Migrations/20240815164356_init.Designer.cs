﻿// <auto-generated />
using System;
using Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20240815164356_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Catalog.Domain.Models.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<bool>("IsObsolete")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RepetitionRule")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a023929-cac4-45da-8b7f-4bdd1cd083ce"),
                            Code = "CS101",
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = new TimeSpan(0, 1, 30, 0, 0),
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Intro to CS",
                            RepetitionRule = 31,
                            StartDate = new DateTime(2024, 2, 12, 18, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                            Code = "CS201",
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = new TimeSpan(0, 1, 0, 0, 0),
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Programming Details",
                            RepetitionRule = 96,
                            StartDate = new DateTime(2024, 8, 20, 12, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("223030a6-c3fe-4802-80c7-d22cdb02d569"),
                            Code = "CS301",
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Duration = new TimeSpan(0, 2, 0, 0, 0),
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pragmatic Programmer",
                            RepetitionRule = 31,
                            StartDate = new DateTime(2024, 2, 20, 20, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Catalog.Domain.Models.Homework", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcceptanceCriteria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsObsolete")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Homework");

                    b.HasData(
                        new
                        {
                            Id = new Guid("98030dcf-df14-4cf3-a0c4-47062adce75a"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Note 1",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                            Title = "Homework 1"
                        },
                        new
                        {
                            Id = new Guid("0774b0b6-6dac-4bf4-b4ce-023491f81a71"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Note 2",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                            Title = "Homework 2"
                        },
                        new
                        {
                            Id = new Guid("17aef592-7b32-4330-b21d-31f53a530c7b"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Note 3",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                            Title = "Homework 3"
                        },
                        new
                        {
                            Id = new Guid("f07004aa-4feb-48a4-ada5-2c49bc37d5e0"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Note 1",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"),
                            Title = "Homework 1"
                        },
                        new
                        {
                            Id = new Guid("57b2c785-55f5-4b08-b2c0-6e6b71724000"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Note 2",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"),
                            Title = "Homework 2"
                        },
                        new
                        {
                            Id = new Guid("e84fd466-c932-486f-a482-b0d6c2885dab"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Note 3",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"),
                            Title = "Homework 3"
                        });
                });

            modelBuilder.Entity("Catalog.Domain.Models.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsObsolete")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f4cad70-b562-4377-a18d-7b7c705c2e3c"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Note 1",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e")
                        },
                        new
                        {
                            Id = new Guid("1cedccea-a904-4284-b719-c4891a6e153b"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Note 2",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e")
                        },
                        new
                        {
                            Id = new Guid("f30e1f87-a9b7-47a7-89dc-aa599574ef4e"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Sample Note 3",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionId = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e")
                        });
                });

            modelBuilder.Entity("Catalog.Domain.Models.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("IsObsolete")
                        .HasColumnType("bit");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Topic")
                        .IsUnique();

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("Topic"), false);

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e"),
                            CourseId = new Guid("2a023929-cac4-45da-8b7f-4bdd1cd083ce"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Introduction to Course, will learn a lot of things",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 19, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            Topic = "Introduction to Course CS101"
                        },
                        new
                        {
                            Id = new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a"),
                            CourseId = new Guid("2a023929-cac4-45da-8b7f-4bdd1cd083ce"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Introduction to Course, will learn a lot of things Part 2",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 20, 19, 30, 0, 0, DateTimeKind.Unspecified),
                            Topic = "Introduction to Course CS101"
                        },
                        new
                        {
                            Id = new Guid("2bd3e9ac-32bb-44cb-a427-5a1cab82d0e7"),
                            CourseId = new Guid("2a023929-cac4-45da-8b7f-4bdd1cd083ce"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Introduction to Course, will learn a lot of things Part 3",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 21, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            Topic = "Introduction to Course CS101"
                        },
                        new
                        {
                            Id = new Guid("9913114a-cb5e-4d00-bf63-ad054a179099"),
                            CourseId = new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Programming Details CS201, will learn a lot of things",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 8, 20, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            Topic = "Programming Details CS201"
                        },
                        new
                        {
                            Id = new Guid("fce3bf3f-bdaf-4672-b878-ea05f7e33319"),
                            CourseId = new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Programming Details CS201, will learn a lot of things",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 8, 21, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            Topic = "Programming Details CS201"
                        },
                        new
                        {
                            Id = new Guid("9437caa9-9814-49d1-a031-9d77d6bf9005"),
                            CourseId = new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Programming Details CS201, will learn a lot of things",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 22, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            Topic = "Programming Details CS201"
                        },
                        new
                        {
                            Id = new Guid("bdd42fa0-197d-4c8b-b02f-492a866ae115"),
                            CourseId = new Guid("e9b6ab56-5f9d-4f75-b29b-aa5736606c84"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Programming Details CS201, will learn a lot of things",
                            IsObsolete = false,
                            ModifiedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 23, 18, 30, 0, 0, DateTimeKind.Unspecified),
                            Topic = "Programming Details CS201"
                        });
                });

            modelBuilder.Entity("Catalog.Domain.Models.SessionReference", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("SessionReferences");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fbc3a10f-578a-4f3d-975b-b9c9410a7aaa"),
                            Reference = "Sample reference 1",
                            SessionId = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e")
                        },
                        new
                        {
                            Id = new Guid("86f842dc-27a9-4327-b91b-87ec7537b212"),
                            Reference = "Sample reference 2",
                            SessionId = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e")
                        },
                        new
                        {
                            Id = new Guid("8ac5adf8-c074-4818-8664-7e8367cbf552"),
                            Reference = "Sample reference 3",
                            SessionId = new Guid("f40a485e-d022-4ce9-9756-33ad30ad859e")
                        },
                        new
                        {
                            Id = new Guid("d1ef9757-b333-402a-8d3c-98d8b878ba30"),
                            Reference = "Sample reference 1",
                            SessionId = new Guid("a76dfcb8-5aa5-4ca0-bcb9-d2ac980e882a")
                        });
                });

            modelBuilder.Entity("Catalog.Domain.Models.Homework", b =>
                {
                    b.HasOne("Catalog.Domain.Models.Session", "Session")
                        .WithMany("Homeworks")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Catalog.Domain.Models.Note", b =>
                {
                    b.HasOne("Catalog.Domain.Models.Session", "Session")
                        .WithMany("Notes")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Catalog.Domain.Models.Session", b =>
                {
                    b.HasOne("Catalog.Domain.Models.Course", "Course")
                        .WithMany("Sessions")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Catalog.Domain.Models.SessionReference", b =>
                {
                    b.HasOne("Catalog.Domain.Models.Session", "Session")
                        .WithMany("SessionReferences")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Catalog.Domain.Models.Course", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Catalog.Domain.Models.Session", b =>
                {
                    b.Navigation("Homeworks");

                    b.Navigation("Notes");

                    b.Navigation("SessionReferences");
                });
#pragma warning restore 612, 618
        }
    }
}
