using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Servers
{
    enum RoomState {
        WaitingJoin,
        waitingBattle,
        Battle,
        End,

    }
    class Room
    {
        private List<client> clientRoom = new List<client>();
        private RoomState state = RoomState.WaitingJoin;
        
    }
}
