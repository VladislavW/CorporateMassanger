using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CorporateMassenger.Data;

namespace CorporateMessenger.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170617132413_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CorporateMassenger.Data.Mapping.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Fullname");

                    b.Property<int?>("GroupsId");

                    b.Property<string>("Phone");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.HasIndex("GroupsId");

                    b.ToTable("UserMap");
                });

            modelBuilder.Entity("CorporateMassenger.Data.Mapping.UserMassage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MassageId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MassageId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMassageMap");
                });

            modelBuilder.Entity("CorporateMessenger.Data.Mapping.Groups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName");

                    b.HasKey("Id");

                    b.ToTable("GroupsMap");
                });

            modelBuilder.Entity("CorporateMessenger.Data.Mapping.Massage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TextMassage");

                    b.HasKey("Id");

                    b.ToTable("MassageMap");
                });

            modelBuilder.Entity("CorporateMassenger.Data.Mapping.User", b =>
                {
                    b.HasOne("CorporateMessenger.Data.Mapping.Groups", "Groups")
                        .WithMany("UserList")
                        .HasForeignKey("GroupsId");
                });

            modelBuilder.Entity("CorporateMassenger.Data.Mapping.UserMassage", b =>
                {
                    b.HasOne("CorporateMessenger.Data.Mapping.Massage", "Massage")
                        .WithMany("UserMassageList")
                        .HasForeignKey("MassageId");

                    b.HasOne("CorporateMassenger.Data.Mapping.User", "User")
                        .WithMany("UserMassageList")
                        .HasForeignKey("UserId");
                });
        }
    }
}
