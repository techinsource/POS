﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POSAnventory.Models;

namespace POSManagement.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190720053846_POSma")]
    partial class POSma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("POSAnventory.Models.Itemd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<double>("Cost_Price");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("LineItemDefinitionId");

                    b.Property<string>("Name");

                    b.Property<double>("Retail_Price");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("LineItemDefinitionId");

                    b.ToTable("Itemds");
                });

            modelBuilder.Entity("POSAnventory.Models.Items.Categorys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<string>("Comments");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("LineItemDefinitionId");

                    b.Property<string>("Name");

                    b.Property<int>("Sortorder");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("LineItemDefinitionId");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("POSAnventory.Models.Items.ItemGroups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<string>("Comments");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("LineItemDefinitionId");

                    b.Property<string>("Name");

                    b.Property<int>("SortItem");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("LineItemDefinitionId");

                    b.ToTable("ItemGroups");
                });

            modelBuilder.Entity("POSAnventory.Models.Items.Item_Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("LineItemDefinitionId");

                    b.Property<string>("Name");

                    b.Property<int>("Sortorder");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("LineItemDefinitionId");

                    b.ToTable("Item_Templates");
                });

            modelBuilder.Entity("POSAnventory.Models.Items.Sub_Categorys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<int>("Code");

                    b.Property<string>("Comments");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("Sortorder");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Sub_Categorys");
                });

            modelBuilder.Entity("POSAnventory.Models.LineItemDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Barcode");

                    b.Property<string>("Comments");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("Sortorder");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("LineItemDefinitions");
                });

            modelBuilder.Entity("POSAnventory.Models.Itemd", b =>
                {
                    b.HasOne("POSAnventory.Models.LineItemDefinition", "LineItemDefinition")
                        .WithMany()
                        .HasForeignKey("LineItemDefinitionId");
                });

            modelBuilder.Entity("POSAnventory.Models.Items.Categorys", b =>
                {
                    b.HasOne("POSAnventory.Models.LineItemDefinition", "LineItemDefinition")
                        .WithMany()
                        .HasForeignKey("LineItemDefinitionId");
                });

            modelBuilder.Entity("POSAnventory.Models.Items.ItemGroups", b =>
                {
                    b.HasOne("POSAnventory.Models.LineItemDefinition", "LineItemDefinition")
                        .WithMany()
                        .HasForeignKey("LineItemDefinitionId");
                });

            modelBuilder.Entity("POSAnventory.Models.Items.Item_Template", b =>
                {
                    b.HasOne("POSAnventory.Models.LineItemDefinition", "LineItemDefinition")
                        .WithMany()
                        .HasForeignKey("LineItemDefinitionId");
                });

            modelBuilder.Entity("POSAnventory.Models.Items.Sub_Categorys", b =>
                {
                    b.HasOne("POSAnventory.Models.Items.Categorys", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
