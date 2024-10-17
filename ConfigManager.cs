using BepInEx.Configuration;
using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace NoMoreLocks
{

    internal class ConfigManager
    {

        private ConfigEntry<bool> configJanitorKeys;
        internal bool JanitorKeys { get { return configJanitorKeys.Value; } set { configJanitorKeys.Value = value; } }
        private ConfigEntry<bool> configManagerKeys;
        internal bool ManagerKeys { get { return configManagerKeys.Value; } set { configManagerKeys.Value = value; } }
        private ConfigEntry<bool> configAssistantKeys;
        internal bool AssistantKeys { get { return configAssistantKeys.Value; } set { configAssistantKeys.Value = value; } }
        private ConfigEntry<bool> configWorkerKeys;
        internal bool WorkerKeys { get { return configWorkerKeys.Value; } set { configWorkerKeys.Value = value; } }
        private ConfigEntry<bool> configRemoveKeys;
        internal bool KeyRingKeys { get { return configRemoveKeys.Value; } set { configRemoveKeys.Value = value; } }
        private ConfigEntry<bool> configDoKeysWork;
        internal bool NoKeys { get { return configRemoveKeys.Value; } set { configRemoveKeys.Value = value; } }
        private ConfigEntry<bool> configForceDoorsUnlocked;
        internal bool ForceDoorsUnlocked { get { return configForceDoorsUnlocked.Value; } set { configForceDoorsUnlocked.Value = value; } }
        internal ConfigManager()
        {

        }
        internal void Configure(ConfigFile configfile)
        {
            configJanitorKeys = configfile.Bind("General.Toggles", "JanitorKeys", true, "Whether or not Janitors can lock doors");
            configManagerKeys = configfile.Bind("General.Toggles", "ManagerKeys", true, "Whether or not Managers can lock doors");
            configAssistantKeys = configfile.Bind("General.Toggles", "AssistantKeys", false, "Whether or not Managers can lock doors");
            configWorkerKeys = configfile.Bind("General.Toggles", "WorkerKeys", false, "Whether or not Slackers/Specialist can lock doors");
            configRemoveKeys = configfile.Bind("General.Toggles", "RemoveKeys", false, "Removes the Keys from the game");
            configDoKeysWork = configfile.Bind("General.Toggles", "DoesKeyringWork", true, "Does the Keys Object work for doors");
            configForceDoorsUnlocked = configfile.Bind("General.Toggles", "ForceDoorsUnlocked", false, "Forces all doors to be constantly unlocked");
            System.Diagnostics.Debug.WriteLine("Config Complete");
        }
    }
}
