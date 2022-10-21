namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class PurchasesPlanRealizationDTO
    {
        public PurchasesPlanRealizationDTO(PurchasesPlanRealization purchasesPlanRealization)
        {
            Id = purchasesPlanRealization.Id;
            Date = purchasesPlanRealization.Date;
            Quantity = purchasesPlanRealization.Quantity;
            PurchasesPlan = new PurchasesPlanDTO(purchasesPlanRealization.PurchasesPlan);
            Product = new ProductDTO(purchasesPlanRealization.Product);
            Division = new DivisionDTO(purchasesPlanRealization.Division);
        }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public PurchasesPlanDTO PurchasesPlan { get; set; }
        public ProductDTO Product { get; set; }
        public DivisionDTO Division { get; set; }

    }
}
