﻿namespace logistics_system_back.Services
{
    using Microsoft.EntityFrameworkCore;
    using Abstractions;
    using DataTransferObjects;

    public class InOutInvoiceService : IInOutInvoiceService
    {
        private readonly ApplicationContext _db;

        public InOutInvoiceService(ApplicationContext context)
        {
            _db = context;
        }

        /// <inheritdoc/>
        public IEnumerable<InOutInvoiceDTO> GetInOutInvoices()
        {
            return _db.InOutInvoices
                .Include(p => p.Invoice)
                .ThenInclude(p => p.Worker)
                .Include(x => x.InDivision)
                .Include(x => x.OutDivision)
                .Select(x => new InOutInvoiceDTO(x));
        }
    }

}
