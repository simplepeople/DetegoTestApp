﻿// <auto-generated />
using System;
using Api.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Migrations
{
    [DbContext(typeof(ReaderContext))]
    partial class ReaderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Models.ActivateEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventTime");

                    b.Property<int?>("TagInfoId");

                    b.HasKey("Id");

                    b.HasIndex("TagInfoId");

                    b.ToTable("ActivateEvents");
                });

            modelBuilder.Entity("Api.Models.RfidReaderWrapper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("ReaderWrappers");
                });

            modelBuilder.Entity("Api.Models.TagInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivationCount");

                    b.Property<string>("RfidKey");

                    b.HasKey("Id");

                    b.ToTable("TagInfos");
                });

            modelBuilder.Entity("Api.Models.ActivateEvent", b =>
                {
                    b.HasOne("Api.Models.TagInfo", "TagInfo")
                        .WithMany("ActivateEvents")
                        .HasForeignKey("TagInfoId");
                });
#pragma warning restore 612, 618
        }
    }
}
