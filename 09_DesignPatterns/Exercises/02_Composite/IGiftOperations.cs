namespace Composite
{
    public interface IGiftOperations
    {
        void Add(BaseGift gift);

        bool Remove(BaseGift gift);
    }
}
