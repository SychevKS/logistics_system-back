namespace logistics_system_back.Models
{
    public class Log
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Message { get; set; }
        public string? UserName { get; set; }
    }
}
