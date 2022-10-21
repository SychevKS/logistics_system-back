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
            Worker = new WorkerDTO(inOutInvoice.Invoice.Worker);
            InDivision = new DivisionDTO(inOutInvoice.InDivision);
            OutDivision = new DivisionDTO(inOutInvoice.OutDivision);
        }

        public Guid InvoiceId { get; set; }
        public DateTime? Date { get; set; }
        public string? Number { get; set; }
        public WorkerDTO Worker { get; set; }
        public DivisionDTO InDivision { get; set; }
        public DivisionDTO OutDivision { get; set; }

    }
}
