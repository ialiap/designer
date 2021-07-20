using Designer.Common.Model.Request;
using FluentValidation;

namespace Designer.Common.Validation
{
    public class GenerateAllAvailablePositionsBindingModelValidator : AbstractValidator<GenerateAllAvailablePositionsBindingModel>
    {
        public GenerateAllAvailablePositionsBindingModelValidator()
        {
            RuleFor(x => x.Container).NotNull().NotEmpty();
            RuleFor(x => x.Container.Width).GreaterThan(0);
            RuleFor(x => x.Container.Length).GreaterThan(0);
            RuleFor(x => x.Table).NotNull().NotEmpty();
            RuleFor(x => x.Table.Width).GreaterThan(0);
            RuleFor(x => x.Table.Length).GreaterThan(0);
            RuleFor(x => x.Chair).NotNull().NotEmpty();
            RuleFor(x => x.Chair.Width).GreaterThan(0);
            RuleFor(x => x.Chair.Length).GreaterThan(0);
        }
    }

}
