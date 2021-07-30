using System;

namespace eShoppingSimple.Shippings.Domain.Contracts
{
    /// <summary>
    /// Data interface of an order
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Id of the order
        /// </summary>
        Guid Id { get; }

    }
}
