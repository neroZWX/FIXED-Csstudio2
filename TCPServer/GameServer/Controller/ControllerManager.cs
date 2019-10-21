using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Reflection;
using GameServer.Servers;

namespace GameServer.Controller
{
    class ControllerManager
    {
        private Server server;
        private Dictionary<Request, baseController> controllerDict = new Dictionary<Request, baseController>();
        public ControllerManager(Server server) {
            this.server = server;
            InitController();
        }

        void InitController()
        {
            defaultController defaultController = new defaultController();
            controllerDict.Add(defaultController.Request, defaultController);
            controllerDict.Add(Request.User, new UserController());
            controllerDict.Add(Request.Room, new RoomController());


        }
        public void HandRequest(Request request, ActionCode actionCode, string data, Client client) {
            baseController controller;
            bool isGet = controllerDict.TryGetValue(request, out controller);
            if (isGet == false) {
                Console.WriteLine("cannot get" + request);
                return;
            }
            string methodName = Enum.GetName(typeof(ActionCode), actionCode);
            MethodInfo mi = controller.GetType().GetMethod(methodName);
            if (mi == null) {

                Console.WriteLine("there is no handal method[" + methodName + "] in controller[" + controller.GetType() + "]");
            }
            object[] parameters = new object[] { data, client, server };
           object o = mi.Invoke(controller, parameters);
            if (o == null || string.IsNullOrEmpty(o as string)) {
                return;
            }
            server.SendResponse(client, actionCode, o as string);
        }
    }
}
