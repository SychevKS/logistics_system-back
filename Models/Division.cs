namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс подразделение
    /// </summary>
    public class Division
    {
        public Guid Id { get; set;} 
        public int Number { get; set;}
        public tDivisionKind Kind { get; set;}
        public IEnumerable<InvoicePurchase>? InvoicePurchases { get; set;}
        public IEnumerable<InvoiceSale>? InvoiceSales { get; set;}
        public IEnumerable<InvoiceTransfer>? InInvoiceTransfers { get; set;}
        public IEnumerable<InvoiceTransfer>? OutInvoiceTransfers { get; set; }
        public IEnumerable<Remaining>? Remainings { get; set; }
        public IEnumerable<PlanPurchasesPosition>? PlanPurchasesPositions { get; set; }
        public IEnumerable<PlanPurchasesRealization>? PlanPurchasesRealizations { get; set; }


    }
}
