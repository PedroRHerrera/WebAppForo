﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppForo.Context;

#nullable disable

namespace WebAppForo.Migrations
{
    [DbContext(typeof(WebAppDatabaseContext))]
    [Migration("20231121205907_Cambio1")]
    partial class Cambio1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebAppForo.Models.Juego", b =>
                {
                    b.Property<int>("JuegoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JuegoId"), 1L, 1);

                    b.Property<string>("DescJuego")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImgJuego")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NombreJuego")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Posicion")
                        .HasColumnType("int");

                    b.HasKey("JuegoId");

                    b.ToTable("Juegos");
                });

            modelBuilder.Entity("WebAppForo.Models.Mensaje", b =>
                {
                    b.Property<int>("MsgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MsgId"), 1L, 1);

                    b.Property<string>("Imagen")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MsgId");

                    b.HasIndex("UserId");

                    b.ToTable("Mensajes");
                });

            modelBuilder.Entity("WebAppForo.Models.Usuario", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("UserMail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebAppForo.Models.Mensaje", b =>
                {
                    b.HasOne("WebAppForo.Models.Usuario", "User")
                        .WithMany("Mensajes")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAppForo.Models.Usuario", b =>
                {
                    b.Navigation("Mensajes");
                });
#pragma warning restore 612, 618
        }
    }
}
