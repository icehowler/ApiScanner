﻿// <auto-generated />
using ApiScanner.DataAccess;
using ApiScanner.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ApiScanner.DataAccess.Migrations
{
    [DbContext(typeof(CoreContext))]
    partial class CoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("ApiScanner.Entities.Models.ApiLocationModel", b =>
                {
                    b.Property<Guid>("ApiId");

                    b.Property<Guid>("LocationId");

                    b.HasKey("ApiId", "LocationId");

                    b.HasIndex("LocationId");

                    b.ToTable("ApiLocations");
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.ApiLogModel", b =>
                {
                    b.Property<Guid>("ApiLogId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApiId");

                    b.Property<string>("Content");

                    b.Property<string>("Headers");

                    b.Property<Guid>("LocationId");

                    b.Property<DateTime>("LogDate");

                    b.Property<long>("ResponseTime");

                    b.Property<int>("StatusCode");

                    b.Property<bool>("Success");

                    b.HasKey("ApiLogId");

                    b.HasIndex("ApiId");

                    b.HasIndex("LocationId");

                    b.ToTable("ApiLogs");
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.ApiModel", b =>
                {
                    b.Property<Guid>("ApiId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Headers");

                    b.Property<int>("Interval");

                    b.Property<int>("Method");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("PublicRead");

                    b.Property<bool>("PublicWrite");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<Guid>("UserId");

                    b.HasKey("ApiId");

                    b.HasIndex("UserId");

                    b.ToTable("Apis");
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName")
                        .HasMaxLength(150);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("Subscribe");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.ConditionModel", b =>
                {
                    b.Property<Guid>("ConditionId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApiId");

                    b.Property<int>("CompareType");

                    b.Property<string>("CompareValue")
                        .HasMaxLength(100);

                    b.Property<int>("MatchType");

                    b.Property<string>("MatchVar")
                        .HasMaxLength(100);

                    b.Property<bool>("ShouldPass");

                    b.HasKey("ConditionId");

                    b.HasIndex("ApiId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.LocationModel", b =>
                {
                    b.Property<Guid>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.ApiLocationModel", b =>
                {
                    b.HasOne("ApiScanner.Entities.Models.ApiModel", "Api")
                        .WithMany("ApiLocations")
                        .HasForeignKey("ApiId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApiScanner.Entities.Models.LocationModel", "Location")
                        .WithMany("ApiLocations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.ApiLogModel", b =>
                {
                    b.HasOne("ApiScanner.Entities.Models.ApiModel", "Api")
                        .WithMany("ApiLogs")
                        .HasForeignKey("ApiId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApiScanner.Entities.Models.LocationModel", "Location")
                        .WithMany("ApiLogs")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.ApiModel", b =>
                {
                    b.HasOne("ApiScanner.Entities.Models.ApplicationUser", "User")
                        .WithMany("Apis")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApiScanner.Entities.Models.ConditionModel", b =>
                {
                    b.HasOne("ApiScanner.Entities.Models.ApiModel", "Api")
                        .WithMany("Conditions")
                        .HasForeignKey("ApiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("ApiScanner.Entities.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ApiScanner.Entities.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ApiScanner.Entities.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("ApiScanner.Entities.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApiScanner.Entities.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ApiScanner.Entities.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
