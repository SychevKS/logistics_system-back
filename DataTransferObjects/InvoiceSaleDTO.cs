namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class InvoiceSaleDTO
    {
        public InvoiceSaleDTO(InvoiceSale invoiceSales)
        {
            InvoiceId = invoiceSales.InvoiceId;
            Date = invoiceSales.Invoice?.Date;
            Number = invoiceSales.Invoice?.Number;
            Worker = invoiceSales.Invoice?.Worker != null ?
                new WorkerDTO(invoiceSales.Invoice.Worker)
                : null;
            Division = invoiceSales.Division != null ?
                new DivisionDTO(invoiceSales.Division)
                : null;
            Partner = invoiceSales.Partner != null ?
                new PartnerDTO(invoiceSales.Partner)
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
