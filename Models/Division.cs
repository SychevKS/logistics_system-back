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
        public IEnumerable<PurchaseInvoice>? PurchaseInvoices { get; set;}
        public IEnumerable<SalesInvoice>? SalesInvoices { get; set;}
        public IEnumerable<InOutInvoice>? InOutInvoices { get; set;}
        public IEnumerable<Remaining>? Remainings { get; set; }
        public IEnumerable<PlanPurchasesPosition>? PlanPurchasesPisitions { get; set; }
        public IEnumerable<PlanPurchasesRealization>? PlanPurchasesRealizations { get; set; }


    }
}
