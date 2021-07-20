using System.Threading.Tasks;
using Designer.Common.Domain;

namespace Designer.Common.Visitor
{
    public interface IAcceptVisitor
    {
        Task Visit(Item visitor);
    }
    
}
