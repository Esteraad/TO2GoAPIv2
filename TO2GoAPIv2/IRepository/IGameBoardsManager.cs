using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TO2GoAPIv2.Controllers;
using TO2GoAPIv2.Logic;
using TO2GoAPIv2.Repository;

namespace TO2GoAPIv2.IRepository
{
    public interface IGameBoardsManager
    {
        public Task<GameBoard> GetGameBoard(int gameId, IUnitOfWork unitOfWork, ILogger<MoveController> logger);
    }
}
