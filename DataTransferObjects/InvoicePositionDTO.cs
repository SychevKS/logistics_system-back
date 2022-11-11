namespace logistics_system_back.DataTransferObjects
{
    using Models;

    public class InvoicePositionDTO
    {
        public InvoicePositionDTO(InvoicePosition invoicePosition)
        {
            Id = invoicePosition.Id;
            Price = invoicePosition.Price;
            Quantity = invoicePosition.Quantity;
            CostDelivery = invoicePosition.CostDelivery;
            Product = invoicePosition.Product != null ? new ProductDTO(invoicePosition.Product) : null;

        }

        public Guid Id { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int CostDelivery { get; set; }
        public ProductDTO? Product { get; set; }

    }
}
