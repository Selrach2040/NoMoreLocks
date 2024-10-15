﻿using HarmonyLib;
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
using Props.Keys;
using Mirror;
using Props.Scripts;

namespace danddplugin
{
    [HarmonyPatch(typeof(Collectible))]
    internal class KeyBreaker
    {
        [HarmonyPatch("Start")]
        // Token: 0x0600000A RID: 10 RVA: 0x00002197 File Offset: 0x00000397
        private static void Prefix(ref Collectible __instance)//, ref int ___NetworkisLocked)// DoorInteractable __instance)
        {
            
            System.Diagnostics.Debug.WriteLine("Bye Keys");
            if (__instance.NetworkinteractableName == "Keys")
            {
                GameObject.Destroy(__instance.gameObject);
                System.Diagnostics.Debug.WriteLine("Bye Keys");
            }

        }
    }
}