using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Player.Lobby;
using Player;
using Props.Door;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreLocks.Patches
{

    [HarmonyPatch(typeof(DoorInteractable))]
    internal class DoorinteractablePatch
    {
        [HarmonyPatch("UnlockDoor")]
        // Token: 0x0600000A RID: 10 RVA: 0x00002197 File Offset: 0x00000397
        private static void Prefix(ref DoorController __instance)//, ref int ___NetworkisLocked)// DoorInteractable __instance)
        {
            System.Diagnostics.Debug.WriteLine("UnlockDoor");
            if (NoMoreLocksBase.Instance.configManager.ForceDoorsUnlocked == true)
            {
                {
                    __instance.NetworkisLocked = false;
                    //System.Diagnostics.Debug.WriteLine("HELP");
                }
            }
        }
    }
    [HarmonyPatch(typeof(DoorInteractable))]
    internal class DoorinteractablePatch2
    {
        [HarmonyPatch("CanChangeLockState")]
        // Token: 0x0600000A RID: 10 RVA: 0x00002197 File Offset: 0x00000397
        private static bool Prefix(ref DoorInteractable __instance)//, ref int ___NetworkisLocked)// DoorInteractable __instance)
        {
            //object everyonecanlock = Traverse.Create(__instance).Field("everyoneCanLock").GetValue();
            //System.Diagnostics.Debug.WriteLine("CanChangeLockState" + " " + everyonecanlock.ToString());

            LobbyPlayer networkLobbyPlayer = NoMoreLocksBase.Instance.GetLobbyManager().GetLocalPlayer();


            //System.Diagnostics.Debug.WriteLine("lobbyplayer");
            PlayerRole playerRole = networkLobbyPlayer.NetworkplayerRole;
            //System.Diagnostics.Debug.WriteLine("playerrole");

            PlayerController playerController = networkLobbyPlayer.NetworkplayerController.GetComponent<PlayerController>();

            //System.Diagnostics.Debug.WriteLine("playercontroller");
            Usable usable = playerController.GetCurrentUsable();

            //System.Diagnostics.Debug.WriteLine("getcurrentusable");
            SubRole playerSubRole = networkLobbyPlayer.NetworksubRole;

            //System.Diagnostics.Debug.WriteLine("subrole");
            if (usable != null) System.Diagnostics.Debug.WriteLine(networkLobbyPlayer.Networkusername + " : " + networkLobbyPlayer.NetworksteamUsername + " : " + playerRole + " : " + usable.NetworkinteractableName);
            else System.Diagnostics.Debug.WriteLine(networkLobbyPlayer.Networkusername + " : " + networkLobbyPlayer.NetworksteamUsername + " : " + playerRole);
            //System.Diagnostics.Debug.WriteLine("debuglines");
            ConfigManager config = NoMoreLocksBase.Instance.configManager;
            //System.Diagnostics.Debug.WriteLine("configmanager");
            if (usable != null)
            {
                if (usable.GetType() == typeof(KeyController))
                {
                    if (config.KeyRingKeys == true) return true;
                }
            }

            if (playerSubRole == SubRole.Assistant)
            {
                if (config.AssistantKeys == true) return true;
            }

            switch (playerRole)
            {
                case PlayerRole.Specialist:
                case PlayerRole.Slacker:
                    if (config.WorkerKeys == false) return false;
                    return true;
                case PlayerRole.Manager:
                    if (config.ManagerKeys == false) return false;
                    return true;
                case PlayerRole.Janitor:
                    if (config.JanitorKeys == false) return false;
                    return true;
                default:
                    break;
            }
            return false;
        }
    }
}