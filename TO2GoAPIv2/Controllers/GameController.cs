using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TO2GoAPIv2.Data;
using TO2GoAPIv2.IRepository;
using TO2GoAPIv2.Models;

namespace TO2GoAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApiUser> userManager;
        private readonly ILogger<AccountController> logger;
        private readonly IMapper mapper;

        public GameController(IUnitOfWork unitOfWork, UserManager<ApiUser> userManager,
            ILogger<AccountController> logger, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.logger = logger;
            this.mapper = mapper;
        }


        [Authorize]
        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateGameDTO gameDTO) {
            if (!ModelState.IsValid) {
                logger.LogError($"Invalid POST attempt in {nameof(Create)}");
                return BadRequest(ModelState);
            }

            var game = mapper.Map<Game>(gameDTO);

            if (game.GamePlayers.Count != 1)
                return BadRequest("Provide exactly 1 GamePlayer");

            var user = await GetCurrentUser();

            game.GamePlayers[0].ApiUser = user;
            game.GamePlayers[0].ApiUserId = user.Id;
            game.GamePlayers[0].GameOwner = true;
            game.CreatedDate = DateTime.Now;


            await unitOfWork.Games.Insert(game);
            await unitOfWork.Save();

            var result = mapper.Map<GameDTO>(game);

            return CreatedAtRoute("GetGame", result);
        }


        [Authorize]
        [HttpGet("get/{id:int}", Name = "GetGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id) {
            var game = await unitOfWork.Games.Get(q => q.Id == id, new List<string> { "GamePlayers.ApiUser", "GameStart", "GameFinish", "GameWinner" });
            var result = mapper.Map<GameDTO>(game);
            return Ok(result);
        }


        [Authorize]
        [HttpPost("join/{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Join(int id) {
            var gamePlayers = await unitOfWork.GamePlayers.GetAll(q => q.GameId == id);
            if (gamePlayers.Count == 0)
                return Forbid("Game does not exist");
            if (gamePlayers.Count != 1)
                return Forbid("Game full");

            var user = await GetCurrentUser();

            var gamePlayer = new GamePlayer {
                GameId = id,
                ApiUserId = user.Id,
                BlackColor = !gamePlayers[0].BlackColor,
                GameOwner = false,
                Ready = false
            };

            await unitOfWork.GamePlayers.Insert(gamePlayer);
            await unitOfWork.Save();

            return Created("", gamePlayer);
        }


        [Authorize]
        [HttpPost("setReady/{gameId:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SetReady(int gameId) {

            var user = await GetCurrentUser();

            var gamePlayer = await unitOfWork.GamePlayers.Get(q => q.GameId == gameId && q.ApiUserId == user.Id);
            if (gamePlayer == null)
                return Forbid("You are not a member of that game or game does not exist");

            gamePlayer.Ready = true;
            unitOfWork.GamePlayers.Update(gamePlayer);
            await unitOfWork.Save();

            return Accepted();
        }


        [Authorize]
        [HttpPost("startGame/{id:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> StartGame(int id) {

            var user = await GetCurrentUser();
            var game = await unitOfWork.Games.Get(q => q.Id == id, new List<string> { "GamePlayers", "GameStart" });

            if (game == null)
                return Forbid("Game does not exist");

            if (game.GameStart != null)
                return Forbid("Game has already started");

            var isOwner = game.GamePlayers.Any(q => q.ApiUserId == user.Id && q.GameOwner == true);
            if (isOwner == false)
                return Forbid("Only game owner can start it");

            var gameStart = new GameStart {
                GameId = id,
                StartDate = DateTime.Now
            };

            await unitOfWork.GameStarts.Insert(gameStart);
            await unitOfWork.Save();

            return Accepted();
        }


        private async Task<ApiUser> GetCurrentUser() {
            ClaimsPrincipal currentUser = User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.Name).Value;
            return await userManager.FindByNameAsync(currentUserName);
        }
    }
}
