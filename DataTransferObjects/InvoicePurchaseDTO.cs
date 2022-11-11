namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class InvoicePurchaseDTO
    {
        public InvoicePurchaseDTO(InvoicePurchase invoicePurchase)
        {
            InvoiceId = invoicePurchase.InvoiceId;
            Date = invoicePurchase.Invoice?.Date;
            Number = invoicePurchase.Invoice?.Number;
            Worker = invoicePurchase.Invoice.Worker != null ? new WorkerDTO(invoicePurchase.Invoice.Worker) : null;
            Division = invoicePurchase.Division != null ? new DivisionDTO(invoicePurchase.Division) : null;
            Partner = invoicePurchase.Partner != null ?  new PartnerDTO(invoicePurchase.Partner) : null;
        }

        public Guid InvoiceId { get; set; }
        public DateTime? Date { get; set; }
        public string? Number { get; set; }
        public WorkerDTO? Worker { get; set; }
        public DivisionDTO? Division { get; set; }
        public PartnerDTO? Partner { get; set; }
    }
}
