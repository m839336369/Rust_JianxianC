using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace JianxianC.Core
{
    public class Nmap
    {
        public GameObject GameMap;
        public Nmap()
        {
            this.GameMap = new GameObject();
            this.GameMap.AddComponent<MapInterface>();
            UnityEngine.Object.DontDestroyOnLoad(this.GameMap);
        }
        ~Nmap()
        {
            bool flag = this.GameMap != null;
            if (flag)
            {
                UnityEngine.Object.Destroy(this.GameMap);
            }
        }
    }
    public class MapInterface : MonoBehaviour
    {
        // Token: 0x06000007 RID: 7 RVA: 0x000020F9 File Offset: 0x000002F9
        public MapInterface()
        {
            this.ShowMap = false;
        }

        // Token: 0x06000008 RID: 8 RVA: 0x0000210C File Offset: 0x0000030C
        public void Update()
        {
            bool flag = !ChatUI.IsVisible() && !ConsoleWindow.IsVisible() && !MainMenu.IsVisible() && Input.GetKeyDown(KeyCode.M);
            if (flag)
            {
                bool showMap = this.ShowMap;
                if (showMap)
                {
                    this.ShowMap = false;
                }
                else
                {
                    this.ShowMap = true;
                }
            }
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002160 File Offset: 0x00000360
        public void OnGUI()
        {
            int width = Screen.width;
            int height = Screen.height;
            Rect position = new Rect(0f, 32f, 60f, 16f);
            bool flag = position.Contains(Event.current.mousePosition);
            bool flag2 = !MainMenu.IsVisible();
            if (flag2)
            {
                bool flag3 = flag;
                if (flag3)
                {
                    GUI.DrawTexture(position, this.ShowMap ? this.ButtonON : this.ButtonOFF, ScaleMode.StretchToFill);
                    bool flag4 = Event.current.type == EventType.MouseDown || Input.GetButtonDown("Fire1");
                    bool flag5 = flag4;
                    if (flag5)
                    {
                        bool showMap = this.ShowMap;
                        if (showMap)
                        {
                            this.ShowMap = false;
                        }
                        else
                        {
                            this.ShowMap = true;
                        }
                    }
                }
                else
                {
                    bool showMap2 = this.ShowMap;
                    if (showMap2)
                    {
                        GUI.DrawTexture(position, this.ButtonON, ScaleMode.StretchToFill);
                    }
                    else
                    {
                        GUI.DrawTexture(position, this.ButtonOFF, ScaleMode.StretchToFill);
                    }
                }
                bool showMap3 = this.ShowMap;
                if (showMap3)
                {
                    float num = (float)width - (float)width * 0.790625f;
                    float num2 = (float)height - (float)height * 0.9444444f;
                    float num3 = (float)width / 1920f * 0.233f;
                    float num4 = (float)height / 1080f * 0.2343934f;
                    GUI.DrawTexture(new Rect(num / 2f, num2 / 2f, (float)width * 0.790625f, (float)height * 0.9444444f), this.Map, ScaleMode.StretchToFill);
                    bool localPlayerControllableExists = Controllable.localPlayerControllableExists;
                    if (localPlayerControllableExists)
                    {
                        Vector3 origin = Controllable.localPlayerControllable.origin;
                        GUI.DrawTexture(new Rect(num / 2f + (7000f + origin.z) * num3 - 5f, num2 / 2f + (origin.x - 3302f) * num4 - 5f, 10f, 10f), this.Pointer, ScaleMode.StretchToFill);
                    }
                }
            }
        }

        // Token: 0x0600000A RID: 10 RVA: 0x00002348 File Offset: 0x00000548
        public void Start()
        {
            byte[] data = MapInterface.ReadFully(Assembly.GetExecutingAssembly().GetManifestResourceStream("NMap.rust-map.jpg"));
            byte[] data2 = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAoAAAAKCAYAAACNMs+9AAAABmJLR0QA/wD/AP+gvaeTAAAACXBIWXMAAAsTAAALEwEAmpwYAAAAB3RJTUUH4QgKEBA4MOfAnQAAAB1pVFh0Q29tbWVudAAAAAAAQ3JlYXRlZCB3aXRoIEdJTVBkLmUHAAAAk0lEQVQY042QsQ3CMBBF3zkoCNmgdBFl6vQskzUyAAOwhldJQe8RIpQeVxRQHI6MLAFfuuLfveL+BwvA89scqh3yNpxG6AdwRwC43yB4uF7UV8A5h2wLtQMRaDqo9zBPYOATSrKt7vpB/QZKKIeTDH/KpMfjUh7jorcVDL6EExR8lnqeNF3TadpHLOvByfZn4QbhBc5DOCDazOLnAAAAAElFTkSuQmCC");
            byte[] data3 = MapInterface.ReadFully(Assembly.GetExecutingAssembly().GetManifestResourceStream("NMap.map_off.jpg"));
            byte[] data4 = MapInterface.ReadFully(Assembly.GetExecutingAssembly().GetManifestResourceStream("NMap.map_on.jpg"));
            this.Map = new Texture2D(1451, 1016, TextureFormat.ATF_RGB_JPG, false);
            this.Map.LoadImage(data);
            this.Pointer.LoadImage(data2);
            this.ButtonOFF.LoadImage(data3);
            this.ButtonHover.LoadImage(data3);
            this.ButtonON.LoadImage(data4);
            MapInterface.Text = "Ahoj";
            MapInterface.lineStyle = new GUIStyle();
            MapInterface.lineStyle.normal.background = MapInterface.Make(1, 1, Color.white);
        }

        // Token: 0x0600000B RID: 11 RVA: 0x00002478 File Offset: 0x00000678
        public static byte[] ReadFully(Stream input)
        {
            byte[] array = new byte[16384];
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int count;
                while ((count = input.Read(array, 0, array.Length)) > 0)
                {
                    memoryStream.Write(array, 0, count);
                }
                result = memoryStream.ToArray();
            }
            return result;
        }

        // Token: 0x0600000C RID: 12 RVA: 0x000024E4 File Offset: 0x000006E4
        public static Texture2D Make(int width, int height, Color col)
        {
            Color[] array = new Color[width * height];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = col;
            }
            Texture2D texture2D = new Texture2D(width, height);
            texture2D.SetPixels(array);
            texture2D.Apply();
            return texture2D;
        }

        // Token: 0x04000002 RID: 2
        private const float r_width = 0.790625f;

        // Token: 0x04000003 RID: 3
        private const float r_height = 0.9444444f;

        // Token: 0x04000004 RID: 4
        private const float offset_dolu = 3302f;

        // Token: 0x04000005 RID: 5
        private const float offset_zleva = 7000f;

        // Token: 0x04000006 RID: 6
        private const float c_height = 0.2343934f;

        // Token: 0x04000007 RID: 7
        private const float c_width = 0.233f;

        // Token: 0x04000008 RID: 8
        private bool ShowMap;

        // Token: 0x04000009 RID: 9
        public static string Text;

        // Token: 0x0400000A RID: 10
        public Texture2D Map;

        // Token: 0x0400000B RID: 11
        public Texture2D ButtonOFF;

        // Token: 0x0400000C RID: 12
        public Texture2D ButtonON;

        // Token: 0x0400000D RID: 13
        public Texture2D ButtonHover;

        // Token: 0x0400000E RID: 14
        public Texture2D Pointer;

        // Token: 0x0400000F RID: 15
        private static GUIStyle lineStyle;
    }
}