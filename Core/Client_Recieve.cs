using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;

namespace JianxianC.Core
{
    public class Client_Recieve
    {
        public static void Hooks_OnRustBusterMessageReceived(RustBuster2016.API.Events.MessageReceivedEvent e)
        {
            ConsoleWindow.singleton.AddText(e.MessageByServer);
            if (e.PluginSender == "JianxianS")
            {
                ConsoleWindow.singleton.AddText(e.MessageByServer);
                string[] msg = e.MessageByServer.Split('|');
                if (msg.Length == 2 && msg[0]== "Login")
                {

                }
            }
        }
    }
}
