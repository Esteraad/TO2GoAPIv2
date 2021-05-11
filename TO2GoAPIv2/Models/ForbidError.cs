using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TO2GoAPIv2.Models
{
    public class ForbidError
    {
        public static ForbidError GameAlreadyStarted { get { return new ForbidError { ErrorCode = 1002, Message = "Game has already started" }; } }
        public static ForbidError GameFull { get { return new ForbidError { ErrorCode = 1003, Message = "Game full" }; } }
        public static ForbidError YouAreNotAMember { get { return new ForbidError { ErrorCode = 1004, Message = "You are not a member" }; } }
        public static ForbidError NoPermission { get { return new ForbidError { ErrorCode = 1005, Message = "You have no permission to do that" }; } }
        public static ForbidError NotEnoughPlayers { get { return new ForbidError { ErrorCode = 1006, Message = "Not enough players" }; } }
        public static ForbidError NotEveryoneIsReady { get { return new ForbidError { ErrorCode = 1007, Message = "Not everyone is ready" }; } }
        public static ForbidError GameNotStartedYet { get { return new ForbidError { ErrorCode = 1008, Message = "Game has not started yet" }; } }
        public static ForbidError GameAlreadyFinished { get { return new ForbidError { ErrorCode = 1009, Message = "Game is already finished" }; } }
        public static ForbidError NotYourMove { get { return new ForbidError { ErrorCode = 1009, Message = "Not your move" }; } }

        




        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);

    }
}
