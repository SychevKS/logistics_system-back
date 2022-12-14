namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс приемно-передачная накладная
    /// </summary>
    public class InvoiceTransfer
    {
        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public Guid OutDivisionId { get; set; }
        public Division? OutDivision { get; set; }
        public Guid InDivisionId { get; set; }
        public Division? InDivision { get; set; }

    }
}
