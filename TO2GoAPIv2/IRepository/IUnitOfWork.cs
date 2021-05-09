using TO2GoAPIv2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.IRepository
{
    public interface IUnitOfWork : IDisposable {
        IGenericRepository<Game> Games { get; } 
        IGenericRepository<GamePlayer> GamePlayers { get; }
        IGenericRepository<GameWinner> GameWinners { get; }
        IGenericRepository<Move> Moves { get; }
        IGenericRepository<GameStart> GameStarts { get; }
        IGenericRepository<GameFinish> GameFinishes { get; }

        Task Save();
    }
}
