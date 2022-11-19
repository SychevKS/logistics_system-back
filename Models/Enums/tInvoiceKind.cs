namespace logistics_system_back.Models
{
    /// <summary>
    /// Перечисление виды действий накладной
    /// </summary>
    public enum tInvoiceKind
    {
        /// <summary>
        /// Приход
        /// </summary>
        Purchase,

        /// <summary>
        /// Расход
        /// </summary>
        Sale,

        /// <summary>
        /// Передача
        /// </summary>
        Transfer
    }
}
