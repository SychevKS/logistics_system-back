namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class PurchasesPlanPositionDTO
    {
        public PurchasesPlanPositionDTO(PurchasesPlanPosition purchasesPlanPosition)
        {
            Id = purchasesPlanPosition.Id;
            Quantity = purchasesPlanPosition.Quantity;
            PurchasesPlan = new PurchasesPlanDTO(purchasesPlanPosition.PurchasesPlan);
            Product = new ProductDTO(purchasesPlanPosition.Product);
            Division = new DivisionDTO(purchasesPlanPosition.Division);
        }

        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public PurchasesPlanDTO PurchasesPlan { get; set; }
        public ProductDTO Product { get; set; }
        public DivisionDTO Division { get; set; }

    }
}
