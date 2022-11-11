﻿namespace logistics_system_back.Abstractions
{
    using DataTransferObjects;
    using Models;

    /// <summary>
    /// Интерфейс сервиса работы с планами закупок
    /// </summary>
    public interface IPlanPurchasesService
    {
        /// <summary>
        /// Получение списка планов закупок
        /// </summary>
        /// <returns></returns>
        IEnumerable<PlanPurchasesDTO> GetPlans(Guid planSalesId);

        /// <summary>
        /// Получение плана закупок по айди
        /// </summary>
        /// <returns></returns>
        PlanPurchasesDTO? GetPlan(Guid id);

        /// <summary>
        /// Получение текущего плана закупок
        /// </summary>
        /// <returns></returns>
        PlanPurchases GetCurrentPlan(Guid invoiceId);

        /// <summary>
        /// Добавление плана закупок
        /// </summary>
        /// <param name="planPurchases"></param>
        void AddPlan(PlanPurchases planPurchases);
    }
}