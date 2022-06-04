using FluentValidation;

namespace GameStore.Application.GameOperations.Command.Create
{
    public class CreateGameCommandValidator :AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
            RuleFor(g=>g.Model.Name).MinimumLength(1).NotEmpty().NotEqual("string").NotNull();
            RuleForEach(g=>g.Model.GameDevelopers).GreaterThan(0).NotNull().NotEmpty(); // Developer-genre-writer ID cannot be 0 or lower.
            RuleForEach(g=>g.Model.GameGenres).GreaterThan(0).NotNull().NotEmpty();
            RuleForEach(g=>g.Model.GameWriters).GreaterThan(0).NotNull().NotEmpty();
            RuleFor(g=>g.Model.Price).GreaterThanOrEqualTo(0).NotNull().NotEmpty(); //Game can be free to play.
            RuleFor(g=>g.Model.PublishDate).LessThan(DateTime.Now).NotNull().NotEmpty(); //can't be default datetime value
        }
    }
}