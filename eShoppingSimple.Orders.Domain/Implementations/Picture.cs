using eShoppingSimple.Orders.Domain.Contracts;

namespace eShoppingSimple.Orders.Domain.Implementations
{
    class Picture : IPicture
    {
        public Picture(byte[] content)
        {
            Content = content;
        }

        public byte[] Content { get; }
    }
}
