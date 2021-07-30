using System;

namespace eShoppingSimple.Shippings.Domain.Contracts
{
    /// <summary>
    /// Data interface of an item
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Id of the item
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Weight of the item
        /// </summary>
        float Weight { get; }

        /// <summary>
        /// Order of the item
        /// </summary>
        IOrder Order { get; }
    }
}
