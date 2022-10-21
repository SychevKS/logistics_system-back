namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class PurchaseInvoiceDTO
    {
        public PurchaseInvoiceDTO(PurchaseInvoice purchaseInvoice)
        {
            InvoiceId = purchaseInvoice.InvoiceId;
            Date = purchaseInvoice.Invoice?.Date;
            Number = purchaseInvoice.Invoice?.Number;
            Worker = new WorkerDTO(purchaseInvoice.Invoice.Worker);
            Division = new DivisionDTO(purchaseInvoice.Division);
            Partner = new PartnerDTO(purchaseInvoice.Partner);
        }

        public Guid InvoiceId { get; set; }
        public DateTime? Date { get; set; }
        public string? Number { get; set; }
        public WorkerDTO Worker { get; set; }
        public DivisionDTO Division { get; set; }
        public PartnerDTO Partner { get; set; }
    }
}
