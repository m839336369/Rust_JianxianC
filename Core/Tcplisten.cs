using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography;
using RustBuster2016;
using RustBuster2016.API;
using RustBuster2016.API.Events;
using Hooks = RustBuster2016.API.Hooks;
using System.Text;

namespace JianxianC
{
    class clienttcp
    {

        private static System.Net.Sockets.Socket server;
        public static System.Net.Sockets.Socket Client;
        public static byte[] qqq;        
        public clienttcp()
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 10086);
            server = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(localEP);
            server.Listen(20);         
            new Thread(new ThreadStart(TcpListen)).Start();
        }

        public static void TcpListen()
        {
            try
            {
                while (true)
                {
                    System.Net.Sockets.Socket k = server.Accept();
                    ClientThread @object = new ClientThread(k);
                    Thread thread = new Thread(new ThreadStart(@object.ClientService));
                    thread.Start();
                }
            }
            catch
            {
            }
        }
        private class ClientThread
        {            
            public System.Net.Sockets.Socket client;
            private int i;
            public float cd = 1f;
            public ClientThread(System.Net.Sockets.Socket k)
            {
                this.client = k;
                Client = k;
            }
            public void ClientService()
            {
                byte[] array = new byte[4096];
                try
                {
                    while ((this.i = this.client.Receive(array)) != 0 && this.i >= 0)
                    {
                        bool flag = array.Length > 4096;
                        if (flag)
                        {
                            qqq = array;
                        }
                        string @string = Encoding.Default.GetString(array, 0, this.i);
                        string text = @string;
                        string[] array2 = text.Split(new char[]
                        {
                            '|'
                        });
                        bool flag2 = array2.Length >= 1;
                        if (flag2)
                        {
                            bool flag3 = array2[0] == "0";
                            if (flag3)
                            {
                                ConsoleSystem.Run(array2[1], false);
                            }
                            else
                            {
                                bool flag4 = array2[0] == "1";
                                if (flag4)
                                {
                                                                        
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
