using Designer.Common.Common.Behavior;
using Designer.Common.Domain;
using Designer.Common.Validation;

namespace Designer.Common.Model.Request
{
    public class GenerateAllAvailablePositionsBindingModel : BindingModel<GenerateAllAvailablePositionsBindingModel, GenerateAllAvailablePositionsBindingModelValidator>
    {
        public Container Container { get; set; }
        public SquareTable Table { get; set; }
        public Chair Chair { get; set; }
        public int Accuracy { get; set; }
    }
}
