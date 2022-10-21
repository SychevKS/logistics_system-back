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
        public IEnumerable<InOutInvoice>? InInvoices { get; set;}
        public IEnumerable<InOutInvoice>? OutInvoices { get; set; }
        public IEnumerable<Remaining>? Remainings { get; set; }
        public IEnumerable<PurchasesPlanPosition>? PurchasesPlanPositions { get; set; }
        public IEnumerable<PurchasesPlanRealization>? PurchasesPlanRealizations { get; set; }


    }
}
