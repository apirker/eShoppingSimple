using System;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    /// <summary>
    /// Items need to have an id at least.
    /// </summary>
    public interface IHasId
    {
        /// <summary>
        /// Id of the item.
        /// </summary>
        Guid Id { get; set; }
    }
}
