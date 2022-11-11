namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class PlanSalesDTO
    {
        public PlanSalesDTO(PlanSales planSales)
        {
            Id = planSales.Id;
            Year = planSales.Year;
        }

        public Guid Id { get; set; }
        public int Year { get; set; }

    }
}
