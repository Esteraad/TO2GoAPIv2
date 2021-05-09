using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TO2GoAPIv2.Data;

namespace TO2GoAPIv2.Models
{
    public class CreateGameDTO
    {
        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Game name is too long")]
        public string Name { get; set; }
        [Required]
        public IList<CreateGamePlayerDTO> GamePlayers { get; set; }
        [Required]
        public BoardSize BoardSize { get; set; }
        [Required]
        public int TimeLimit { get; set; }
    }

    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<GamePlayerDTO> GamePlayers { get; set; }
        public BoardSize BoardSize { get; set; }
        public int TimeLimit { get; set; }
        public DateTime CreatedDate { get; set; }
        public GameStartDTO GameStart { get; set; }
        public GameFinishDTO GameFinish { get; set; }
        public GameWinnerDTO GameWinner { get; set; }
    }

    public class UpdateGameDTO : CreateGameDTO {}

}
