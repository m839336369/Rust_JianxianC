using RustBuster2016.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using uLink;
using UnityEngine;

namespace JianxianC.Core
{

    public class chinese : UnityEngine.MonoBehaviour
    {
        internal GameObject MainGameObject;
        bool ready = false;
        public UIFont ChinaFont_UI ;
        Color32 ps_qs= new Color32(63, 148, 181, 100);
        Color32 ps_qs1 = new Color32(96, 171, 168, 100);
        //Color32 ps_hs = new Color32(80, 180, 215, 100);
        Color32 ps_hs = Color.cyan;
        public void init()
        {
            ConsoleWindow.singleton.consoleOutput.Font = ChatUI.singleton.textInput.Font;
            MainGameObject = new GameObject();
            UnityEngine.Object.DontDestroyOnLoad(this.MainGameObject);
            MainGameObject.AddComponent<Window>();
            try
            {
                MainGameObject.AddComponent<chinese>().StartCoroutine(DownloadAndCache());
            }
            catch (Exception ex)
            {
            }
        }



        public void Load_UI()
        {
            global::dfRichTextLabel[] array2 = global::Resources.FindObjectsOfTypeAll(typeof(global::dfRichTextLabel)) as global::dfRichTextLabel[];
            for (int i = 0; i < array2.Length; i++)
            {
                if (array2[i].Text == "disconnect")
                {
                    array2[i].Text = "断开连接";
                    array2[i].Color = ps_qs;
                    array2[i].ColorChanged += Chinese_ColorChanged;
                }
                else if (array2[i].Text == "WARNING")
                {
                    array2[i].Text = "仙域";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text == "This server is protected by Valve Anti Cheat. If you cheat you will be banned from all servers")
                {
                    array2[i].Text = "逍遥-逍枪遥神-楉灵槿魂-仙域\n一路走来，众列同在否？——剑仙";
                    array2[i].Color = Color.yellow;
                }
                else if (array2[i].Text == "p e r m a n e n t l y")
                {
                    array2[i].Text = "官群:487185946";
                    array2[i].Color = Color.red;
                }
                else if (array2[i].Text == "loading")
                {
                    array2[i].Text = "仙域Rust";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text == "play game")
                {
                    array2[i].Text = "征战仙域";
                    array2[i].Color = ps_qs;
                    array2[i].ColorChanged += Chinese_ColorChanged;
                }
                else if (array2[i].Text == "options")
                {
                    array2[i].Text = "设置";
                    array2[i].Color = ps_qs;
                    array2[i].ColorChanged += Chinese_ColorChanged;
                }
                else if (array2[i].Text == "exit")
                {
                    array2[i].Text = "退出仙域";
                    array2[i].Color = ps_qs;
                    array2[i].ColorChanged += Chinese_ColorChanged;
                }
                else if (array2[i].Text == "sound")
                {
                    array2[i].Text = "音量";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text == "rust.legacy")
                {
                    array2[i].Text = "仙域";

                    array2[i].Color = Color.black;
                }
                else if (array2[i].Text.Contains("2019,"))
                {
                    array2[i].Text = "Happy New Year";
                    array2[i].Color = Color.red;
                }
                else if (array2[i].Text.Contains("Music Volume,"))
                {
                    array2[i].Text = "音乐设置";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Volume"))
                {
                    array2[i].Text = "游戏音量";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("graphics"))
                {
                    array2[i].Text = "图像";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Render"))
                {
                    array2[i].Text = "渲染质量";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Water Re"))
                {
                    array2[i].Text = "水质质量";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("VSync"))
                {
                    array2[i].Text = "垂直同步";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("input"))
                {
                    array2[i].Text = "输入";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Invert"))
                {
                    array2[i].Text = "纵向反转";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Left"))
                {
                    array2[i].Text = "左";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Right"))
                {
                    array2[i].Text = "右";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Up"))
                {
                    array2[i].Text = "前";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Down"))
                {
                    array2[i].Text = "后";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Jump"))
                {
                    array2[i].Text = "跳";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Duck"))
                {
                    array2[i].Text = "蹲";
                }
                else if (array2[i].Text.Contains("Sprint"))
                {
                    array2[i].Text = "跑";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Laser"))
                {
                    array2[i].Text = "激光器";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Fire"))
                {
                    array2[i].Text = "开火";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("AltFire"))
                {
                    array2[i].Text = "瞄准";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Reload"))
                {
                    array2[i].Text = "重载";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Use"))
                {
                    array2[i].Text = "使用";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Voice"))
                {
                    array2[i].Text = "语音";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Flashlight"))
                {
                    array2[i].Text = "手电筒";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Inventory"))
                {
                    array2[i].Text = "背包";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Chat"))
                {
                    array2[i].Text = "聊天";
                    array2[i].Color = ps_qs;
                }
                else if (array2[i].Text.Contains("Mouse Sen"))
                {
                    array2[i].Text = "鼠标灵敏度";
                    array2[i].Color = ps_qs;
                }
            }
        }
        public  string Text_Fanyi(string text)
        {
            return zhongwen.GetChinese(text);
        }
        

        public void ReChinese()
        {
                UnityEngine.Object[] array1 = global::Resources.FindObjectsOfTypeAll(typeof(global::dfLabel));
                Vector2 vector2 = new Vector2(500, 200);
                for (int i = 0; i < array1.Length; i++)
                {
                    dfLabel gUIHide = (global::dfLabel)array1[i];
                    if (gUIHide != null)
                    {
                        gUIHide.AutoHeight = true;
                        gUIHide.Shadow = true;
                        gUIHide.ShadowColor = ps_qs;
                        switch (gUIHide.Text)
                        {
                            case "YOU  ARE":
                                gUIHide.AutoSize = true;
                                gUIHide.Text = "胜败乃兵家常事，大侠请重新来过";
                                gUIHide.Color = ps_qs1;
                                break;
                            case "DEAD":
                                gUIHide.Text = "仙域";
                                gUIHide.Color = ps_qs1;
                                break;
                            case "This is the [b]chat[/b] <p color=red>text</p> etc...":
                                gUIHide.AutoSize = false;
                                gUIHide.Font.FontSize = 16;
                                gUIHide.Size = vector2;
                                gUIHide.Shadow = false;
                                break;
                        }      
                    }
                }
                foreach (ItemDataBlock itemDataBlock in DatablockDictionary.All)
                {
                    itemDataBlock.name = Text_Fanyi(itemDataBlock.name);
                    itemDataBlock.itemDescriptionOverride = Text_Fanyi(itemDataBlock.GetItemDescription()) ;
                }
                UnityEngine.Object[] array3 = global::Resources.FindObjectsOfTypeAll(typeof(global::dfButton));
                for (int i = 0; i < array3.Length; i++)
                {
                    dfButton gUIHide = (global::dfButton)array3[i];
                    if (gUIHide != null)
                    {
                        gUIHide.AutoSize = true;
                        gUIHide.TextColor = ps_qs;
                        if (gUIHide.Text.IndexOf("CAMP") != -1)
                        {
                            gUIHide.Text = "重生到睡袋";
                            gUIHide.Color = new Color32(100, 100, 200, 100);
                        }
                        switch (gUIHide.Text)
                        {
                            case "RESPAWN":
                                gUIHide.Text = "重生";
                                gUIHide.Color = new Color32(100, 100, 200, 100);
                                break;
                            case "Apply Changes":
                                gUIHide.Text = "修改配置";
                                gUIHide.Color = new Color32(100, 100, 200, 100);
                                break;
                        }
                    }
                }

                UILabel[] array = Resources.FindObjectsOfTypeAll(typeof(UILabel)) as UILabel[];
                for (int i = 0; i < array.Length; i++)
                {
                        array[i].color = ps_hs;
                        for(int j = 0; j < array.Length; j++)
                        {
                            ChinaFont_UI.bmFont.charSize = 70;                  
                            if (array[j].font!=null && array[j].font != ChinaFont_UI)
                            {
                                if (array[j].text != null)
                                {
                                    array[j].font = ChinaFont_UI;
                                    array[j].text = Text_Fanyi(array[j].text);
                                }
                            }
                        }
                }
        }
        private void Chinese_ColorChanged(dfControl control, Color32 value)
        {
                control.Color = ps_qs;
        }

        private AssetBundleCreateRequest asset;
        public static AssetBundle bundle;

        // Token: 0x04000015 RID: 21
        public GameObject ourobject;

        // Token: 0x04000017 RID: 23
        private IEnumerator DownloadAndCache()//z这里加载打包的字体
        {
            FileStream fileStream = new FileStream(Path.Combine(Environment.CurrentDirectory, "bundles\\Font.unity3d"), FileMode.Open, FileAccess.ReadWrite);
            byte[] array = new byte[fileStream.Length];
            fileStream.Read(array, 0, (int)fileStream.Length);
            fileStream.Close();
            this.asset = AssetBundle.CreateFromMemory(array);
            yield return this.asset;
            foreach (UnityEngine.Object @object in asset.assetBundle.LoadAll())
            {
                if (@object.GetType().ToString() == "UnityEngine.GameObject")
                {
                    GameObject gameObject = @object as GameObject;
                    if (gameObject.name == "New Font")
                    {
                        ChinaFont_UI = gameObject.GetComponent<UIFont>();
                        break;
                    }
                }
            }
            yield break;
        }
        public partial class zhongwen : UnityEngine.MonoBehaviour
        {
            public static string GetChinese(string str1)
            {
                string result;
                if (str1 == "Bullet")
                {
                    result = "防 弹";
                }
                else if (str1 == "CRAFTING")
                {
                    result = "制作栏";
                }
                else if (str1 == "Melee")
                {
                    result = "防 暴";
                }
                else if (str1 == "Explosion")
                {
                    result = "防 爆";
                }
                else if (str1 == "Radiation")
                {
                    result = "防 化";
                }
                else if (str1 == "Cold")
                {
                    result = "防 寒";
                }
                else if (str1 == "COLD")
                {
                    result = "寒 冷";
                }
                else if (str1 == "FOOD")
                {
                    result = "食 物";
                }
                else if (str1 == "ARMOR")
                {
                    result = "装备";
                }
                else if (str1 == "Condition")
                {
                    result = "耐久";
                }
                else if (str1 == "Description")
                {
                    result = "详情";
                }
                else if (str1 == "Description:")
                {
                    result = "详情:";
                }
                else if (str1 == "Result Item")
                {
                    result = "学习对象";
                }
                else if (str1 == "Ingredients")
                {
                    result = "合成材料";
                }
                else if (str1 == "This is a weapon")
                {
                    result = "这是一把武器，把它拖到你的屏幕下方的格子里，按相应的数字键使用它";
                }
                else if (str1 == "Use")
                {
                    result = "使用";
                }
                else if (str1 == "Blueprint. Study it to")
                {
                    result = "这是一个物品蓝图，学习后你就可以制作它";
                }
                else if (str1 == "REPAIR BENCH")
                {
                    result = "维修台";
                }
                else if (str1 == "Occupied")
                {
                    result = "占用";
                }
                else if (str1 == "HEAD")
                {
                    result = "头";
                }
                else if (str1 == "Head")
                {
                    result = "头";
                }
                else if (str1 == "Chest")
                {
                    result = "身";
                }
                else if (str1 == "CHEST")
                {
                    result = "身";
                }
                else if (str1 == "Legs")
                {
                    result = "腿";
                }
                else if (str1 == "LEGS")
                {
                    result = "腿";
                }
                else if (str1 == "BOOTS")
                {
                    result = "脚";
                }
                else if (str1 == "Boots")
                {
                    result = "脚";
                }
                else if (str1 == "A type of resource")
                {
                    result = "一种资源";
                }
                else if (str1 == "Ammunition for a")
                {
                    result = "武器弹药";
                }
                else if (str1 == "Consumable")
                {
                    result = "效果";
                }
                else if (str1 == "Protection")
                {
                    result = "装备属性";
                }
                else if (str1 == "Equipment Slot")
                {
                    result = "保护部位";
                }
                else if (str1 == "Drink")
                {
                    result = "喝";
                }
                else if (str1 == "Consume")
                {
                    result = "吃";
                }
                else if (str1 == "Open")
                {
                    result = "打开";
                }
                else if (str1 == "Study")
                {
                    result = "学习";
                }
                else if (str1 == "Search")
                {
                    result = "打开";
                }
                else if (str1 == "LOOT")
                {
                    result = "物资";
                }
                else if (str1 == "Ignite")
                {
                    result = "点燃";
                }
                else if (str1 == "Extinguish")
                {
                    result = "熄灭";
                }
                else if (str1 == "Craft")
                {
                    result = "制作";
                }
                else if (str1 == "Split")
                {
                    result = "分";
                }
                else if (str1 == "HEALTH")
                {
                    result = "生 命";
                }
                else if (str1 == "Resource")
                {
                    result = "材料";
                }
                else if (str1 == "Medical")
                {
                    result = "药物";
                }
                else if (str1 == "Ammo")
                {
                    result = "子弹";
                }
                else if (str1 == "Eat")
                {
                    result = "吃";
                }
                else if (str1 == "Weapons")
                {
                    result = "武器";
                }
                else if (str1 == "Tools")
                {
                    result = "工具";
                }
                else if (str1 == "Mods")
                {
                    result = "武器配件";
                }
                else if (str1 == "Unload")
                {
                    result = "卸弹";
                }
                else if (str1 == "Parts")
                {
                    result = "建筑部件";
                }
                else if (str1 == "RADS")
                {
                    result = "辐 射";
                }
                else if (str1 == "Misc")
                {
                    result = "杂项";
                }
                else if (str1 == "Inventory")
                {
                    result = "背包";
                }
                else if (str1 == "INVENTORY")
                {
                    result = "背包-仙域游戏公会";
                }
                else if (str1 == "Armor")
                {
                    result = "装备";
                }
                else if (str1 == "Crafting")
                {
                    result = "制作栏";
                }
                else if (str1 == "ITEMS")
                {
                    result = "物品";
                }
                else if (str1 == "NEED")
                {
                    result = "需要";
                }
                else if (str1 == "Close")
                {
                    result = "关闭";
                }
                else if (str1 == "REQUIRES WORKBENCH")
                {
                    result = "需要工作台";
                }
                else if (str1 == "HAVE")
                {
                    result = "已有";
                }
                else if (str1 == "EFFECTS")
                {
                    result = "加成";
                }
                else if (str1 == "Survival")
                {
                    result = "生存工具";
                }
                else if (str1 == "undefined")
                {
                    result = "身体";
                }
                else if (str1 == "head")
                {
                    result = "头部";
                }
                else if (str1 == "face")
                {
                    result = "脸";
                }
                else if (str1 == "left eye")
                {
                    result = "左眼";
                }
                else if (str1 == "right eye")
                {
                    result = "右眼";
                }
                else if (str1 == "nose")
                {
                    result = "鼻子";
                }
                else if (str1 == "mouth")
                {
                    result = "口";
                }
                else if (str1 == "throat")
                {
                    result = "喉咙";
                }
                else if (str1 == "chest")
                {
                    result = "胸膛";
                }
                else if (str1 == "torso")
                {
                    result = "躯干";
                }
                else if (str1 == "body")
                {
                    result = "身体";
                }
                else if (str1 == "gut")
                {
                    result = "肠子";
                }
                else if (str1 == "hip")
                {
                    result = "关节";
                }
                else if (str1 == "left lung")
                {
                    result = "左肺";
                }
                else if (str1 == "right lung")
                {
                    result = "右肺";
                }
                else if (str1 == "left shoulder")
                {
                    result = "左肩";
                }
                else if (str1 == "right shoulder")
                {
                    result = "右肩";
                }
                else if (str1 == "left hand")
                {
                    result = "左手";
                }
                else if (str1 == "right hand")
                {
                    result = "右手";
                }
                else if (str1 == "left wrist")
                {
                    result = "左手腕";
                }
                else if (str1 == "right wrist")
                {
                    result = "右手腕";
                }
                else if (str1 == "left bicep")
                {
                    result = "左二头肌";
                }
                else if (str1 == "right bicep")
                {
                    result = "右二头肌";
                }
                else if (str1 == "left foot")
                {
                    result = "左脚";
                }
                else if (str1 == "right foot")
                {
                    result = "右脚";
                }
                else if (str1 == "left calve")
                {
                    result = "左大腿";
                }
                else if (str1 == "right calve")
                {
                    result = "右大腿";
                }
                else if (str1 == "Chicken")
                {
                    result = "鸡";
                }
                else if (str1 == "Rabbit")
                {
                    result = "兔";
                }
                else if (str1 == "Boar")
                {
                    result = "猪";
                }
                else if (str1 == "Stag")
                {
                    result = "鹿";
                }
                else if (str1 == "Wolf")
                {
                    result = "狼";
                }
                else if (str1 == "Bear")
                {
                    result = "熊";
                }
                else if (str1 == "Mutant Wolf")
                {
                    result = "僵尸狼";
                }
                else if (str1 == "Mutant Bear")
                {
                    result = "僵尸熊";
                }
                else if (str1 == "Bolt Action Rifle")
                {
                    result = "狙击";
                }
                else if (str1 == "Bolt Action Rifle Blueprint")
                {
                    result = "狙击蓝图";
                }
                else if (str1 == "556 Ammo")
                {
                    result = "556子弹";
                }
                else if (str1 == "9mm Ammo")
                {
                    result = "9mm子弹";
                }
                else if (str1 == "556 Ammo Blueprint")
                {
                    result = "556子弹蓝图";
                }
                else if (str1 == "9mm Ammo Blueprint")
                {
                    result = "9mm子弹蓝图";
                }
                else if (str1 == "Handmade Shell Blueprint")
                {
                    result = "土炮子弹蓝图";
                }
                else if (str1 == "Shotgun Shells Blueprint")
                {
                    result = "子弹蓝图";
                }
                else if (str1 == "Handmade Shell")
                {
                    result = "土炮子弹";
                }
                else if (str1 == "Shotgun Shells")
                {
                    result = "散弹枪子弹";
                }
                else if (str1 == "Cloth Boots BP")
                {
                    result = "布鞋蓝图";
                }
                else if (str1 == "Cloth Helmet BP")
                {
                    result = "布盔蓝图";
                }
                else if (str1 == "Cloth Pants BP")
                {
                    result = "布裤蓝图";
                }
                else if (str1 == "Cloth Vest BP")
                {
                    result = "布衣蓝图";
                }
                else if (str1 == "Kevlar Boots BP")
                {
                    result = "防弹鞋蓝图";
                }
                else if (str1 == "Kevlar Helmet BP")
                {
                    result = "防弹盔蓝图";
                }
                else if (str1 == "Kevlar Pants BP")
                {
                    result = "防弹裤蓝图";
                }
                else if (str1 == "Kevlar Vest BP")
                {
                    result = "防弹衣蓝图";
                }
                else if (str1 == "Leather Boots BP")
                {
                    result = "皮鞋蓝图";
                }
                else if (str1 == "Leather Helmet BP")
                {
                    result = "皮盔蓝图";
                }
                else if (str1 == "Leather Pants BP")
                {
                    result = "皮裤蓝图";
                }
                else if (str1 == "Leather Vest BP")
                {
                    result = "皮衣蓝图";
                }
                else if (str1 == "Rad Suit Boots BP")
                {
                    result = "防化鞋蓝图";
                }
                else if (str1 == "Rad Suit Helmet BP")
                {
                    result = "防化盔蓝图";
                }
                else if (str1 == "Rad Suit Pants BP")
                {
                    result = "防化裤蓝图";
                }
                else if (str1 == "Rad Suit Vest BP")
                {
                    result = "防化衣蓝图";
                }
                else if (str1 == "Cloth Boots")
                {
                    result = "布鞋";
                }
                else if (str1 == "Cloth Helmet")
                {
                    result = "布盔";
                }
                else if (str1 == "Cloth Pants")
                {
                    result = "布裤";
                }
                else if (str1 == "Cloth Vest")
                {
                    result = "布衣";
                }
                else if (str1 == "Invisible Boots")
                {
                    result = "管理员鞋";
                }
                else if (str1 == "Invisible Helmet")
                {
                    result = "管理盔";
                }
                else if (str1 == "Invisible Pants")
                {
                    result = "管理员裤";
                }
                else if (str1 == "Invisible Vest")
                {
                    result = "管理员衣";
                }
                else if (str1 == "Kevlar Boots")
                {
                    result = "防弹鞋";
                }
                else if (str1 == "Kevlar Helmet")
                {
                    result = "防弹盔";
                }
                else if (str1 == "Kevlar Pants")
                {
                    result = "防弹裤";
                }
                else if (str1 == "Kevlar Vest")
                {
                    result = "防弹衣";
                }
                else if (str1 == "Leather Boots")
                {
                    result = "皮鞋";
                }
                else if (str1 == "Leather Helmet")
                {
                    result = "皮盔";
                }
                else if (str1 == "Leather Pants")
                {
                    result = "皮裤";
                }
                else if (str1 == "Leather Vest")
                {
                    result = "皮衣";
                }
                else if (str1 == "Rad Suit Boots")
                {
                    result = "防化鞋";
                }
                else if (str1 == "Rad Suit Helmet")
                {
                    result = "防化盔";
                }
                else if (str1 == "Rad Suit Pants")
                {
                    result = "防化裤";
                }
                else if (str1 == "Rad Suit Vest")
                {
                    result = "防化衣";
                }
                else if (str1 == "Arrow")
                {
                    result = "箭";
                }
                else if (str1 == "Arrow Blueprint")
                {
                    result = "箭蓝图";
                }
                else if (str1 == "Anti-Radiation Pills")
                {
                    result = "口香糖";
                }
                else if (str1 == "Can of Beans")
                {
                    result = "豆罐头";
                }
                else if (str1 == "Can of Tuna")
                {
                    result = "鱼罐头";
                }
                else if (str1 == "Chocolate Bar")
                {
                    result = "巧克力";
                }
                else if (str1 == "Cooked Chicken Breast")
                {
                    result = "熟肉";
                }
                else if (str1 == "Granola Bar")
                {
                    result = "燕麦";
                }
                else if (str1 == "Raw Chicken Breast")
                {
                    result = "生肉";
                }
                else if (str1 == "Small Rations")
                {
                    result = "饼干";
                }
                else if (str1 == "Small Water Bottle")
                {
                    result = "矿泉水";
                }
                else if (str1 == "Bed")
                {
                    result = "铁床";
                }
                else if (str1 == "Bed Blueprint")
                {
                    result = "铁床蓝图";
                }
                else if (str1 == "Camp Fire Blueprint")
                {
                    result = "火堆蓝图";
                }
                else if (str1 == "Explosive Charge Blueprint")
                {
                    result = "C4蓝图";
                }
                else if (str1 == "Furnace Blueprint")
                {
                    result = "熔炉蓝图";
                }
                else if (str1 == "Large Spike Wall Blueprint")
                {
                    result = "大栅栏蓝图";
                }
                else if (str1 == "Large Wood Storage Blueprint")
                {
                    result = "大箱子蓝图";
                }
                else if (str1 == "Metal Door Blueprint")
                {
                    result = "铁门蓝图";
                }
                else if (str1 == "Metal Window Bars Blueprint")
                {
                    result = "金属窗栏蓝图";
                }
                else if (str1 == "Repair Bench Blueprint")
                {
                    result = "维修台蓝图";
                }
                else if (str1 == "Sleeping Bag Blueprint")
                {
                    result = "睡袋蓝图";
                }
                else if (str1 == "Small Stash Blueprint")
                {
                    result = "小袋子蓝图";
                }
                else if (str1 == "Spike Wall Blueprint")
                {
                    result = "小木刺蓝图";
                }
                else if (str1 == "Wood Barricade Blueprint")
                {
                    result = "大木刺蓝图";
                }
                else if (str1 == "Wood Gate Blueprint")
                {
                    result = "大栅栏门蓝图";
                }
                else if (str1 == "Wood Gateway Blueprint")
                {
                    result = "大栅栏蓝图";
                }
                else if (str1 == "Wood Shelter Blueprint")
                {
                    result = "茅屋蓝图";
                }
                else if (str1 == "Wood Storage Box Blueprint")
                {
                    result = "小箱子蓝图";
                }
                else if (str1 == "Wooden Door Blueprint")
                {
                    result = "木门蓝图";
                }
                else if (str1 == "Workbench Blueprint")
                {
                    result = "工作台蓝图";
                }
                else if (str1 == "Metal Ceiling BP")
                {
                    result = "铁天花板蓝图";
                }
                else if (str1 == "Metal Doorway BP")
                {
                    result = "铁门框蓝图";
                }
                else if (str1 == "Metal Foundation BP")
                {
                    result = "铁地基蓝图";
                }
                else if (str1 == "Metal Pillar BP")
                {
                    result = "铁柱子蓝图";
                }
                else if (str1 == "Metal Ramp BP")
                {
                    result = "铁斜坡蓝图";
                }
                else if (str1 == "Metal Stairs BP")
                {
                    result = "铁楼梯蓝图";
                }
                else if (str1 == "Metal Wall BP")
                {
                    result = "铁墙蓝图";
                }
                else if (str1 == "Metal Window BP")
                {
                    result = "铁窗户蓝图";
                }
                else if (str1 == "Metal Ceiling")
                {
                    result = "铁天花板";
                }
                else if (str1 == "Metal Doorway")
                {
                    result = "铁门框";
                }
                else if (str1 == "Metal Foundation")
                {
                    result = "铁地基";
                }
                else if (str1 == "Metal Pillar")
                {
                    result = "铁柱子";
                }
                else if (str1 == "Metal Ramp")
                {
                    result = "铁斜坡";
                }
                else if (str1 == "Metal Stairs")
                {
                    result = "铁楼梯";
                }
                else if (str1 == "Metal Wall")
                {
                    result = "铁墙";
                }
                else if (str1 == "Metal Window")
                {
                    result = "铁窗户";
                }
                else if (str1 == "Wood Ceiling BP")
                {
                    result = "木天花板蓝图";
                }
                else if (str1 == "Wood Doorway BP")
                {
                    result = "木门框蓝图";
                }
                else if (str1 == "Wood Foundation BP")
                {
                    result = "木地基蓝图";
                }
                else if (str1 == "Wood Pillar BP")
                {
                    result = "木柱子蓝图";
                }
                else if (str1 == "Wood Ramp BP")
                {
                    result = "木斜坡蓝图";
                }
                else if (str1 == "Wood Stairs BP")
                {
                    result = "木楼梯蓝图";
                }
                else if (str1 == "Wood Wall BP")
                {
                    result = "木墙蓝图";
                }
                else if (str1 == "Wood Window BP")
                {
                    result = "木窗户蓝图";
                }
                else if (str1 == "Wood Ceiling")
                {
                    result = "木天花板";
                }
                else if (str1 == "Wood Doorway")
                {
                    result = "木门框";
                }
                else if (str1 == "Wood Foundation")
                {
                    result = "木地基";
                }
                else if (str1 == "Wood Pillar")
                {
                    result = "木柱子";
                }
                else if (str1 == "Wood Ramp")
                {
                    result = "木斜坡";
                }
                else if (str1 == "Wood Stairs")
                {
                    result = "木楼梯";
                }
                else if (str1 == "Wood Wall")
                {
                    result = "木墙";
                }
                else if (str1 == "Wood Window")
                {
                    result = "木窗户";
                }
                else if (str1 == "Camp Fire")
                {
                    result = "火堆";
                }
                else if (str1 == "Explosive Charge")
                {
                    result = "C4";
                }
                else if (str1 == "Furnace")
                {
                    result = "熔炉";
                }
                else if (str1 == "Large Spike Wall")
                {
                    result = "大地刺";
                }
                else if (str1 == "Large Wood Storage")
                {
                    result = "大箱子";
                }
                else if (str1 == "Metal Door")
                {
                    result = "铁门";
                }
                else if (str1 == "Metal Window Bars")
                {
                    result = "铁窗户栏";
                }
                else if (str1 == "Repair Bench")
                {
                    result = "维修台";
                }
                else if (str1 == "Sleeping Bag")
                {
                    result = "睡袋";
                }
                else if (str1 == "Small Stash")
                {
                    result = "小袋子";
                }
                else if (str1 == "Spike Wall")
                {
                    result = "小地刺";
                }
                else if (str1 == "Wood Barricade")
                {
                    result = "挡板";
                }
                else if (str1 == "Wood Gate")
                {
                    result = "大闸门";
                }
                else if (str1 == "Wood Gateway")
                {
                    result = "闸门门框";
                }
                else if (str1 == "Wood Shelter")
                {
                    result = "茅屋";
                }
                else if (str1 == "Wood Storage Box")
                {
                    result = "小箱子";
                }
                else if (str1 == "Wooden Door")
                {
                    result = "木门";
                }
                else if (str1 == "Workbench")
                {
                    result = "工作台";
                }
                else if (str1 == "Explosives")
                {
                    result = "炸药";
                }
                else if (str1 == "Gunpowder")
                {
                    result = "火药";
                }
                else if (str1 == "Bandage")
                {
                    result = "绷带";
                }
                else if (str1 == "Bandage Blueprint")
                {
                    result = "绷带蓝图";
                }
                else if (str1 == "Large Medkit Blueprint")
                {
                    result = "大药包蓝图";
                }
                else if (str1 == "Small Medkit Blueprint")
                {
                    result = "小药包蓝图";
                }
                else if (str1 == "Large Medkit")
                {
                    result = "大药包";
                }
                else if (str1 == "Small Medkit")
                {
                    result = "小药包";
                }
                else if (str1 == "Explosives Blueprint")
                {
                    result = "炸药蓝图";
                }
                else if (str1 == "Flare")
                {
                    result = "荧光棒";
                }
                else if (str1 == "Flare Blueprint")
                {
                    result = "荧光棒蓝图";
                }
                else if (str1 == "Gunpowder Blueprint")
                {
                    result = "火药蓝图";
                }
                else if (str1 == "Paper Blueprint")
                {
                    result = "纸张蓝图";
                }
                else if (str1 == "Torch")
                {
                    result = "火把";
                }
                else if (str1 == "Torch Blueprint")
                {
                    result = "火把蓝图";
                }
                else if (str1 == "Animal Fat")
                {
                    result = "脂肪";
                }
                else if (str1 == "Blood")
                {
                    result = "血袋";
                }
                else if (str1 == "Low Grade Fuel Blueprint")
                {
                    result = "油蓝图";
                }
                else if (str1 == "Low Quality Metal Blueprint")
                {
                    result = "大铁块蓝图";
                }
                else if (str1 == "Wood Planks Blueprint")
                {
                    result = "木板蓝图";
                }
                else if (str1 == "Charcoal")
                {
                    result = "木炭";
                }
                else if (str1 == "Cloth")
                {
                    result = "布";
                }
                else if (str1 == "Leather")
                {
                    result = "皮";
                }
                else if (str1 == "Low Grade Fuel")
                {
                    result = "油";
                }
                else if (str1 == "Low Quality Metal")
                {
                    result = "铁皮";
                }
                else if (str1 == "Metal Fragments")
                {
                    result = "铁块";
                }
                else if (str1 == "Metal Ore")
                {
                    result = "铁矿";
                }
                else if (str1 == "Paper")
                {
                    result = "纸张";
                }
                else if (str1 == "Stones")
                {
                    result = "碎石";
                }
                else if (str1 == "Sulfur")
                {
                    result = "硫磺";
                }
                else if (str1 == "Sulfur Ore")
                {
                    result = "硫磺矿";
                }
                else if (str1 == "Wood")
                {
                    result = "木头";
                }
                else if (str1 == "Wood Planks")
                {
                    result = "木板";
                }
                else if (str1 == "Blood Draw Kit")
                {
                    result = "超级抽血机";
                }
                else if (str1 == "Blood Draw Kit Blueprint")
                {
                    result = "超级抽血机蓝图";
                }
                else if (str1 == "Handmade Lockpick Blueprint")
                {
                    result = "锁蓝图";
                }
                else if (str1 == "Research Kit Blueprint")
                {
                    result = "蓝箱子蓝图";
                }
                else if (str1 == "Handmade Lockpick")
                {
                    result = "锁";
                }
                else if (str1 == "Recycle Kit 1")
                {
                    result = "回收工具包";
                }
                else if (str1 == "Research Kit 1")
                {
                    result = "蓝箱子";
                }
                else if (str1 == "9mm Pistol")
                {
                    result = "9mm手枪";
                }
                else if (str1 == "9mm Pistol Blueprint")
                {
                    result = "9mm手枪蓝图";
                }
                else if (str1 == "F1 Grenade Blueprint")
                {
                    result = "手雷蓝图";
                }
                else if (str1 == "Hatchet Blueprint")
                {
                    result = "铁斧蓝图";
                }
                else if (str1 == "Hunting Bow Blueprint")
                {
                    result = "弓箭蓝图";
                }
                else if (str1 == "M4 Blueprint")
                {
                    result = "M4蓝图";
                }
                else if (str1 == "MP5A4 Blueprint")
                {
                    result = "MP5A 蓝图";
                }
                else if (str1 == "P250 Blueprint")
                {
                    result = "P250 蓝图";
                }
                else if (str1 == "Pick Axe Blueprint")
                {
                    result = "稿子蓝图";
                }
                else if (str1 == "Shotgun Blueprint")
                {
                    result = "散弹枪蓝图";
                }
                else if (str1 == "Stone Hatchet Blueprint")
                {
                    result = "石斧蓝图";
                }
                else if (str1 == "F1 Grenade")
                {
                    result = "手雷";
                }
                else if (str1 == "Hatchet")
                {
                    result = "铁斧";
                }
                else if (str1 == "Hunting Bow")
                {
                    result = "弓箭";
                }
                else if (str1 == "M4")
                {
                    result = "M4步枪";
                }
                else if (str1 == "Flashlight Mod BP")
                {
                    result = "红瞄蓝图";
                }
                else if (str1 == "Holo sight BP")
                {
                    result = "瞄准镜蓝图";
                }
                else if (str1 == "Laser Sight BP")
                {
                    result = "手电筒蓝图";
                }
                else if (str1 == "Silencer BP")
                {
                    result = "消音器蓝图";
                }
                else if (str1 == "Flashlight Mod")
                {
                    result = "手电筒";
                }
                else if (str1 == "Holo sight")
                {
                    result = "瞄准镜";
                }
                else if (str1 == "Laser Sight")
                {
                    result = "红瞄";
                }
                else if (str1 == "Silencer")
                {
                    result = "消音器";
                }
                else if (str1 == "MP5A4")
                {
                    result = "MP5A4";
                }
                else if (str1 == "P250")
                {
                    result = "P250";
                }
                else if (str1 == "Pick Axe")
                {
                    result = "稿头";
                }
                else if (str1 == "Rock")
                {
                    result = "肥皂";
                }
                else if (str1 == "Shotgun")
                {
                    result = "散弹枪";
                }
                else if (str1 == "Stone Hatchet")
                {
                    result = "石斧";
                }
                else if (str1 == "Supply Signal")
                {
                    result = "烟雾弹";
                }
                else if (str1 == "Uber Hatchet")
                {
                    result = "管理斧";
                }
                else if (str1 == "Uber Hunting Bow")
                {
                    result = "管理弓";
                }
                else if (str1 == "HandCannon")
                {
                    result = "手炮";
                }
                else if (str1 == "HandCannon Blueprint")
                {
                    result = "手炮蓝图";
                }
                else if (str1 == "Pipe Shotgun")
                {
                    result = "土炮";
                }
                else if (str1 == "Pipe Shotgun Blueprint")
                {
                    result = "土炮蓝图";
                }
                else if (str1 == "Revolver")
                {
                    result = "左轮";
                }
                else if (str1 == "Revolver Blueprint")
                {
                    result = "左轮蓝图";
                }
                else if (str1 == "Wood")
                {
                    result = "木头";
                }
                else if (str1 == "Wood Planks")
                {
                    result = "木板";
                }
                else if (str1 == "Stones")
                {
                    result = "碎石头";
                }
                else if (str1 == "Sulfur Ore")
                {
                    result = "硫磺石";
                }
                else if (str1 == "Metal Ore")
                {
                    result = "铁矿";
                }
                else if (str1 == "Cloth")
                {
                    result = "皮";
                }
                else if (str1 == "Blood")
                {
                    result = "血袋";
                }
                else if (str1 == "Animal Fat")
                {
                    result = "脂肪";
                }
                else if (str1 == "Raw Chicken Breast")
                {
                    result = "生肉";
                }
                else if (str1 == "Charcoal")
                {
                    result = "木炭";
                }
                else if (str1 == "Leather")
                {
                    result = "烧过的布";
                }
                else if (str1 == "Weapon Stats")
                {
                    result = "武器属性";
                }
                else if (str1 == "Sulfur")
                {
                    result = "硫磺";
                }
                else if (str1.Contains("you killed yourself"))
                {
                    result = "你自杀了，不要灰心，崛起于微末！";
                }
                else if (str1.Contains("No item description available"))
                {
                    result = "没有介绍哦";
                }
                else if (str1.IndexOf("Bullet") != -1 && str1.IndexOf("Cold") != -1)
                {
                    result = "防 弹\r\n防 暴\r\n防 爆\r\n防 化\r\n防 寒";
                }
                else if (str1.IndexOf("This is a weapon") != -1)
                {
                    result = "这是一把武器，把它拖到你的屏幕下方的格子里，按相应的数字键使用它";
                }
                else if (str1.IndexOf("Blueprint. Study it to") != -1)
                {
                    result = "这是一个物品蓝图，学习后你就可以制作它";
                }
                else if (str1.IndexOf("This is a beverage") != -1)
                {
                    result = "一种饮料";
                }
                else if (str1.IndexOf("This is a Medical item") != -1)
                {
                    result = "一种药物";
                }
                else if (str1.IndexOf("This is a food item") != -1)
                {
                    result = "一种食物";
                }
                else if (str1.IndexOf("Calories") != -1)
                {
                    result = str1.Replace("Calories", "食物");
                }
                else if (str1.IndexOf("Water") != -1)
                {
                    result = str1.Replace("Water", "水");
                }
                else if (str1.IndexOf("Rads") != -1)
                {
                    result = str1.Replace("Rads", "辐射值");
                }
                else if (str1.IndexOf("Health") != -1)
                {
                    result = str1.Replace("Health", "生命");
                }
                else
                {
                    if (str1.IndexOf("Head,") != -1)
                    {
                        str1 = str1.Replace("Head", "头");
                    }
                    if (str1.IndexOf("Chest,") != -1)
                    {
                        str1 = str1.Replace("Chest", "身");
                    }
                    if (str1.IndexOf("Legs") != -1)
                    {
                        str1 = str1.Replace("Legs,", "腿");
                    }
                    if (str1.IndexOf("Feet") != -1)
                    {
                        result = str1.Replace("Feet", "脚");
                    }
                    else if (str1.IndexOf("Occupied") != -1)
                    {
                        result = str1.Replace("Occupied", "占用");
                    }
                    else if (str1.IndexOf("Condition") != -1)
                    {
                        result = str1.Replace("Condition", "耐久");
                    }
                    else if (str1.IndexOf("Fire Rate") != -1)
                    {
                        result = str1.Replace("Fire Rate", "射击速度");
                    }
                    else if (str1.IndexOf("Damage") != -1)
                    {
                        result = str1.Replace("Damage", "伤害");
                    }
                    else if (str1.IndexOf("Recoil") != -1)
                    {
                        result = str1.Replace("Recoil", "后坐力");
                    }
                    else if (str1.IndexOf("Range") != -1)
                    {
                        result = str1.Replace("Range", "射击距离");
                    }
                    else if (str1.IndexOf("Low Quality Metal") != -1)
                    {
                        result = str1.Replace("Low Quality Metal", "铁皮");
                    }
                    else if (str1.IndexOf("Heals") != -1 && str1.IndexOf("Health.") != -1)
                    {
                        str1 = str1.Replace("Heals", "提供");
                        result = str1.Replace("Health", "点生命值");
                    }
                    else if (str1.IndexOf("No item description") != -1)
                    {
                        result = "无物品详情";
                    }
                    else if (str1.IndexOf("Ammunition for a") != -1)
                    {
                        result = "一种子弹";
                    }
                    else if (str1.IndexOf("weapon (with at least") != -1)
                    {
                        result = "武器配件";
                    }
                    else if (str1.IndexOf("own blood, perhaps to") != -1)
                    {
                        result = "超级抽血机，提供额外物品";
                    }
                    else if (str1.IndexOf("Explosive used in") != -1)
                    {
                        result = "一种材料";
                    }
                    else if (str1.IndexOf("item to learn how to") != -1)
                    {
                        result = "用于学习物品";
                    }
                    else if (str1.IndexOf("anti-radioactive") != -1)
                    {
                        result = "一种药物";
                    }
                    else if (str1.IndexOf("place") != -1)
                    {
                        result = "建筑部件";
                    }
                    else if (str1.IndexOf("Snaps to foundation") != -1)
                    {
                        result = "建筑部件";
                    }
                    else if (str1.IndexOf("armor. Drag it to it's") != -1)
                    {
                        result = "一件装备";
                    }
                    else
                    {
                        result = str1;
                    }
                }
                return result;
            }
        }
    }
}
