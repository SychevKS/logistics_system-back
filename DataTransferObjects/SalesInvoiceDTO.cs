namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class SalesInvoiceDTO
    {
        public SalesInvoiceDTO(SalesInvoice salesInvoice)
        {
            InvoiceId = salesInvoice.InvoiceId;
            Date = salesInvoice.Invoice?.Date;
            Number = salesInvoice.Invoice?.Number;
            Worker = salesInvoice.Invoice?.Worker != null ?
                new WorkerDTO(salesInvoice.Invoice.Worker)
                : null;
            Division = salesInvoice.Division != null ?
                new DivisionDTO(salesInvoice.Division)
                : null;
            Partner = salesInvoice.Partner != null ?
                new PartnerDTO(salesInvoice.Partner)
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
