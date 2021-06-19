using System.Linq;
using Assets.CoreScripts;
using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using ExtraColorsMod.Patches;
using ExtraColorsMod.Types;
using Reactor;

namespace ExtraColorsMod
{
    [BepInPlugin(Id, Name, Version)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public class ExtraColorsModPlugin : BasePlugin
    {
        public const string Id = "mengtube.amongus.extracolorsmod";
        public const string Name = "Extra Colors Mod";
        public const string Version = "1.0.0";

        public Harmony Harmony { get; } = new Harmony(Id);

        public override void Load()
        {
            RegisterCustomRpcAttribute.Register(this);
            RegisterInIl2CppAttribute.Register();
            
            ColorSelectionPatches.Initialize();
            
            Harmony.PatchAll();

            Reactor.Patches.ReactorVersionShower.TextUpdated += textMeshPro
             => textMeshPro.text = "<color=#00FA9A>Extra Colors Mod</color> \n<color=#FFD11AFF>By MengTube</color>";
        }
    }

    public static class ExtraColorsMod
    {
        public static void AddColors(CustomColor[] customColors)
        {
            var frontColors = Palette.PlayerColors.ToList();
            var backColors = Palette.ShadowColors.ToList();
            var colorNames = Palette.ColorNames.ToList();
            var shortColorNames = Palette.ShortColorNames.ToList();
            
            foreach (var customColor in customColors)
            {
                if (customColor.Hidden) continue;
                
                frontColors.Add(customColor.FrontColor);
                backColors.Add(customColor.BackColor);
                colorNames.Add(customColor.ColorName);
                shortColorNames.Add(customColor.ShortColorName);
            }
            
            Palette.PlayerColors = frontColors.ToArray();
            Palette.ShadowColors = backColors.ToArray();
            Palette.ColorNames = colorNames.ToArray();
            Palette.ShortColorNames = shortColorNames.ToArray();
            MedScanMinigame.ColorNames = Palette.ColorNames;
            Telemetry.ColorNames = Palette.ColorNames;
            
            ColorSelectionPatches.CustomColors.AddRange(customColors);
        }

        public static void AddColor(CustomColor customColor)
        {
            Palette.PlayerColors = Palette.PlayerColors.AddItem(customColor.FrontColor).ToArray();
            Palette.ShadowColors = Palette.ShadowColors.AddItem(customColor.BackColor).ToArray();
            Palette.ColorNames = Palette.ColorNames.AddItem(customColor.ColorName).ToArray();
            Palette.ShortColorNames = Palette.ShortColorNames.AddItem(customColor.ShortColorName).ToArray();
            MedScanMinigame.ColorNames = Palette.ColorNames;
            Telemetry.ColorNames = Palette.ColorNames;
            
            ColorSelectionPatches.CustomColors.Add(customColor);
        }
    }
}
