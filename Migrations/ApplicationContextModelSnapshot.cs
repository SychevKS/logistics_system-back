﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using logistics_system_back;

#nullable disable

namespace logistics_system_back.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("logistics_system_back.Models.Division", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Kind")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("logistics_system_back.Models.InOutInvoice", b =>
                {
                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("InDivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OutDivisionId")
                        .HasColumnType("uuid");

                    b.HasKey("InvoiceId");

                    b.HasIndex("InDivisionId");

                    b.HasIndex("OutDivisionId");

                    b.ToTable("InOutInvoices");
                });

            modelBuilder.Entity("logistics_system_back.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<Guid>("WorkerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("logistics_system_back.Models.InvoicePosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CostDelivery")
                        .HasColumnType("integer");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoicePositions");
                });

            modelBuilder.Entity("logistics_system_back.Models.Partner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("Kind")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("logistics_system_back.Models.PriceList", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.ToTable("PriceList");
                });

            modelBuilder.Entity("logistics_system_back.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UnitId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("logistics_system_back.Models.PurchaseInvoice", b =>
                {
                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uuid");

                    b.HasKey("InvoiceId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("PartnerId");

                    b.ToTable("PurchaseInvoices");
                });

            modelBuilder.Entity("logistics_system_back.Models.PurchasesPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Month")
                        .HasColumnType("integer");

                    b.Property<Guid>("SalesPlanId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SalesPlanId");

                    b.ToTable("PurchasesPlans");
                });

            modelBuilder.Entity("logistics_system_back.Models.PurchasesPlanPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PurchasesPlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchasesPlanId");

                    b.ToTable("PurchasesPlanPositions");
                });

            modelBuilder.Entity("logistics_system_back.Models.PurchasesPlanRealization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PurchasesPlanId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchasesPlanId");

                    b.ToTable("PurchasesPlanRealizations");
                });

            modelBuilder.Entity("logistics_system_back.Models.Remaining", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("ProductId");

                    b.ToTable("Remainings");
                });

            modelBuilder.Entity("logistics_system_back.Models.SalesInvoice", b =>
                {
                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uuid");

                    b.HasKey("InvoiceId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("PartnerId");

                    b.ToTable("SalesInvoices");
                });

            modelBuilder.Entity("logistics_system_back.Models.SalesPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SalesPlans");
                });

            modelBuilder.Entity("logistics_system_back.Models.SalesPlanPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("SalesPlanId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SalesPlanId");

                    b.ToTable("SalesPlanPositions");
                });

            modelBuilder.Entity("logistics_system_back.Models.SalesPlanRealization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("SalesPlanId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SalesPlanId");

                    b.ToTable("SalesPlanRealizations");
                });

            modelBuilder.Entity("logistics_system_back.Models.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("logistics_system_back.Models.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("logistics_system_back.Models.InOutInvoice", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "InDivision")
                        .WithMany("InInvoices")
                        .HasForeignKey("InDivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Invoice", "Invoice")
                        .WithOne("InOuts")
                        .HasForeignKey("logistics_system_back.Models.InOutInvoice", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Division", "OutDivision")
                        .WithMany("OutInvoices")
                        .HasForeignKey("OutDivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InDivision");

                    b.Navigation("Invoice");

                    b.Navigation("OutDivision");
                });

            modelBuilder.Entity("logistics_system_back.Models.Invoice", b =>
                {
                    b.HasOne("logistics_system_back.Models.Worker", "Worker")
                        .WithMany("Invoices")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("logistics_system_back.Models.InvoicePosition", b =>
                {
                    b.HasOne("logistics_system_back.Models.Invoice", "Invoice")
                        .WithMany("InvoicePositions")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("InvoicePositions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("logistics_system_back.Models.PriceList", b =>
                {
                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithOne("PriceList")
                        .HasForeignKey("logistics_system_back.Models.PriceList", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("logistics_system_back.Models.Product", b =>
                {
                    b.HasOne("logistics_system_back.Models.Unit", "Unit")
                        .WithMany("Products")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("logistics_system_back.Models.PurchaseInvoice", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "Division")
                        .WithMany("PurchaseInvoices")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Invoice", "Invoice")
                        .WithOne("Purchase")
                        .HasForeignKey("logistics_system_back.Models.PurchaseInvoice", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Partner", "Partner")
                        .WithMany("PurchaseInvoices")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Invoice");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("logistics_system_back.Models.PurchasesPlan", b =>
                {
                    b.HasOne("logistics_system_back.Models.SalesPlan", "SalesPlan")
                        .WithMany()
                        .HasForeignKey("SalesPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalesPlan");
                });

            modelBuilder.Entity("logistics_system_back.Models.PurchasesPlanPosition", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "Division")
                        .WithMany("PurchasesPlanPositions")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("PurchasesPlanPositions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.PurchasesPlan", "PurchasesPlan")
                        .WithMany("PurchasesPlanPositions")
                        .HasForeignKey("PurchasesPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Product");

                    b.Navigation("PurchasesPlan");
                });

            modelBuilder.Entity("logistics_system_back.Models.PurchasesPlanRealization", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "Division")
                        .WithMany("PurchasesPlanRealizations")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("PurchasesPlanRealizations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.PurchasesPlan", "PurchasesPlan")
                        .WithMany("PurchasesPlanRealizations")
                        .HasForeignKey("PurchasesPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Product");

                    b.Navigation("PurchasesPlan");
                });

            modelBuilder.Entity("logistics_system_back.Models.Remaining", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "Division")
                        .WithMany("Remainings")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("Remainings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("logistics_system_back.Models.SalesInvoice", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "Division")
                        .WithMany("SalesInvoices")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Invoice", "Invoice")
                        .WithOne("Sales")
                        .HasForeignKey("logistics_system_back.Models.SalesInvoice", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Partner", "Partner")
                        .WithMany("SalesInvoices")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Invoice");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("logistics_system_back.Models.SalesPlanPosition", b =>
                {
                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("SalesPlanPositions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.SalesPlan", "SalesPlan")
                        .WithMany("PlanSalesPositions")
                        .HasForeignKey("SalesPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SalesPlan");
                });

            modelBuilder.Entity("logistics_system_back.Models.SalesPlanRealization", b =>
                {
                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("SalesPlanRealizations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.SalesPlan", "SalesPlan")
                        .WithMany("RealizationSalesPlans")
                        .HasForeignKey("SalesPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SalesPlan");
                });

            modelBuilder.Entity("logistics_system_back.Models.Division", b =>
                {
                    b.Navigation("InInvoices");

                    b.Navigation("OutInvoices");

                    b.Navigation("PurchaseInvoices");

                    b.Navigation("PurchasesPlanPositions");

                    b.Navigation("PurchasesPlanRealizations");

                    b.Navigation("Remainings");

                    b.Navigation("SalesInvoices");
                });

            modelBuilder.Entity("logistics_system_back.Models.Invoice", b =>
                {
                    b.Navigation("InOuts");

                    b.Navigation("InvoicePositions");

                    b.Navigation("Purchase");

                    b.Navigation("Sales");
                });

            modelBuilder.Entity("logistics_system_back.Models.Partner", b =>
                {
                    b.Navigation("PurchaseInvoices");

                    b.Navigation("SalesInvoices");
                });

            modelBuilder.Entity("logistics_system_back.Models.Product", b =>
                {
                    b.Navigation("InvoicePositions");

                    b.Navigation("PriceList")
                        .IsRequired();

                    b.Navigation("PurchasesPlanPositions");

                    b.Navigation("PurchasesPlanRealizations");

                    b.Navigation("Remainings");

                    b.Navigation("SalesPlanPositions");

                    b.Navigation("SalesPlanRealizations");
                });

            modelBuilder.Entity("logistics_system_back.Models.PurchasesPlan", b =>
                {
                    b.Navigation("PurchasesPlanPositions");

                    b.Navigation("PurchasesPlanRealizations");
                });

            modelBuilder.Entity("logistics_system_back.Models.SalesPlan", b =>
                {
                    b.Navigation("PlanSalesPositions");

                    b.Navigation("RealizationSalesPlans");
                });

            modelBuilder.Entity("logistics_system_back.Models.Unit", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("logistics_system_back.Models.Worker", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
