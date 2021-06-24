using eShoppingSimple.Orders.Domain.Contracts;

namespace eShoppingSimple.Orders.Domain.Implementations
{
    class Picture : IPicture
    {
        public Picture(string content)
        {
            Content = content;
        }

        public string Content { get; }
    }
}
