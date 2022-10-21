namespace logistics_system_back.DataTransferObjects
{
    using Models;
    using DataTransferObjects;

    public class PurchaseInvoiceDTO
    {
        public PurchaseInvoiceDTO(PurchaseInvoice purchaseInvoice)
        {
            InvoiceId = purchaseInvoice.InvoiceId;
            Date = purchaseInvoice.Invoice?.Date;
            Number = purchaseInvoice.Invoice?.Number;
            Worker = purchaseInvoice.Invoice?.Worker != null ? 
                new WorkerDTO(purchaseInvoice.Invoice.Worker) 
                : null;
            Division = purchaseInvoice.Division != null ?
                new DivisionDTO(purchaseInvoice.Division)
                : null;
            Partner = purchaseInvoice.Partner != null ?
                new PartnerDTO(purchaseInvoice.Partner)
                : null;
        }

        public Guid InvoiceId { get; set; }
        public DateTime? Date { get; set; }
        public string? Number { get; set; }
        public WorkerDTO? Worker { get; set; }
        public DivisionDTO? Division { get; set; }
        public PartnerDTO? Partner { get; set; }
    }
}
