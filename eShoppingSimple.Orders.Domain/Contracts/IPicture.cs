namespace eShoppingSimple.Orders.Domain.Contracts
{
    /// <summary>
    /// Data interface for a picture of an item.
    /// </summary>
    public interface IPicture
    {
        /// <summary>
        /// String representation of the picture.
        /// </summary>
        string Content { get; }
    }
}
