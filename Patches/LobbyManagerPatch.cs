﻿using HarmonyLib;
using Props.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreLocks.Patches
{
    [HarmonyPatch(typeof(LobbyManager))]
    internal class LobbyManagerPatch
    {
        
        [HarmonyPatch("StartGame")]
        // Token: 0x0600000A RID: 10 RVA: 0x00002197 File Offset: 0x00000397
        private static void Prefix(ref LobbyManager __instance)
        {

            System.Diagnostics.Debug.WriteLine("LOBBY MANAGER FOUND");
            NoMoreLocksBase baseplugin = NoMoreLocksBase.Instance;
            baseplugin.SetLobbyManager(__instance);
        }
        
    }
}