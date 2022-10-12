namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс работник
    /// </summary>
    public class Worker
    {
        public Guid Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<Invoice>? Invoices { get; set; }

    }
}
