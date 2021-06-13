using ExtraColorsMod.Patches;
using ExtraColorsMod.Types;
using Reactor;

namespace ExtraColorsMod.Extensions
{
    public static class CustomColorExtensions
    {
        public static bool TryGetCustomColorById(int colorId, out CustomColor customColor)
        {
            var originalPaletteLength = ColorSelectionPatches.OriginalPaletteLength;

            var isCustomColor = colorId >= originalPaletteLength;
            customColor = isCustomColor ? ColorSelectionPatches.CustomColors[colorId - originalPaletteLength] : null;

            return isCustomColor;
        }
    }
}