﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UrnaEletronica.Repository;

namespace UrnaEletronica.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UrnaEletronica.Domain.Candidate", b =>
                {
                    b.Property<int>("IdCandidate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("full_name");

                    b.Property<int>("PartyLegend")
                        .HasColumnType("int")
                        .HasColumnName("party_legend");

                    b.Property<DateTime>("RegistreDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("registre_date");

                    b.Property<string>("VicesName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("vice_name");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.HasKey("IdCandidate");

                    b.ToTable("t_candidates");
                });

            modelBuilder.Entity("UrnaEletronica.Domain.Vote", b =>
                {
                    b.Property<int>("IdVote")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCandidate")
                        .HasColumnType("int")
                        .HasColumnName("candidate_id");

                    b.Property<DateTime>("VoteDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("vote_date");

                    b.HasKey("IdVote");

                    b.ToTable("t_votes");
                });
#pragma warning restore 612, 618
        }
    }
}