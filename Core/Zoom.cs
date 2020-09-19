using System;
using Rust;
using UnityEngine;
namespace JianxianC.Core
{
    public class Zoom
    {
        public static GameObject LoadZoom;
        public static bool On=false;
        public Zoom()
        {
            LoadZoom = new GameObject();
            LoadZoom.AddComponent<ZoomGUIRustNoWipe>();
            UnityEngine.Object.DontDestroyOnLoad(LoadZoom);
        }
        ~Zoom()
        {
            bool flag = LoadZoom != null;
            if (flag)
            {
                On = false;
                LoadZoom.SetActive(false);
                UnityEngine.Object.Destroy(LoadZoom);
            }
        }
    }
    public class ZoomGUIRustNoWipe : uLink.MonoBehaviour
    {
        	// Token: 0x04000001 RID: 1
	public static bool onlytimemsg;

	// Token: 0x04000002 RID: 2
	public static bool mouse0;

	// Token: 0x04000003 RID: 3
	public static bool mouse1;

	// Token: 0x04000004 RID: 4
	public static float levelzoom;

	// Token: 0x04000005 RID: 5
	public static Texture2D Messagy;

	// Token: 0x04000006 RID: 6
	public static float counterseconds;
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        public void OnGUI()
        {
            bool flag = !PlayerClient.GetLocalPlayer() || !PlayerClient.GetLocalPlayer().controllable;
            if (flag)
            {
                ZoomGUIRustNoWipe.onlytimemsg = true;
                ZoomGUIRustNoWipe.levelzoom = 60f;
                ZoomGUIRustNoWipe.counterseconds = 10f;
                Zoom.On = false;
            }
            else
            {
                bool flag2 = !Zoom.On && ZoomGUIRustNoWipe.counterseconds >= 0f;
                if (flag2)
                {
                    GUI.DrawTexture(new Rect(600f, 200f, 116f, 54f), ZoomGUIRustNoWipe.Messagy, ScaleMode.StretchToFill);
                    ZoomGUIRustNoWipe.counterseconds -= Time.deltaTime;
                }
                else
                {
                    bool flag3 = !Zoom.On && ZoomGUIRustNoWipe.onlytimemsg;
                    if (flag3)
                    {
                        ZoomGUIRustNoWipe.onlytimemsg = false;
                    }
                    else
                    {
                        bool flag4 = PlayerClient.GetLocalPlayer() || (PlayerClient.GetLocalPlayer().controllable && Zoom.On);
                        if (flag4)
                        {
                            ZoomGUIRustNoWipe.mouse0 = false;
                            ZoomGUIRustNoWipe.mouse1 = false;
                            bool key = Input.GetKey(KeyCode.Mouse0);
                            if (key)
                            {
                                ZoomGUIRustNoWipe.mouse1 = true;
                            }
                            bool key2 = Input.GetKey(KeyCode.Mouse1);
                            if (key2)
                            {
                                ZoomGUIRustNoWipe.mouse0 = true;
                            }
                            bool keyUp = Input.GetKeyUp(KeyCode.Mouse0);
                            if (keyUp)
                            {
                                ZoomGUIRustNoWipe.mouse1 = false;
                            }
                            bool keyUp2 = Input.GetKeyUp(KeyCode.Mouse1);
                            if (keyUp2)
                            {
                                ZoomGUIRustNoWipe.mouse0 = false;
                            }
                        }
                        bool flag5 = ZoomGUIRustNoWipe.mouse1 && !ZoomGUIRustNoWipe.mouse0 && Zoom.On;
                        if (flag5)
                        {
                            Inventory component = PlayerClient.GetLocalPlayer().controllable.GetComponent<Inventory>();
                            this.ClearWeapon(component);
                            bool flag6 = ZoomGUIRustNoWipe.levelzoom > 60f;
                            if (flag6)
                            {
                                ZoomGUIRustNoWipe.levelzoom = 60f;
                            }
                            bool flag7 = ZoomGUIRustNoWipe.levelzoom < 0f;
                            if (flag7)
                            {
                                ZoomGUIRustNoWipe.levelzoom = 0f;
                            }
                            bool flag8 = ZoomGUIRustNoWipe.levelzoom >= 20f;
                            if (flag8)
                            {
                                ZoomGUIRustNoWipe.levelzoom = ZoomGUIRustNoWipe.levelzoom - Time.deltaTime - 0.3f;
                            }
                            bool flag9 = ZoomGUIRustNoWipe.levelzoom < 20f;
                            if (flag9)
                            {
                                ZoomGUIRustNoWipe.levelzoom = ZoomGUIRustNoWipe.levelzoom - Time.deltaTime - 0.05f;
                            }
                            bool flag10 = ZoomGUIRustNoWipe.levelzoom > 0f;
                            if (flag10)
                            {
                                HumanController component2 = PlayerClient.GetLocalPlayer().controllable.GetComponent<HumanController>();
                                CameraMount componentInChildren = component2.GetComponentInChildren<CameraMount>();
                                bool flag11 = componentInChildren != null;
                                if (flag11)
                                {
                                    HeadBob component3 = componentInChildren.GetComponent<HeadBob>();
                                    bool flag12 = component3 != null;
                                    if (flag12)
                                    {
                                        CameraFX mainCameraFX = CameraFX.mainCameraFX;
                                        bool flag13 = mainCameraFX != null;
                                        if (flag13)
                                        {
                                            mainCameraFX.SetFieldOfView(ZoomGUIRustNoWipe.levelzoom, 1f);
                                        }
                                    }
                                }
                            }
                        }
                        bool flag14 = ZoomGUIRustNoWipe.mouse0 && !ZoomGUIRustNoWipe.mouse1 && Zoom.On;
                        if (flag14)
                        {
                            Inventory component4 = PlayerClient.GetLocalPlayer().controllable.GetComponent<Inventory>();
                            this.ClearWeapon(component4);
                            bool flag15 = ZoomGUIRustNoWipe.levelzoom > 60f;
                            if (flag15)
                            {
                                ZoomGUIRustNoWipe.levelzoom = 60f;
                            }
                            bool flag16 = ZoomGUIRustNoWipe.levelzoom < 0f;
                            if (flag16)
                            {
                                ZoomGUIRustNoWipe.levelzoom = 0f;
                            }
                            bool flag17 = ZoomGUIRustNoWipe.levelzoom >= 20f;
                            if (flag17)
                            {
                                ZoomGUIRustNoWipe.levelzoom = ZoomGUIRustNoWipe.levelzoom + Time.deltaTime + 0.3f;
                            }
                            bool flag18 = ZoomGUIRustNoWipe.levelzoom < 20f;
                            if (flag18)
                            {
                                ZoomGUIRustNoWipe.levelzoom = ZoomGUIRustNoWipe.levelzoom + Time.deltaTime + 0.05f;
                            }
                            bool flag19 = ZoomGUIRustNoWipe.levelzoom > 0f;
                            if (flag19)
                            {
                                HumanController component5 = PlayerClient.GetLocalPlayer().controllable.GetComponent<HumanController>();
                                CameraMount componentInChildren2 = component5.GetComponentInChildren<CameraMount>();
                                bool flag20 = componentInChildren2 != null;
                                if (flag20)
                                {
                                    HeadBob component6 = componentInChildren2.GetComponent<HeadBob>();
                                    bool flag21 = component6 != null;
                                    if (flag21)
                                    {
                                        CameraFX mainCameraFX2 = CameraFX.mainCameraFX;
                                        bool flag22 = mainCameraFX2 != null;
                                        if (flag22)
                                        {
                                            mainCameraFX2.SetFieldOfView(ZoomGUIRustNoWipe.levelzoom, 1f);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void ClearWeapon(Inventory inve)
        {
            bool flag = inve != null && inve.activeItem != null && inve.activeItem.datablock != null;
            if (flag)
            {
                inve.activeItem.OnMovedTo(inve, 28);
            }
        }

    }
}