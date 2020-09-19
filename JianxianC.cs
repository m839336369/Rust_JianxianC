using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;


namespace JianxianC
{
    public class JianxianC : RustBuster2016.API.RustBusterPlugin
    {
        private static JianxianC _inst;
        static public JianxianC Instance()
        {
            return _inst;
        }

        public static string RunPath = System.IO.Directory.GetCurrentDirectory();
        static string zhanghao, mima, zhuce;
        Core.Tcplinsten clienttcp = new Core.Tcplinsten();
        //侦听
        Core.chinese chinese = new Core.chinese();
        //汉化
        Core.window window = new Core.window();
        //快捷面板  
        Core.command command = new Core.command();
        //Re指令
        Core.AuthMe.AuthMe AuthMe = new Core.AuthMe.AuthMe();
        //AuthMe
        Core.Zoom zoom= new Core.Zoom();
        //超级视距
        Core.Nmap Nmap = new Core.Nmap();
        //地图
        public override string Name
        {
            get { return "JianxianC"; }
        }

        public override string Author
        {
            get { return "Jianxian"; }
        }

        public override Version Version
        {
            get { return new Version("1.0.0"); }
        }
        public override void DeInitialize()
        {

        }
        public override void Initialize()
        {
            chinese.init();
            string[] logininfo;
            logininfo = login().Split('|');
            zhanghao = logininfo[0];
            mima = logininfo[1];
            zhuce = logininfo[2];
            RustBuster2016.API.Hooks.OnRustBusterClientMove += Hooks_OnRustBusterClientMove;
        }
        
        private void Hooks_OnRustBusterClientMove(HumanController b, Character b2, int b3)
        {
            RustBuster2016.API.Hooks.OnRustBusterClientMove -= Hooks_OnRustBusterClientMove;
            chinese.init();
            if (zhuce == "0") SendMessageToServer("AuthMeRegister-" + zhanghao + "-" + mima);
            else SendMessageToServer("AuthMeLogin-" + zhanghao + "-" + mima);
        }

        [DllImport("jianxianc.dll")]
        public static extern string login();
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}