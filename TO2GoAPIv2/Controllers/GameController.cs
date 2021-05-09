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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateGameDTO gameDTO) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var game = mapper.Map<Game>(gameDTO);

            if (game.GamePlayers.Count != 1)
                return BadRequest("Provide exactly 1 GamePlayer");

            ClaimsPrincipal currentUser = User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.Name).Value;
            var user = await userManager.FindByNameAsync(currentUserName);

            //var user = await userManager.GetUserAsync(User);
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
        [HttpGet("{id:int}", Name = "GetGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id) {

            var game = await unitOfWork.Games.Get(q => q.Id == id, new List<string> { "GamePlayers.ApiUser", "GameStart", "GameFinish", "GameWinner" });
            var result = mapper.Map<GameDTO>(game);
            return Ok(result);

        }
    }
}
