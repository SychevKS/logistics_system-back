namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class InOutInvoiceDTO
    {
        public InOutInvoiceDTO(InOutInvoice inOutInvoice)
        {
            InvoiceId = inOutInvoice.InvoiceId;
            Date = inOutInvoice.Invoice?.Date;
            Number = inOutInvoice.Invoice?.Number;
            Worker = inOutInvoice.Invoice?.Worker != null ?
                new WorkerDTO(inOutInvoice.Invoice.Worker)
                : null;
            InDivision = inOutInvoice.InDivision != null ?
                new DivisionDTO(inOutInvoice.InDivision)
                : null;
            OutDivision = inOutInvoice.OutDivision != null ?
                new DivisionDTO(inOutInvoice.OutDivision)
                : null;
        }

        public Guid InvoiceId { get; set; }
        public DateTime? Date { get; set; }
        public string? Number { get; set; }
        public WorkerDTO? Worker { get; set; }
        public DivisionDTO? InDivision { get; set; }
        public DivisionDTO? OutDivision { get; set; }

    }
}
