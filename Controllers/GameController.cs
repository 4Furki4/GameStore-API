using AutoMapper;
using FluentValidation;
using GameStore.Application.GameOperations.Command.Create;
using GameStore.Application.GameOperations.Command.Delete;
using GameStore.Application.GameOperations.Command.Update;
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
        public List<GameModel> GetGames()
        {
            GetBookQuery query = new(dbContext, mapper);
            var result = query.Handler();
            return result;
        }

        [HttpPost]
        public IActionResult CreateGame(CreateGameModel model)
        {
            CreateGameCommand command = new (dbContext);
            command.Model=model;

            CreateGameCommandValidator validations = new();  // VALIDATIONS
            validations.ValidateAndThrow(command);

            command.Handler();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            GetBookDetailQuery query = new(dbContext,mapper);
            query.GameID = id;
            GetBookDetailQueryValidator validations = new();
            validations.ValidateAndThrow(query);
            var result = query.Handler();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, UpdateGameModel model)
        {
            UpdateGameCommand command = new(dbContext);
            UpdateGameCommandValidator validations = new();
            command.GameID=id;
            command.Model=model;
            validations.ValidateAndThrow(command);
            command.Handler();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            DeleteGameCommand command = new(dbContext);
            DeleteGameCommandValidator validations = new();
            command.GameID=id;
            validations.ValidateAndThrow(command);
            command.Handler();
            return Ok();
        }
    }
}