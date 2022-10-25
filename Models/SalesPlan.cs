﻿namespace logistics_system_back.Models
{
    /// <summary>
    /// Класс план продаж
    /// </summary>
    public class SalesPlan
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public IEnumerable<SalesPlanPosition>? SalesPlanPosition { get; set; }
        public IEnumerable<SalesPlanRealization>? SalesPlanRealization { get; set; }
    }
}
