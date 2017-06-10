using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CorporateMassenger.Data;

namespace CorporateMessenger.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170610143651_Initia")]
    partial class Initia
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CorporateMassenger.Data.Mapping.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Fullname");

                    b.Property<string>("Phone");

                    b.Property<string>("Photo");

                    b.HasKey("Id");

                    b.ToTable("UserMap");
                });
        }
    }
}
