﻿// <auto-generated />
using System;
using CentrisWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CentrisWebApi.Migrations
{
    [DbContext(typeof(CentrisDataContext))]
    [Migration("20200312033037_testimonials")]
    partial class testimonials
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("CentrisWebApi.models.Testimonials.Testimonial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTimeAdded")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAproved")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHearted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<int>("TestimonyById")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TestimonyById");

                    b.HasIndex("UserId");

                    b.ToTable("Testimonials");
                });

            modelBuilder.Entity("CentrisWebApi.models.UserAgg.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("CentrisWebApi.models.UserAgg.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AccountCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("BaptismalName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("CollegeAttended")
                        .HasColumnType("TEXT");

                    b.Property<int>("CollegeYearGraduated")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DegreeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("EyeColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("FaceBookUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<byte>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HighSchoolAttended")
                        .HasColumnType("TEXT");

                    b.Property<int>("HighSchoolYearGraduated")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescrtion")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<DateTime>("SurvivalDate")
                        .HasColumnType("TEXT");

                    b.Property<byte>("UserType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.Property<string>("username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CentrisWebApi.models.Testimonials.Testimonial", b =>
                {
                    b.HasOne("CentrisWebApi.models.UserAgg.User", "TestimonyBy")
                        .WithMany()
                        .HasForeignKey("TestimonyById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentrisWebApi.models.UserAgg.User", "User")
                        .WithMany("Testimonials")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CentrisWebApi.models.UserAgg.Photo", b =>
                {
                    b.HasOne("CentrisWebApi.models.UserAgg.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}