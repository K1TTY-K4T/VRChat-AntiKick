using Harmony;
using MelonLoader;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using VRCSDK2;
using System.Net.Http;
using VRC;
using VRTK.Controllables.ArtificialBased;
using Transmtn.DTO;
using UnityEngine.UI;
using VRC.Core;
using VRC.UI;
using VRC.Udon;
using ThirdParty.iOS4Unity;
using BestHTTP;
using Il2CppSystem.Threading.Tasks;
using Transmtn;
using System.Threading.Tasks;
using Il2CppSystem.Threading;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Il2CppMono.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using UnityEngine.SceneManagement;
using DiskWars;
using UnhollowerRuntimeLib;
using UnityEngine.Events;
using VRC.SDKBase;
using VRCSDK2.Validation.Performance.Scanners;
using Steamworks;
using WebSocketSharp;
using Transmtn.DTO.Notifications;
using Il2CppSystem.Security.Cryptography;
using UnhollowerBaseLib;
using VRC.UserCamera;
using Harmony.ILCopying;
using static VRC.SDKBase.VRC_EventHandler;
using ExitGames.Client.Photon;
using RootMotion.Dynamics;
using VRC.Animation;

namespace AntiKickStuff
{

    public class AntiKick : MelonMod
    {
        public override void OnApplicationStart()
        {ApplyPatches();
        }
        public override void OnUpdate()
      {
      }
        public static void ApplyPatch(Type x,string Method,string PatchMethod){
        HarmonyInstance instance=HarmonyInstance.Create(string.Empty);
        instance.Patch(x.GetMethod(Method),GetPatch(PatchMethod),null,null);}
        public static HarmonyMethod GetPatch(string name) {
        return new HarmonyMethod(typeof(AntiKick).GetMethod(name,BindingFlags.Static|BindingFlags.NonPublic));
        }
        private static void EventPatches(){
            try{
            }
            catch(Exception e){System.Console.WriteLine(e);}
        }
        private static void ApplyPatches()
        {
            try
            {
                EventPatches();
            ApplyPatch(typeof(ModerationManager),"KickUserRPC","AntiKick");
            ApplyPatch(typeof(ModerationManager),"Method_Private_Void_Boolean_PDM_0","KickPatch");
            ApplyPatch(typeof(ModerationManager),"Method_Public_Boolean_String_String_String_1","CanEnterPublicWorldsPatch");
            ApplyPatch(typeof(ModerationManager),"Method_Public_Boolean_String_String_String_0","IsKickedFromWorldPatch");
            ApplyPatch(typeof(ModerationManager),"WarnUserRPC","WarnPatch");
            ApplyPatch(typeof(ModerationManager),"Method_Public_Boolean_String_8","IsBlockedEitherWayPatch");
            foreach(var methodInfo in typeof(ModerationManager).GetMethods()){
                if(methodInfo.Name.Contains("Method_Private_Void_String_Boolean_Player_")){ApplyPatch(typeof(ModerationManager),methodInfo.Name,"allKickPatch");
                }
            }
            foreach(var methodInfo in typeof(ModerationManager).GetMethods()){
                if(methodInfo.Name.Contains("ApiPlayerModeration_Action_1_Strin")){ApplyPatch(typeof(ModerationManager),methodInfo.Name,"allKickPatch1");
                }
            }
            ApplyPatch(typeof(ModerationManager),"Method_Private_Void_String_ModerationType_String_ModerationTimeRange_String_String_Action_1_ApiModelContainer_1_ApiModeration_Action_1_ApiModelContainer_1_ApiModeration_PDM_0","pleaseEndThis");
            ApplyPatch(typeof(ModerationManager),"Method_Private_Void_String_ModerationType_String_ModerationTimeRange_String_String_Action_1_ApiModelContainer_1_ApiModeration_Action_1_ApiModelContainer_1_ApiModeration_PDM_0","pleaseEndThis");
            ApplyPatch(typeof(ModerationManager),"ModForceOffMicRPC","ModForceOffMicPatch");
            ApplyPatch(typeof(ModerationManager),"MuteChangeRPC","MutePatch");
            ApplyPatch(typeof(VRCSDK2.VRC_EventHandler),"InternalTriggerEvent","TriggerEvent");
                System.Console.WriteLine("all patches were applied successfully! (u cant b voted or kicked by world author/instance creator)");
            }
            catch(Exception e){System.Console.WriteLine(e.ToString());}
            finally{}
        }
        private static bool allKickPatch(ref string __0,ref bool __1,ref Player __2){return false;}
        private static bool allKickPatch1(ref string __0,ref ApiPlayerModeration.ModerationType __1,ref Il2CppSystem.Action<ApiPlayerModeration> __2,ref Il2CppSystem.Action<string> __3){return false;}
        private static bool pleaseEndThis(ref string __0,ref ApiModeration.ModerationType __1,ref string __2,ref ApiModeration.ModerationTimeRange __3,ref string __4,ref string __5,ref Il2CppSystem.Action<ApiModelContainer<ApiModeration>> __6,ref Il2CppSystem.Action<ApiModelContainer<ApiModeration>> __7){return false;}
       

        private static bool IsKickedFromWorldPatch(ref bool __result)
        {
            return false;
        }
        private static bool AntiKickkk(ref string __0, ref string __1, ref string __2, ref string __3, ref Player __4)
        {
                if (__4.field_Private_APIUser_0.id == APIUser.CurrentUser.id)
                    return false;
            return false;
        }
        
        private static bool WarnPatch(ref string __0, ref string __1, ref Player __2)
        {
            return false;
        }
        private static bool MutePatch(ref string __0, bool __1, ref Player __2)
        {
            return false;
        }
        private static bool KickPatch(bool __0)
        {
            return false;
        } 

        private static bool ModForceOffMicPatch(ref string __0, ref Player __1)
        {return false;
        }
    }
}
