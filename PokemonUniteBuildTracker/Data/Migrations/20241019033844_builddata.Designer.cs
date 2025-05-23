﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonUniteBuildTracker.Data;

#nullable disable

namespace PokemonUniteBuildTracker.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241019033844_builddata")]
    partial class builddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HeldItemPokemon", b =>
                {
                    b.Property<int>("HeldItemsHeldItemId")
                        .HasColumnType("int");

                    b.Property<int>("PokemonsPokemonId")
                        .HasColumnType("int");

                    b.HasKey("HeldItemsHeldItemId", "PokemonsPokemonId");

                    b.HasIndex("PokemonsPokemonId");

                    b.ToTable("HeldItemPokemon");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PokemonUniteBuildTracker.Models.BattleItem", b =>
                {
                    b.Property<int>("BattleItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BattleItemId"));

                    b.Property<int>("BattleItemAttack")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemAttackSpeed")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemCDR")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemCritRate")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemDefense")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemHP")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemImgLink")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemLifesteal")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemMoveSpeed")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemName")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemSpAttack")
                        .HasColumnType("int");

                    b.Property<int>("BattleItemSpDefense")
                        .HasColumnType("int");

                    b.HasKey("BattleItemId");

                    b.ToTable("BattleItems");
                });

            modelBuilder.Entity("PokemonUniteBuildTracker.Models.Build", b =>
                {
                    b.Property<int>("BuildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildId"));

                    b.HasKey("BuildId");

                    b.ToTable("Builds");
                });

            modelBuilder.Entity("PokemonUniteBuildTracker.Models.HeldItem", b =>
                {
                    b.Property<int>("HeldItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HeldItemId"));

                    b.Property<int>("HeldItemAttack")
                        .HasColumnType("int");

                    b.Property<int>("HeldItemAttackSpeed")
                        .HasColumnType("int");

                    b.Property<int>("HeldItemCDR")
                        .HasColumnType("int");

                    b.Property<int>("HeldItemCritRate")
                        .HasColumnType("int");

                    b.Property<int>("HeldItemDefense")
                        .HasColumnType("int");

                    b.Property<int>("HeldItemHP")
                        .HasColumnType("int");

                    b.Property<int>("HeldItemImgLink")
                        .HasColumnType("int");

                    b.Property<int>("HeldItemLifesteal")
                        .HasColumnType("int");

                    b.Property<int>("HeldItemMoveSpeed")
                        .HasColumnType("int");

                    b.Property<string>("HeldItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HeldItemSpAttack")
                        .HasColumnType("int");

                    b.Property<int>("HeldItemSpDefense")
                        .HasColumnType("int");

                    b.HasKey("HeldItemId");

                    b.ToTable("HeldItems");
                });

            modelBuilder.Entity("PokemonUniteBuildTracker.Models.Pokemon", b =>
                {
                    b.Property<int>("PokemonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokemonId"));

                    b.Property<int>("BattleItemId")
                        .HasColumnType("int");

                    b.Property<int>("PokemonAttack")
                        .HasColumnType("int");

                    b.Property<int>("PokemonAttackSpeed")
                        .HasColumnType("int");

                    b.Property<int>("PokemonCDR")
                        .HasColumnType("int");

                    b.Property<int>("PokemonCritRate")
                        .HasColumnType("int");

                    b.Property<int>("PokemonDefense")
                        .HasColumnType("int");

                    b.Property<int>("PokemonHP")
                        .HasColumnType("int");

                    b.Property<string>("PokemonImgLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokemonLifesteal")
                        .HasColumnType("int");

                    b.Property<int>("PokemonMoveSpeed")
                        .HasColumnType("int");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PokemonRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokemonSpAttack")
                        .HasColumnType("int");

                    b.Property<int>("PokemonSpDefense")
                        .HasColumnType("int");

                    b.Property<string>("PokemonStyle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PokemonId");

                    b.HasIndex("BattleItemId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("HeldItemPokemon", b =>
                {
                    b.HasOne("PokemonUniteBuildTracker.Models.HeldItem", null)
                        .WithMany()
                        .HasForeignKey("HeldItemsHeldItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonUniteBuildTracker.Models.Pokemon", null)
                        .WithMany()
                        .HasForeignKey("PokemonsPokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PokemonUniteBuildTracker.Models.Pokemon", b =>
                {
                    b.HasOne("PokemonUniteBuildTracker.Models.BattleItem", "BattleItem")
                        .WithMany("Pokemons")
                        .HasForeignKey("BattleItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BattleItem");
                });

            modelBuilder.Entity("PokemonUniteBuildTracker.Models.BattleItem", b =>
                {
                    b.Navigation("Pokemons");
                });
#pragma warning restore 612, 618
        }
    }
}
