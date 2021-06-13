using ExtraColorsMod.MonoBehaviours;
using ExtraColorsMod.Types;
using Reactor.Extensions;
using UnityEngine;

namespace ExtraColorsMod.Extensions
{
    public static class GameObjectExtensions
    {
        public static void SetCyclicVisorColor(this GameObject gameObject, CyclicColor cyclicColor)
        {
            var dynamicColor = gameObject.GetComponent<DynamicVisorColor>() ??
                               gameObject.AddComponent<DynamicVisorColor>();
            
            dynamicColor.CyclicColor = cyclicColor;
        }
        
        public static void SetCyclicColor(this GameObject gameObject, CyclicColor cyclicColor)
        {
            var dynamicColor = gameObject.GetComponent<DynamicColor>() ?? gameObject.AddComponent<DynamicColor>();
            
            dynamicColor.CyclicColor = cyclicColor;
        }

        public static void ClearCyclicColor(this GameObject gameObject)
        {
            gameObject.GetComponent<DynamicVisorColor>()?.DestroyImmediate();
            gameObject.GetComponent<DynamicColor>()?.DestroyImmediate();
        }
    }
}