using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Props.Door;
using LevelManagement;
using System.Runtime.CompilerServices;
using BepInEx.Logging;
using Il2CppInterop.Runtime;
using Room;
using Mirror;
using Player.Lobby;
using Player;

namespace NoMoreLocks.Patches
{

    [HarmonyPatch(typeof(DoorController))]
    internal class DoorControllerPatch
    {
        [HarmonyPatch("RequestDoorState")]
        // Token: 0x0600000A RID: 10 RVA: 0x00002197 File Offset: 0x00000397
        private static void Prefix(ref DoorController __instance)//, ref int ___NetworkisLocked)// DoorInteractable __instance)
        {
            System.Diagnostics.Debug.WriteLine("RequestDoorState");
            if (NoMoreLocksBase.Instance.configManager.ForceDoorsUnlocked == true)
            {
                {
                    __instance.NetworkisLocked = false;
                    //System.Diagnostics.Debug.WriteLine("HELP");
                }
            }
        }
    }
    [HarmonyPatch(typeof(DoorController))]
    internal class DoorControllerPatch2
    {
        [HarmonyPatch("Update")]
        // Token: 0x0600000A RID: 10 RVA: 0x00002197 File Offset: 0x00000397
        private static void Prefix(ref DoorController __instance)//, ref int ___NetworkisLocked)// DoorInteractable __instance)
        {
            if (NoMoreLocksBase.Instance.configManager.ForceDoorsUnlocked == true)
            {
                {
                    __instance.NetworkisLocked = false;

                }
            }
        }
    }
    internal class DoorControllerPatch3
    {
        [HarmonyPatch("PlayerCanChangeLockState")]
        // Token: 0x0600000A RID: 10 RVA: 0x00002197 File Offset: 0x00000397
        private static bool Prefix(ref DoorController __instance, NetworkIdentity player)//, ref int ___NetworkisLocked)// DoorInteractable __instance)
        {

            System.Diagnostics.Debug.WriteLine("PlayerCanChangeLockState");
            PlayerController playerController = player.GetComponent<PlayerController>();
            LobbyPlayer networkLobbyPlayer = playerController.NetworklobbyPlayer;
            PlayerRole playerRole = networkLobbyPlayer.NetworkplayerRole;
            Usable usable = playerController.GetCurrentUsable();
            SubRole playerSubRole = networkLobbyPlayer.NetworksubRole;


            if (usable != null) System.Diagnostics.Debug.WriteLine(networkLobbyPlayer.Networkusername + " : " + networkLobbyPlayer.NetworksteamUsername + " : " + playerRole + " : " + usable.NetworkinteractableName);
            else System.Diagnostics.Debug.WriteLine(networkLobbyPlayer.Networkusername + " : " + networkLobbyPlayer.NetworksteamUsername + " : " + playerRole);

            ConfigManager config = NoMoreLocksBase.Instance.configManager;
            if (usable != null)
            {
                if (usable.GetType() == typeof(KeyController))
                {
                    if (config.KeyRingKeys == true) return true;
                }
            }

                if (playerSubRole == SubRole.Assistant)
            {
                if (config.AssistantKeys == true)return true;
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

            // we have the player network identity
            // we need the players LobbyPlayer
            //player role enum 0-none 1-specialist 2-slacker 3-manager 4-janitor 5-saboteur
            //LobbyPlayer lobbyPlayer;
            //lobbyPlayer.NetworkplayerRole.
        }
    }
}