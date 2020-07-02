﻿ 
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PWABlog;

namespace PWABlog.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Autor.AutorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Categoria.CategoriaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Etiqueta.EtiquetaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Etiquetas");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Postagem.Classificacao.ClassificacaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Classificacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("PostagemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostagemId");

                    b.ToTable("Classificacoes");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Postagem.Comentario.ComentarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<int?>("ComentarioPaiId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("PostagemId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ComentarioPaiId");

                    b.HasIndex("PostagemId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Postagem.PostagemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataExibicao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(640) CHARACTER SET utf8mb4")
                        .HasMaxLength(640);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Postagens");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Postagem.PostagemEtiquetaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("EtiquetaId")
                        .HasColumnType("int");

                    b.Property<int?>("PostagemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EtiquetaId");

                    b.HasIndex("PostagemId");

                    b.ToTable("PostagensEtiquetas");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Postagem.Revisao.RevisaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("PostagemId")
                        .HasColumnType("int");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<int>("Versao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostagemId");

                    b.ToTable("Revisoes");
                });
 
         

            

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("PWABlog.Models.ControleDeAcesso.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("PWABlog.Models.ControleDeAcesso.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("PWABlog.Models.ControleDeAcesso.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Etiqueta.EtiquetaEntity", b =>
                {
                    b.HasOne("PWABlog.Models.Blog.Categoria.CategoriaEntity", "Categoria")
                        .WithMany("Etiquetas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Postagem.Classificacao.ClassificacaoEntity", b =>
                {
                    b.HasOne("PWABlog.Models.Blog.Postagem.PostagemEntity", "Postagem")
                        .WithMany("Classificacoes")
                        .HasForeignKey("PostagemId");
                });

             

            modelBuilder.Entity("PWABlog.Models.Blog.Postagem.PostagemEntity", b =>
                {
                    b.HasOne("PWABlog.Models.Blog.Autor.AutorEntity", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId");

                    b.HasOne("PWABlog.Models.Blog.Categoria.CategoriaEntity", "Categoria")
                        .WithMany("Postagens")
                        .HasForeignKey("CategoriaId");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Postagem.PostagemEtiquetaEntity", b =>
                {
                    b.HasOne("PWABlog.Models.Blog.Etiqueta.EtiquetaEntity", "Etiqueta")
                        .WithMany("PostagensEtiquetas")
                        .HasForeignKey("EtiquetaId");

                    b.HasOne("PWABlog.Models.Blog.Postagem.PostagemEntity", "Postagem")
                        .WithMany("PostagensEtiquetas")
                        .HasForeignKey("PostagemId");
                });

            modelBuilder.Entity("PWABlog.Models.Blog.Postagem.Revisao.RevisaoEntity", b =>
                {
                    b.HasOne("PWABlog.Models.Blog.Postagem.PostagemEntity", "Postagem")
                        .WithMany("Revisoes")
                        .HasForeignKey("PostagemId");
                });
#pragma warning restore 612, 618
        }
    }
}
