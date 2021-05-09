using TO2GoAPIv2.Data;
using TO2GoAPIv2.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext context;
        private IGenericRepository<Game> games;
        private IGenericRepository<GamePlayer> gamePlayers;
        private IGenericRepository<GameWinner> gameWinners;
        private IGenericRepository<Move> moves;
        private IGenericRepository<GameStart> gameStarts;
        private IGenericRepository<GameFinish> gameFinishes;
        public UnitOfWork(DatabaseContext context) {
            this.context = context;
        }
        public IGenericRepository<Game> Games => games ??= new GenericRepository<Game>(context);
        public IGenericRepository<GamePlayer> GamePlayers => gamePlayers ??= new GenericRepository<GamePlayer>(context);
        public IGenericRepository<GameWinner> GameWinners => gameWinners ??= new GenericRepository<GameWinner>(context);
        public IGenericRepository<Move> Moves => moves ??= new GenericRepository<Move>(context);
        public IGenericRepository<GameStart> GameStarts => gameStarts ??= new GenericRepository<GameStart>(context);
        public IGenericRepository<GameFinish> GameFinishes => gameFinishes ??= new GenericRepository<GameFinish>(context);

        public void Dispose() {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save() {
            await context.SaveChangesAsync();
        }
    }
}
