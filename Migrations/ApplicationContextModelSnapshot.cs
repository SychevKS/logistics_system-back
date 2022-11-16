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

            modelBuilder.Entity("logistics_system_back.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

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

            modelBuilder.Entity("logistics_system_back.Models.InvoicePurchase", b =>
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

                    b.ToTable("InvoicePurchases");
                });

            modelBuilder.Entity("logistics_system_back.Models.InvoiceSale", b =>
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

                    b.ToTable("InvoiceSales");
                });

            modelBuilder.Entity("logistics_system_back.Models.InvoiceTransfer", b =>
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

                    b.ToTable("InvoiceTransfers");
                });

            modelBuilder.Entity("logistics_system_back.Models.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Logs");
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

            modelBuilder.Entity("logistics_system_back.Models.PlanPurchases", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Month")
                        .HasColumnType("integer");

                    b.Property<Guid>("PlanSalesId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlanSalesId");

                    b.ToTable("PlansPurchases");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanPurchasesPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlanPurchasesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("PlanPurchasesId");

                    b.HasIndex("ProductId");

                    b.ToTable("PlanPurchasesPositions");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanPurchasesRealization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("DivisionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlanPurchasesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("PlanPurchasesId");

                    b.HasIndex("ProductId");

                    b.ToTable("PlanPurchasesRealizations");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanSales", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PlansSales");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanSalesPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlanSalesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlanSalesId");

                    b.HasIndex("ProductId");

                    b.ToTable("PlanSalesPositions");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanSalesRealization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("PlanSalesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlanSalesId");

                    b.HasIndex("ProductId");

                    b.ToTable("PlanSalesRealizations");
                });

            modelBuilder.Entity("logistics_system_back.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<Guid>("UnitId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("logistics_system_back.Models.Remaining", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

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

            modelBuilder.Entity("logistics_system_back.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("logistics_system_back.Models.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Workers");
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

            modelBuilder.Entity("logistics_system_back.Models.InvoicePurchase", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "Division")
                        .WithMany("InvoicePurchases")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Invoice", "Invoice")
                        .WithOne("Purchase")
                        .HasForeignKey("logistics_system_back.Models.InvoicePurchase", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Partner", "Partner")
                        .WithMany("InvoicePurchases")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Invoice");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("logistics_system_back.Models.InvoiceSale", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "Division")
                        .WithMany("InvoiceSales")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Invoice", "Invoice")
                        .WithOne("Sale")
                        .HasForeignKey("logistics_system_back.Models.InvoiceSale", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Partner", "Partner")
                        .WithMany("InvoiceSales")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Invoice");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("logistics_system_back.Models.InvoiceTransfer", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "InDivision")
                        .WithMany("InInvoiceTransfers")
                        .HasForeignKey("InDivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Invoice", "Invoice")
                        .WithOne("Transfer")
                        .HasForeignKey("logistics_system_back.Models.InvoiceTransfer", "InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Division", "OutDivision")
                        .WithMany("OutInvoiceTransfers")
                        .HasForeignKey("OutDivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InDivision");

                    b.Navigation("Invoice");

                    b.Navigation("OutDivision");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanPurchases", b =>
                {
                    b.HasOne("logistics_system_back.Models.PlanSales", "PlanSales")
                        .WithMany()
                        .HasForeignKey("PlanSalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanSales");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanPurchasesPosition", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "Division")
                        .WithMany("PlanPurchasesPositions")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.PlanPurchases", "PlanPurchases")
                        .WithMany("PlanPurchasesPositions")
                        .HasForeignKey("PlanPurchasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("PlanPurchasesPositions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("PlanPurchases");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanPurchasesRealization", b =>
                {
                    b.HasOne("logistics_system_back.Models.Division", "Division")
                        .WithMany("PlanPurchasesRealizations")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.PlanPurchases", "PlanPurchases")
                        .WithMany("PlanPurchasesRealizations")
                        .HasForeignKey("PlanPurchasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("PlanPurchasesRealizations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("PlanPurchases");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanSalesPosition", b =>
                {
                    b.HasOne("logistics_system_back.Models.PlanSales", "PlanSales")
                        .WithMany("PlanSalesPositions")
                        .HasForeignKey("PlanSalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("PlanSalesPositions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanSales");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanSalesRealization", b =>
                {
                    b.HasOne("logistics_system_back.Models.PlanSales", "PlanSales")
                        .WithMany("PlanSalesRealizations")
                        .HasForeignKey("PlanSalesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("logistics_system_back.Models.Product", "Product")
                        .WithMany("PlanSalesRealizations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanSales");

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

            modelBuilder.Entity("logistics_system_back.Models.Division", b =>
                {
                    b.Navigation("InInvoiceTransfers");

                    b.Navigation("InvoicePurchases");

                    b.Navigation("InvoiceSales");

                    b.Navigation("OutInvoiceTransfers");

                    b.Navigation("PlanPurchasesPositions");

                    b.Navigation("PlanPurchasesRealizations");

                    b.Navigation("Remainings");
                });

            modelBuilder.Entity("logistics_system_back.Models.Invoice", b =>
                {
                    b.Navigation("InvoicePositions");

                    b.Navigation("Purchase");

                    b.Navigation("Sale");

                    b.Navigation("Transfer");
                });

            modelBuilder.Entity("logistics_system_back.Models.Partner", b =>
                {
                    b.Navigation("InvoicePurchases");

                    b.Navigation("InvoiceSales");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanPurchases", b =>
                {
                    b.Navigation("PlanPurchasesPositions");

                    b.Navigation("PlanPurchasesRealizations");
                });

            modelBuilder.Entity("logistics_system_back.Models.PlanSales", b =>
                {
                    b.Navigation("PlanSalesPositions");

                    b.Navigation("PlanSalesRealizations");
                });

            modelBuilder.Entity("logistics_system_back.Models.Product", b =>
                {
                    b.Navigation("InvoicePositions");

                    b.Navigation("PlanPurchasesPositions");

                    b.Navigation("PlanPurchasesRealizations");

                    b.Navigation("PlanSalesPositions");

                    b.Navigation("PlanSalesRealizations");

                    b.Navigation("Remainings");
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
