﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using TO2GoAPIv2.Data;
using TO2GoAPIv2.IRepository;
using TO2GoAPIv2.Models;

namespace TO2GoAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<ApiUser> userManager;
        private readonly ILogger<AccountController> logger;
        private readonly IMapper mapper;

        public MoveController(IUnitOfWork unitOfWork, UserManager<ApiUser> userManager,
            ILogger<AccountController> logger, IMapper mapper) {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.logger = logger;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpPost("add/{gameId:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(int gameId, [FromBody] CreateMoveDTO moveDTO) {

            if (!ModelState.IsValid) {
                logger.LogError($"Invalid POST attempt in {nameof(Add)}");
                return BadRequest(ModelState);
            }

            if (moveDTO.Type == MoveType.putStone && (moveDTO.PosX == 0 || moveDTO.PosY == 0))
                return BadRequest("if MoveType == 'PutStone' posX and posY have to be set");

            var user = await GetCurrentUser();
            var game = await unitOfWork.Games.Get(q => q.Id == gameId, new List<string> { "GamePlayers", "GameStart", "GameFinish" });

            if (game == null)
                return NotFound(gameId);

            if (game.GameStart == null)
                return ForbidWMsg(ForbidError.GameNotStartedYet);

            if (game.GameFinish != null)
                return ForbidWMsg(ForbidError.GameAlreadyFinished);

            var isMember = game.GamePlayers.Any(q => q.ApiUserId == user.Id);
            if (isMember == false)
                return ForbidWMsg(ForbidError.YouAreNotAMember);

            var gamePlayer = game.GamePlayers.FirstOrDefault(q => q.ApiUserId == user.Id);

            var moves = await unitOfWork.Moves.GetAll(q => q.GameId == gameId, m => m.OrderByDescending(x => x.Id), take: 1);

            if (moves.Count == 0) {
                if (!gamePlayer.BlackColor)
                     return ForbidWMsg(ForbidError.NotYourMove);
            } else if (moveDTO.Type != MoveType.surrender && moves[0].ApiUserId == user.Id) {
                return ForbidWMsg(ForbidError.NotYourMove);
            }

            var move = mapper.Map<Move>(moveDTO);
            move.Timestamp = DateTime.Now;
            move.GameId = gameId;
            move.ApiUserId = user.Id;

            await unitOfWork.Moves.Insert(move);
            await unitOfWork.Save();

            var result = mapper.Map<MoveDTO>(move);

            return CreatedAtRoute("GetMove", new { id = result.Id }, result);
        }


        [Authorize]
        [HttpGet("get/{id:int}", Name = "GetMove")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id) {

            var move = await unitOfWork.Moves.Get(q => q.Id == id);

            if (move == null)
                return NotFound(id);

            var user = await GetCurrentUser();
            var game = await unitOfWork.Games.Get(q => q.Id == move.GameId, new List<string> { "GamePlayers", "GameStart", "GameFinish" });

            var isMember = game.GamePlayers.Any(q => q.ApiUserId == user.Id);
            if (isMember == false)
                return ForbidWMsg(ForbidError.YouAreNotAMember);

            var result = mapper.Map<MoveDTO>(move);

            return Ok(result);
        }


        [Authorize]
        [HttpGet("get/{gameId:int}/{minMoveId:int}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int gameId, int minMoveId) {

            var user = await GetCurrentUser();
            var game = await unitOfWork.Games.Get(q => q.Id == gameId, new List<string> { "GamePlayers", "GameStart", "GameFinish" });

            if (game == null)
                return NotFound(gameId);

            if (game.GameStart == null)
                return ForbidWMsg(ForbidError.GameNotStartedYet);

            var isMember = game.GamePlayers.Any(q => q.ApiUserId == user.Id);
            if (isMember == false)
                return ForbidWMsg(ForbidError.YouAreNotAMember);

            var moves = await unitOfWork.Moves.GetAll(q => q.GameId == gameId && q.Id > minMoveId, includes: new List<string> { "ApiUser" });
            var results = mapper.Map<IList<MoveDTO>>(moves);

            return Ok(results);
        }


        private async Task<ApiUser> GetCurrentUser() {
            ClaimsPrincipal currentUser = User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.Name).Value;
            return await userManager.FindByNameAsync(currentUserName);
        }

        private ObjectResult ForbidWMsg(ForbidError forbidError) {
            return StatusCode((int)HttpStatusCode.Forbidden, forbidError);
        }
    }
}
