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
    public class ChatController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApiUser> userManager;
        private readonly ILogger<AccountController> logger;
        private readonly IMapper mapper;

        public ChatController(IUnitOfWork unitOfWork, UserManager<ApiUser> userManager,
            ILogger<AccountController> logger, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.logger = logger;
            this.mapper = mapper;
        }


        [Authorize]
        [HttpPost("add/{gameId:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(int gameId, [FromBody] CreateChatMessageDTO chatMessageDTO) {

            if (!ModelState.IsValid) {
                logger.LogError($"Invalid POST attempt in {nameof(Add)}");
                return BadRequest(ModelState);
            }

            var user = await GetCurrentUser();
            var game = await unitOfWork.Games.Get(q => q.Id == gameId, new List<string> { "GamePlayers", "GameStart", "GameFinish" });

            if(game == null)
                return Forbid("Game does not exist");

            if (game.GameStart == null)
                return Forbid("Game has not started yet");

            if (game.GameFinish != null)
                return Forbid("Game is already finished");

            var isMember = game.GamePlayers.Any(q => q.ApiUserId == user.Id);
            if (isMember == false)
                return Forbid("You are not a member of that game");

            var chatMessage = mapper.Map<ChatMessage>(chatMessageDTO);
            chatMessage.Timestamp = DateTime.Now;
            chatMessage.ApiUserId = user.Id;
            chatMessage.GameId = gameId;

            await unitOfWork.ChatMessages.Insert(chatMessage);
            await unitOfWork.Save();

            var result = mapper.Map<ChatMessageDTO>(chatMessage);

            return CreatedAtRoute("GetChatMessage", result);
        }

        [Authorize]
        [HttpGet("get/{id:int}", Name = "GetChatMessage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id) {

            var chatMessage = await unitOfWork.ChatMessages.Get(q => q.Id == id);

            if (chatMessage == null)
                return Forbid("ChatMessage does not exist");

            var user = await GetCurrentUser();
            var game = await unitOfWork.Games.Get(q => q.Id == chatMessage.GameId, new List<string> { "GamePlayers", "GameStart", "GameFinish" });

            var isMember = game.GamePlayers.Any(q => q.ApiUserId == user.Id);
            if (isMember == false)
                return Forbid("You are not a member of that game");
            
            var result = mapper.Map<ChatMessageDTO>(chatMessage);

            return Ok(result);
        }


        [Authorize]
        [HttpGet("get/{gameId:int}/{minChatMessageId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int gameId, int minChatMessageId) {

            var user = await GetCurrentUser();
            var game = await unitOfWork.Games.Get(q => q.Id == gameId, new List<string> { "GamePlayers", "GameStart", "GameFinish" });

            if (game == null)
                return Forbid("Game does not exist");

            if (game.GameStart == null)
                return Forbid("Game has not started yet");

            var isMember = game.GamePlayers.Any(q => q.ApiUserId == user.Id);
            if (isMember == false)
                return Forbid("You are not a member of that game");

            var chatMessages = unitOfWork.ChatMessages.GetAll(q => q.GameId == gameId && q.Id > minChatMessageId, includes: new List<string> { "ApiUser" });
            var results = mapper.Map<IList<ChatMessageDTO>>(chatMessages);

            return Ok(results);
        }


        private async Task<ApiUser> GetCurrentUser() {
            ClaimsPrincipal currentUser = User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.Name).Value;
            return await userManager.FindByNameAsync(currentUserName);
        }
    }
}
