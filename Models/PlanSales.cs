namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс план продаж
    /// </summary>
    public class PlanSales
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public IEnumerable<PlanSalesPosition>? PlanSalesPositions { get; set; }
        public IEnumerable<PlanSalesRealization>? PlanSalesRealizations { get; set; }
    }
}
