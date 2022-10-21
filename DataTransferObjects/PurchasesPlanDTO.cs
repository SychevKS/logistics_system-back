namespace logistics_system_back.DataTransferObjects
{
    using Models;
    using DataTransferObjects;

    public class PurchasesPlanDTO
    {
        public PurchasesPlanDTO(PurchasesPlan purchasesPlan)
        {
            Id = purchasesPlan.Id;
            Month = purchasesPlan.Month;
            SalesPlan = new SalesPlanDTO(purchasesPlan.SalesPlan);
        }

        public Guid Id { get; set; }
        public tMonth Month { get; set; }
        public SalesPlanDTO SalesPlan { get; set; }

    }
}
