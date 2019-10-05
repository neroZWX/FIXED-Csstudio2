﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Servers;

namespace GameServer.Controller
{
    abstract class baseController
    {
        Request request = Request.None;
        public Request Request {
            get { return request; }
        }
        public virtual string DefaultHandle(string data,client client, Server server) {
            return null;
        }
    }
}
