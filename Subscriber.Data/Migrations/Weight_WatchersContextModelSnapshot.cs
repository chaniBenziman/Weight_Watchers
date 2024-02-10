﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Subscriber.Data;

#nullable disable

namespace Subscriber.Data.Migrations
{
    [DbContext(typeof(Weight_WatchersContext))]
    partial class Weight_WatchersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Subscriber.Data.entites.SubscribeCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BMI")
                        .HasColumnType("float");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("date");

                    b.Property<int>("Subscriber_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("date");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Subscriber_Id");

                    b.ToTable("SubscribeCard");
                });

            modelBuilder.Entity("Subscriber.Data.entites.Subscribers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subscriber");
                });

            modelBuilder.Entity("Subscriber.Data.entites.SubscribeCard", b =>
                {
                    b.HasOne("Subscriber.Data.entites.Subscribers", "Subscriber")
                        .WithMany()
                        .HasForeignKey("Subscriber_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscriber");
                });
#pragma warning restore 612, 618
        }
    }
}
