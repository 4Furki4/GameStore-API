using FluentValidation;

namespace GameStore.Application.GameOperations.Command.Update
{
    public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
    {
        public UpdateGameCommandValidator()
        {
            RuleFor(g=>g.GameID).GreaterThan(0);
            RuleFor(g=>g.Model.Name).NotEmpty().NotEqual("string").NotNull();
            RuleFor(g=>g.Model.Price).GreaterThanOrEqualTo(0).NotNull();
            RuleFor(g=>g.Model.PublishDate).LessThan(DateTime.Now).NotEmpty().NotNull();
        }
    }
}