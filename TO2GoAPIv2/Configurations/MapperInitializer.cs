using AutoMapper;
using TO2GoAPIv2.Data;
using TO2GoAPIv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer() {
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<ApiUser, GetUserDTO>();
            CreateMap<Game, GameDTO>().ReverseMap();
            CreateMap<Game, CreateGameDTO>().ReverseMap();
            CreateMap<Game, UpdateGameDTO>().ReverseMap();
            CreateMap<GamePlayer, CreateGamePlayerDTO>().ReverseMap();
            CreateMap<GamePlayer, GamePlayerDTO>().ReverseMap();
            CreateMap<Move, CreateMoveDTO>().ReverseMap();
            CreateMap<Move, MoveDTO>().ReverseMap();
            CreateMap<GameStart, GameStartDTO>().ReverseMap();
            CreateMap<GameFinish, GameFinishDTO>().ReverseMap();
            CreateMap<GameWinner, GameWinnerDTO>().ReverseMap();
            CreateMap<ChatMessage, CreateChatMessageDTO>().ReverseMap();
            CreateMap<ChatMessage, ChatMessageDTO>().ReverseMap();

        }
    }
}
