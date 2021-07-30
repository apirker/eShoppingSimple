using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    /// <summary>
    /// Data interface for items
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Id of the item
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Name of the item
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Price of the item
        /// </summary>
        float Price { get; }

        /// <summary>
        /// Images of the item
        /// </summary>
        IEnumerable<IPicture> Pictures { get; }
    }
}
