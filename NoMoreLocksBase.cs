using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using NoMoreLocks;
using Player.Lobby;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//using DDSSModManager;

namespace NoMoreLocks;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class NoMoreLocksBase : BasePlugin
{
    internal static NoMoreLocksBase Instance;
    public static ManualLogSource NoMoreLocksLog;
    internal ConfigManager configManager;
    public LobbyManager lobbyManager;
    public List<LobbyPlayer> lobbyPlayers;

    //D:\SteamLibrary\steamapps\common\Dale&Dawson\BepInEx\interop

    public override void Load()
    {
        configManager = new ConfigManager();
        configManager.Configure(Config);
        if (Instance == null)
        {
            Instance = this;
        }

        NoMoreLocksLog = base.Log;
        NoMoreLocksLog.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loading...");
        Harmony harmony = new Harmony("NoMoreLocks");
        harmony.PatchAll();
        NoMoreLocksLog.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
    public void SetLobbyManager(LobbyManager lobbyManager)
    {
        this.lobbyManager = lobbyManager;
    }
    public void AddLobbyPlayer(LobbyPlayer player)
    {
        lobbyPlayers.Add(player);
    }
    public LobbyManager GetLobbyManager()
    {
        if (lobbyManager != null) return lobbyManager;
        lobbyManager = GameObject.FindFirstObjectByType<LobbyManager>();
        if (lobbyManager == null) System.Diagnostics.Debug.WriteLine("Could Not Find Lobby Manager");
        else System.Diagnostics.Debug.WriteLine("Updated");
        return lobbyManager;
    }
}