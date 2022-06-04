using FluentValidation;

namespace GameStore.Application.GameOperations.Command.Delete
{
    public class DeleteGameCommandValidator :AbstractValidator<DeleteGameCommand>
    {
        public DeleteGameCommandValidator()
        {
            RuleFor(g=>g.GameID).GreaterThan(0);
        }
    }
}