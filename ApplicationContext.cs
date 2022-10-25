namespace logistics_system_back
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        public DbSet<Division> Divisions { get; set; } = null!;
        public DbSet<Partner> Partners { get; set; } = null!;
        public DbSet<Worker> Workers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<Invoice> Invoices { get; set; } = null!;
        public DbSet<InvoicePosition> InvoicePositions { get; set; } = null!;
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; } = null!;
        public DbSet<SalesInvoice> SalesInvoices { get; set; } = null!;
        public DbSet<TransferInvoice> TransferInvoices { get; set; } = null!;
        public DbSet<PurchasesPlan> PurchasesPlans { get; set; } = null!;
        public DbSet<PurchasesPlanPosition> PurchasesPlanPositions { get; set; } = null!;
        public DbSet<PurchasesPlanRealization> PurchasesPlanRealizations { get; set; } = null!;
        public DbSet<SalesPlan> SalesPlans { get; set; } = null!;
        public DbSet<SalesPlanPosition> SalesPlanPositions { get; set; } = null!;
        public DbSet<SalesPlanRealization> SalesPlanRealizations { get; set; } = null!;
        public DbSet<Remaining> Remainings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseInvoice>()
                .HasKey(l => l.InvoiceId);

            modelBuilder.Entity<SalesInvoice>()
                .HasKey(l => l.InvoiceId);

            modelBuilder.Entity<TransferInvoice>()
                .HasKey(l => l.InvoiceId);

            modelBuilder.Entity<TransferInvoice>()
                .HasOne(g => g.InDivision)
                .WithMany(t => t.TransferInInvoices)
                .HasForeignKey(t => t.InDivisionId);

            modelBuilder.Entity<TransferInvoice>()
                .HasOne(g => g.OutDivision)
                .WithMany(t => t.TransferOutInvoices)
                .HasForeignKey(t => t.OutDivisionId);

        }
    }
}
