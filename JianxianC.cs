using JianxianC.Core;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using UnityEngine;


namespace JianxianC
{
    public class JianxianC : RustBuster2016.API.RustBusterPlugin
    {
        private static JianxianC _inst;
        static public JianxianC Instance
        {
            get { return _inst; }
        }
        public JianxianC()
        {
            _inst = this;
        }
        public static string RunPath = System.IO.Directory.GetCurrentDirectory();
        static string zhanghao, mima;
        
        Core.Tcplinsten clienttcp = new Core.Tcplinsten();
        //侦听
        public Core.chinese chinese = new Core.chinese();
        //汉化
        Core.Window window = new Core.Window();
        //快捷面板  
        //Core.AuthMe.AuthMe AuthMe = new Core.AuthMe.AuthMe();
        //AuthMe
        Core.Zoom zoom= new Core.Zoom();
        //超级视距
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
            try
            {
                ConsoleWindow.singleton.AddText("开始载入UI");
                chinese.Load_UI();
                ConsoleWindow.singleton.AddText("开始面板");
                Custom_Panel_Load();
                ConsoleWindow.singleton.AddText("开始翻译");
                chinese.init();
                ConsoleWindow.singleton.AddText("汉化和面板");
                RustBuster2016.API.Hooks.OnRustBusterClientConsole += Hooks_OnRustBusterClientConsole;
            }
            catch (Exception err)
            {
                ConsoleWindow.singleton.AddText(err.Message);
            }
        }

        private void Hooks_OnRustBusterClientConsole(string msg)
        {
            if(msg=="zhongwen")chinese.ReChinese();
        }

        public void Custom_Panel_Load()
        {
            string[] logininfo;
            logininfo = login().Split('|');
            if (logininfo.Length < 2) ConsoleWindow.singleton.AddText("信息获取失败");
            zhanghao = logininfo[0];
            mima = logininfo[1];
            ConsoleWindow.singleton.AddText(SendMessageToServer("Login|" + zhanghao + "|" + mima));
            
            /*if (zhuce == "0") SendMessageToServer("AuthMeRegister-" + zhanghao + "-" + mima);
            else SendMessageToServer("AuthMeLogin-" + zhanghao + "-" + mima);*/
        }
        [DllImport("jianxianc.dll")]
        public static extern string login();
        [DllImport("jianxianc.dll")]
        public static extern void F2();
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    }
}