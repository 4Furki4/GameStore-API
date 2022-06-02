using AutoMapper;
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
    }
}