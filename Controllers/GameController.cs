using AutoMapper;
using FluentValidation;
using GameStore.Application.GameOperations.Command.Create;
using GameStore.Application.GameOperations.Query.GetBookDetail;
using GameStore.Application.GameOperations.Query.GetBooks;
using GameStore.DbOperations;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GameController : ControllerBase
    {
        private readonly GameStoreDbContext dbContext;
        private readonly IMapper mapper;

        public GameController(GameStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public List<GameModel> GetBooks()
        {
            GetBookQuery query = new(dbContext, mapper);
            var result = query.Handler();
            return result;
        }

        [HttpPost]
        public IActionResult CreateBook(CreateGameModel model)
        {
            CreateGameCommand command = new (dbContext,mapper);
            command.Model=model;
            // VALIDATIONS
            command.Handler();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            GetBookDetailQuery query = new(dbContext,mapper);
            query.GameID = id;
            GetBookDetailQueryValidator validations = new();
            validations.ValidateAndThrow(query);
            var result = query.Handler();
            return Ok(result);
        }
    }
}