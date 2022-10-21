namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class SalesPlanDTO
    {
        public SalesPlanDTO(SalesPlan salesPlan)
        {
            Id = salesPlan.Id;
            Year = salesPlan.Year;
        }

        public Guid Id { get; set; }
        public int Year { get; set; }

    }
}
