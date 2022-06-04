using FluentValidation;

namespace GameStore.Application.GameOperations.Query.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(query=>query.GameID).GreaterThan(0);
        }
        
    }
}