using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using System.Diagnostics;
using UnityEngine;
//using DDSSModManager;

namespace danddplugin;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    //D:\SteamLibrary\steamapps\common\Dale&Dawson\BepInEx\interop
    internal static new ManualLogSource Log;

    private ConfigEntry<string> configGreeting;
    private ConfigEntry<bool> configDisplayGreeting;
    public override void Load()
    {
        Harmony harmony = new Harmony("MultiJanitor");
        harmony.PatchAll();
        // Plugin startup logic
        Log = base.Log;
        Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

        configGreeting = Config.Bind("General",      // The section under which the option is shown
                                        "GreetingText",  // The key of the configuration option in the configuration file
                                        "Hello, world!", // The default value
                                        "A greeting text to show when the game is launched"); // Description of the option to show in the config file

        configDisplayGreeting = Config.Bind("General.Toggles",
                                            "DisplayGreeting",
                                            true,
                                            "Whether or not to show the greeting text");
        // Test code
        Log.LogInfo("Why hello there, world!");

        /*
        new ModRegistrationBuilder(this).SetPeerType(ModPeerType.HOST_ONLY).Register();
        ModRegistrationBuilder modregbuilder = new ModRegistrationBuilder(this);
        modregbuilder.SetPeerType(ModPeerType.HOST_ONLY);
        modregbuilder.SetCompatibilityVersion(new SemanticVersioning.Version("1.0.0"));
        modregbuilder.Register();
        */
    }
    void Start()
    {
        Application.Quit();
        Log = base.Log;
        Log.LogDebug("checkwithlog");
        System.Diagnostics.Debug.WriteLine("startcheck");
        System.Diagnostics.Debug.WriteLine("startcheck");
        System.Diagnostics.Debug.WriteLine("startcheck");
        System.Diagnostics.Debug.WriteLine("startcheck");
    }
}
/*
	<ItemGroup>
		<Reference Include="DDSSModManager">
			<HintPath>C:\Users\Charles\danddplugin\lib\DDSSModManager.dll</HintPath>
		</Reference>
	</ItemGroup>
*/