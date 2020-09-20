using System;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using ParticleOverdrive.Misc;
using BS_Utils.Utilities;
using System.Reflection.Emit;
using System.Reflection;

namespace ParticleOverdrive.Patches
{
    [HarmonyPatch(typeof(NoteCutParticlesEffect))]
    [HarmonyPatch("SpawnParticles")]
    class NoteCutParticlesEffectSpawnParticles
    {
        internal static void Prefix(ref NoteCutParticlesEffect __instance, ref Color32 color, ref int sparkleParticlesCount, ref int explosionParticlesCount, ref float lifetimeMultiplier)
        {
            ParticleSystem explosionPS = Plugin.GetExplosionPS(__instance);
            ParticleSystem[] sparklesPSAry = Plugin.GetSparklesPS(__instance);

            sparkleParticlesCount = Mathf.FloorToInt(sparkleParticlesCount * Plugin.SlashParticleMultiplier);
            explosionParticlesCount = Mathf.FloorToInt(explosionParticlesCount * Plugin.ExplosionParticleMultiplier);
            lifetimeMultiplier *= Plugin.SlashParticleLifetimeMultiplier;

            if (Plugin.RainbowParticles)
                color = UnityEngine.Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);

            for (int i = 0; i < sparklesPSAry.Length; i++)
            {
                ParticleSystem.MainModule slashMain = sparklesPSAry[i].main;
                slashMain.maxParticles = int.MaxValue;
                //slashMain.startSpeedMultiplier = 200f;
            }

            ParticleSystem.MainModule explosionMain = explosionPS.main;
            explosionMain.maxParticles = int.MaxValue;
            explosionMain.startLifetimeMultiplier = Plugin.ExplosionParticleLifetimeMultiplier;
        }
    }

}
