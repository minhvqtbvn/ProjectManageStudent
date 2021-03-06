﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManageStudent.Models;

namespace ProjectManageStudent.Migrations
{
    [DbContext(typeof(ProjectManageStudentContext))]
    [Migration("20181223042318_initDatabase3")]
    partial class initDatabase3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectManageStudent.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDay");

                    b.Property<int>("ClassroomId");

                    b.Property<DateTime>("CreateAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<int>("Role");

                    b.Property<string>("Salt");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("ProjectManageStudent.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("ProjectManageStudent.Models.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId");

                    b.Property<float>("Assignment");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<float>("Practice");

                    b.Property<int>("Status");

                    b.Property<int>("SubjectId");

                    b.Property<float>("Theory");

                    b.Property<DateTime>("UpdateAt");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Mark");
                });

            modelBuilder.Entity("ProjectManageStudent.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdateAt");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("ProjectManageStudent.Models.Account", b =>
                {
                    b.HasOne("ProjectManageStudent.Models.Classroom", "Classroom")
                        .WithMany("Accounts")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectManageStudent.Models.Mark", b =>
                {
                    b.HasOne("ProjectManageStudent.Models.Account", "Account")
                        .WithMany("Marks")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectManageStudent.Models.Subject", "Subject")
                        .WithMany("Marks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
