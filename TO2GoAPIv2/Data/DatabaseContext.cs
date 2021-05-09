using TO2GoAPIv2.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options): base(options) {}
        

        public DbSet<Game> Games { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<GameWinner> GameWinners { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<GameStart> GameStarts { get; set; }
        public DbSet<GameFinish> GameFinishes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            //builder.ApplyConfiguration(new CountryConfiguration());
            //builder.ApplyConfiguration(new HotelConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<ApiUser>().HasIndex(u => u.Nick).IsUnique();
        }
    }
}
