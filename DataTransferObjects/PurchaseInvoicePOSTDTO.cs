namespace logistics_system_back.DataTransferObjects
{
    public class PurchaseInvoicePOSTDTO
    {
        public Guid Id { get; set; }
        public Guid DivisionId { get; set; }
        public Guid PartnerId { get; set; }
        public DateTime Date { get; set; }
        public string? Number { get; set; }
        public Guid WorkerId { get; set; }
    }
}
