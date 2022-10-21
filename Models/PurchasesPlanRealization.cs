﻿namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс выполения плана закупок
    /// </summary>
    public class PurchasesPlanRealization
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public Guid PurchasesPlanId { get; set; }
        public PurchasesPlan PurchasesPlan { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid DivisionId { get; set; }
        public Division Division { get; set; }

    }
}