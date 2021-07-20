using Designer.Common.Domain;

namespace Designer.Common.Visitor
{
    public interface IVisitor
    {
        void Visit(Item item);
    }
}