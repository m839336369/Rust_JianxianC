using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
namespace JianxianC.Core
{
    class window:MonoBehaviour
    {

        private bool ShowAim;
        public Texture2D Taskelis;
        public Texture2D ButtonOFF;
        public Texture2D ButtonHover;
        public Texture2D ButtonON;
        private bool windows;
        private bool zoom=false;
        private void OnGUI()
        {
            if(windows==true) GUI.Window(0, new Rect(3f, 18f, 100f, 184f), new GUI.WindowFunction(DoMyWindow), " 帮助菜单");
            if (Convert.ToInt32(Time.time - this.cd) > 1)
            {

                if (Input.GetKeyUp(KeyCode.F10))
                {
                    if (this.ShowAim)
                    {
                        this.ShowAim = false;
                        PopupUI.singleton.CreateNotice(5f, "☣", "准心关闭");
                    }
                    else
                    {
                        this.ShowAim = true;
                        PopupUI.singleton.CreateNotice(5f, "☣", "准心打开");
                    }
                    this.cd = (float)((int)Time.time);
                    return;
                }
                if (Input.GetKeyUp(KeyCode.Q) && !ChatUI.singleton.textInput.IsVisible)//
                {
                    ConsoleNetworker.SendCommandToServer("chat.say /bb");
                    this.cd = (float)((int)Time.time);                   
                    return; 
                }
                if (Input.GetKeyUp(KeyCode.F3))
                {
                    ConsoleNetworker.SendCommandToServer("chat.say \"/kit starter\"");                   
                    this.cd = (float)((int)Time.time);
                    return;
                }
                if (Input.GetKeyUp(KeyCode.F4))
                {
                    ConsoleNetworker.SendCommandToServer("chat.say \"/destory\"");

                    this.cd = (float)((int)Time.time);
                    return;
                }
                RunConsoleCommand consoleCommand = new RunConsoleCommand();
                if (Input.GetKeyUp(KeyCode.F5))
                {
                    ConsoleWindow consoleWindow = new ConsoleWindow();
                    if (zoom)
                    {
                        zoom = false;
                        Zoom.On = false;                         
                        PopupUI.singleton.CreateNotice(5f, "剑", "超视距已关闭");
                    }
                    else
                    {
                        zoom = true;
                        Zoom.On = true;
                        PopupUI.singleton.CreateNotice(5f, "剑", "超视距已开启");
                    }                    
                    this.cd = (float)((int)Time.time);                    
                    return;                    
                }
                
                if (Input.GetKeyUp(KeyCode.F6))
                {
                    ConsoleNetworker.SendCommandToServer("chat.say /home");
                    this.cd = (float)((int)Time.time);
                    return;
                }
                if (Input.GetKeyUp(KeyCode.F7))
                {
                    ConsoleNetworker.SendCommandToServer("chat.say /sjfz");
                    this.cd = (float)((int)Time.time);
                    return;
                }
                if (Input.GetKeyUp(KeyCode.F8))
                {
                    if (windows == true) windows = false;
                    else windows = true;
                    this.cd = (float)((int)Time.time);
                    return;
                }
                if (this.ShowAim)
                {
                    Rect rect = new Rect(Screen.width / 2 - (this.Taskelis.width >> 1) + 2, Screen.height / 2 - (this.Taskelis.height >> 1) - 1, this.Taskelis.width, this.Taskelis.height);
                    GUI.DrawTexture(rect, this.Taskelis);
                }
                return;
            }
        }
        public void DoMyWindow(int windowID)
        {            
            GUIStyle guistyle = new GUIStyle();
            guistyle.fontSize = 14;
            guistyle.fontStyle = FontStyle.Bold;
            guistyle.normal.textColor = Color.cyan;
            GUIStyle guistyle2 = new GUIStyle();
            guistyle2.fontSize = 14;
            guistyle2.fontStyle = FontStyle.Bold;
            guistyle2.normal.textColor = Color.yellow;
            GUIStyle guistyle3 = new GUIStyle();
            guistyle3.fontSize = 14;
            guistyle3.fontStyle = FontStyle.Bold;
            guistyle3.normal.textColor = Color.green;
            GUI.Label(new Rect(6f, 10f, (float)Screen.width, (float)Screen.height), "", guistyle);
            GUI.Label(new Rect(6f, 24f, (float)Screen.width, (float)Screen.height), "Q▶一键捡包", guistyle3);
            GUI.Label(new Rect(6f, 38f, (float)Screen.width, (float)Screen.height), "M▶实时地图", guistyle3);
            GUI.Label(new Rect(6f, 52f, (float)Screen.width, (float)Screen.height), "N▶夜视", guistyle3);
            GUI.Label(new Rect(6f, 66f, (float)Screen.width, (float)Screen.height), "F4▶拆家指令", guistyle3);
            GUI.Label(new Rect(6f, 80f, (float)Screen.width, (float)Screen.height), "F5▶超级视觉", guistyle3);
            GUI.Label(new Rect(6f, 94f, (float)Screen.width, (float)Screen.height), "F6▶一键回家", guistyle3);
            GUI.Label(new Rect(6f, 108f, (float)Screen.width, (float)Screen.height), "F7▶查询物品", guistyle3);
            GUI.Label(new Rect(6f, 122f, (float)Screen.width, (float)Screen.height), "F8▶开关面板", guistyle3);
            GUI.Label(new Rect(6f, 136f, (float)Screen.width, (float)Screen.height), "F2▶仙域道脉", guistyle3);
            GUI.Label(new Rect(6f, 150f, (float)Screen.width, (float)Screen.height), "F10▶一键准心", guistyle3);
            GUI.Label(new Rect(6f, 164f, (float)Screen.width, (float)Screen.height), "  仙域Rust", guistyle);
        }
        public float cd = 1f;
        public float cd1 = 4f;
        public void Start()
        {
            int width = Screen.width;
            int height = Screen.height;
            new Rect(0f, 0f, 60f, 16f);
            byte[] array = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAB4AAAAbCAYAAABr/T8RAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAFMSURBVEhL1ZW/SsNQFId/EWr+Oqg41EGwKIibOOokLg7VTVdXQVcFEQQni3QoTuIjiE6OpW4+QfURWlq1NE1LSEJyLXIewJMzXPot+chwv3tvIMdQSkEHU/TMxcXTZe5di8LF0iIZH1F4lI7I+IjCQeyT8RGFwygk4yMKR2FExkcUXlkukfGRXbWuE2eDjIyP7Kq9VTI+k/fL7N5U1cfJee5d/5348PRIFXeLwHwGx3Lh93zMWB4KVgHf/hcsx4Y57QLtFJWDihE03lX97ArmeIF0ewPlh6rx+FZTbdtHZ9CB6ZjwTBf9nz5c24Vt2+iO15kzZvFy+4xm/dPIfdWv5WPVa7WwsLOFvbtrg17/m8kcixJE4VrjXs88TtyEjI8o7KeaxmKQBGR8ROEo1DSP15bWyfiIwnEYk/ERhYeRpm+cDTXN4/LmPhkX4Bex5G9mc5BOFQAAAABJRU5ErkJggoL5ouW51fJxwbHrML0x2QOLt3ZuzvkuW4MWe9hpf2EX0Kj7Q89mZl/NzL68ch2N4sMPG55PnnnfvC1oW951LWxfdQSWPGG3+a15+Z3r9NlTKrUAgUV9MCB07L+XVltyZ/PIfN86f+nRmXOvb7hxyLU65YFoyKEYCYgEcXKF9NIrKyI4HhVWfnqdEilAFMlZ+TwR+opPPoOTUC5VvkDi0BHVU4+E3rqmP0ABvzf8myf/K+i2jHfnXnde64FeakoRNbortEKKatLCaDcq6I+YHij1McStARspqkkLU1BTOxi3jdNQD2DwlJEZRFMpg8xGapPKVjVpQS81MWaQvRtZPyb1EaDspZBeCd2eJo36QJfN4ZvLt3zyt6buLqEcLu/pndfAX3edGROlos0OAAAAAElFTkSuQmCC");
            this.Taskelis = new Texture2D(100, 100, TextureFormat.RGBA32, false);
            this.ButtonOFF = new Texture2D(60, 16, TextureFormat.RGB24, false);
            this.ButtonHover = new Texture2D(60, 16, TextureFormat.RGB24, false);
            this.ButtonON = new Texture2D(60, 16, TextureFormat.RGB24, false);
            this.Taskelis.LoadImage(array);
        }
    }
}