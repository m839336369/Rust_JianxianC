using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RustBuster2016;
using RustBuster2016.API.Events;
using UnityEngine;

namespace JianxianC.Core.AuthMe
{
    public class AuthMe
    {
        static internal GameObject MainGameObject;
        static internal GameObject AuthGameObject;
        static internal AuthChecker Checker;    
        public AuthMe()
        {
            MainGameObject = new GameObject();
            AuthGameObject = new GameObject();
            MainGameObject.AddComponent<CharacterWaiter>();
            UnityEngine.Object.DontDestroyOnLoad(MainGameObject);
            UnityEngine.Object.DontDestroyOnLoad(AuthGameObject);
        }

        ~AuthMe()
        {
            // Just incase.
            /*if (PlayerClient.GetLocalPlayer() != null && PlayerClient.GetLocalPlayer().controllable != null)
            {
                Character player = PlayerClient.GetLocalPlayer().controllable.GetComponent<Character>();
                if (player != null)
                {
                    player.lockMovement = false;
                    player.lockLook = false;
                }
            }*/

            if (Checker != null)
            {
                Checker.enabled = false;
            }

            if (AuthGameObject != null)
            {
                UnityEngine.Object.Destroy(AuthGameObject);
                AuthGameObject = null;
            }
            
            if (MainGameObject != null)
            {
                UnityEngine.Object.Destroy(MainGameObject);
                MainGameObject = null;
            }
            
            if (Checker != null)
            {
                UnityEngine.Object.Destroy(Checker);
                Checker = null;
            }
        }
        
        internal static void StartMyRPCs()
        {
            if (MainGameObject != null) {UnityEngine.Object.Destroy(MainGameObject);}
            // Add our Behaviour that is containing all the RPC methods to the player.
            Checker = PlayerClient.GetLocalPlayer().gameObject.AddComponent<AuthChecker>();
        }
    }
}