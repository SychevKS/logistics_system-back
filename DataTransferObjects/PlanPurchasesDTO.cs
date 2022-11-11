namespace logistics_system_back.DataTransferObjects
{
    using Models;
    using DataTransferObjects;

    public class PlanPurchasesDTO
    {
        public PlanPurchasesDTO(PlanPurchases planPurchases)
        {
            Id = planPurchases.Id;
            Month = planPurchases.Month;
            PlanSales = planPurchases.PlanSales != null ? new PlanSalesDTO(planPurchases.PlanSales) : null;
        }

        public Guid Id { get; set; }
        public tMonth Month { get; set; }
        public PlanSalesDTO? PlanSales { get; set; }

    }
}
