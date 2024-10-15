using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using danddplugin;
using Props.Door;
using LevelManagement;
using System.Runtime.CompilerServices;
using BepInEx.Logging;
using Il2CppInterop.Runtime;
using Room;

namespace danddplugin
{

    [HarmonyPatch(typeof(DoorController))]
    internal class DoorLockPatch
    {

        [HarmonyPatch("RequestDoorState")]
        // Token: 0x0600000A RID: 10 RVA: 0x00002197 File Offset: 0x00000397
        private static void Prefix(ref DoorController __instance)//, ref int ___NetworkisLocked)// DoorInteractable __instance)
        {
            __instance.NetworkisLocked = false;
            // Debug.LogWarning("Help");
            System.Diagnostics.Debug.WriteLine("HELP");

        }
    }
    [HarmonyPatch(typeof(DoorController))]
    internal class DoorLockPatch2
    {

        [HarmonyPatch("Update")]
        // Token: 0x0600000A RID: 10 RVA: 0x00002197 File Offset: 0x00000397
        private static void Prefix(ref DoorController __instance)//, ref int ___NetworkisLocked)// DoorInteractable __instance)
        {
            __instance.NetworkisLocked = false;
            // Debug.LogWarning("Help");
           // System.Diagnostics.Debug.WriteLine("HELP");

        }
    }

}