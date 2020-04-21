﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VJ.MyAirport.EF;

namespace VJ.MyAirport.EF.Migrations
{
    [DbContext(typeof(MyAirportContext))]
    [Migration("20200228154515_FirstCreate")]
    partial class FirstCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VJ.MyAirport.EF.Bagage", b =>
                {
                    b.Property<int>("BagageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Classe")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("CodeIata")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Escale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Prioritaire")
                        .HasColumnType("bit");

                    b.Property<string>("Ssur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sta")
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("VolId")
                        .HasColumnType("int");

                    b.HasKey("BagageID");

                    b.HasIndex("VolId");

                    b.ToTable("Bagages");
                });

            modelBuilder.Entity("VJ.MyAirport.EF.Vol", b =>
                {
                    b.Property<int>("VolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Des")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dhc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lig")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Pax")
                        .HasColumnType("int");

                    b.Property<string>("Pkg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VolId");

                    b.ToTable("Vols");
                });

            modelBuilder.Entity("VJ.MyAirport.EF.Bagage", b =>
                {
                    b.HasOne("VJ.MyAirport.EF.Vol", "Vol")
                        .WithMany()
                        .HasForeignKey("VolId");
                });
#pragma warning restore 612, 618
        }
    }
}
