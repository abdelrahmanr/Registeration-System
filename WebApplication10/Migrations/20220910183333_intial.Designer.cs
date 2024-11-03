﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication10.Model;

namespace WebApplication10.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20220910183333_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication10.Model.RegForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RegForms");
                });

            modelBuilder.Entity("WebApplication10.Model.RegFormItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RegFormId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegFormId");

                    b.HasIndex("SubjectId");

                    b.ToTable("RegFormItems");
                });

            modelBuilder.Entity("WebApplication10.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegFormId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegFormId")
                        .IsUnique()
                        .HasFilter("[RegFormId] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApplication10.Model.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WebApplication10.Model.RegFormItem", b =>
                {
                    b.HasOne("WebApplication10.Model.RegForm", "RegForm")
                        .WithMany("Items")
                        .HasForeignKey("RegFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication10.Model.Subject", "Subject")
                        .WithMany("Items")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RegForm");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WebApplication10.Model.Student", b =>
                {
                    b.HasOne("WebApplication10.Model.RegForm", "RegForm")
                        .WithOne("Student")
                        .HasForeignKey("WebApplication10.Model.Student", "RegFormId");

                    b.Navigation("RegForm");
                });

            modelBuilder.Entity("WebApplication10.Model.RegForm", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebApplication10.Model.Subject", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
