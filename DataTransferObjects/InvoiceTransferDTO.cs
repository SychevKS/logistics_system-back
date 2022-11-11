namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class InvoiceTransferDTO
    {
        public InvoiceTransferDTO(InvoiceTransfer invoiceTransfer)
        {
            InvoiceId = invoiceTransfer.InvoiceId;
            Date = invoiceTransfer.Invoice?.Date;
            Number = invoiceTransfer.Invoice?.Number;
            Worker = invoiceTransfer.Invoice.Worker != null 
                ? new WorkerDTO(invoiceTransfer.Invoice.Worker)
                : null;
            InDivision = invoiceTransfer.InDivision != null
                ? new DivisionDTO(invoiceTransfer.InDivision)
                : null;
            OutDivision = invoiceTransfer.OutDivision != null 
                ? new DivisionDTO(invoiceTransfer.OutDivision)
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
