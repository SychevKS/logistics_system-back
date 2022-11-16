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
        public DbSet<InvoicePurchase> InvoicePurchases { get; set; } = null!;
        public DbSet<InvoiceSale> InvoiceSales { get; set; } = null!;
        public DbSet<InvoiceTransfer> InvoiceTransfers { get; set; } = null!;
        public DbSet<PlanPurchases> PlansPurchases { get; set; } = null!;
        public DbSet<PlanPurchasesPosition> PlanPurchasesPositions { get; set; } = null!;
        public DbSet<PlanPurchasesRealization> PlanPurchasesRealizations { get; set; } = null!;
        public DbSet<PlanSales> PlansSales { get; set; } = null!;
        public DbSet<PlanSalesPosition> PlanSalesPositions { get; set; } = null!;
        public DbSet<PlanSalesRealization> PlanSalesRealizations { get; set; } = null!;
        public DbSet<Remaining> Remainings { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Log> Logs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoicePurchase>()
                .HasKey(l => l.InvoiceId);

            modelBuilder.Entity<InvoiceSale>()
                .HasKey(l => l.InvoiceId);

            modelBuilder.Entity<InvoiceTransfer>()
                .HasKey(l => l.InvoiceId);

            modelBuilder.Entity<InvoiceTransfer>()
                .HasOne(g => g.InDivision)
                .WithMany(t => t.InInvoiceTransfers)
                .HasForeignKey(t => t.InDivisionId);

            modelBuilder.Entity<InvoiceTransfer>()
                .HasOne(g => g.OutDivision)
                .WithMany(t => t.OutInvoiceTransfers)
                .HasForeignKey(t => t.OutDivisionId);

        }
    }
}
