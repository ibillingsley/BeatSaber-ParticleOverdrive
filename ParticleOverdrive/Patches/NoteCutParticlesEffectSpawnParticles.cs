using HarmonyLib;
using UnityEngine;
using Logger = ParticleOverdrive.Misc.Logger;

namespace ParticleOverdrive.Patches
{
    [HarmonyPatch(typeof(NoteCutParticlesEffect))]
    [HarmonyPatch("SpawnParticles")]
    class NoteCutParticlesEffectSpawnParticles
    {
        internal static void Prefix(ref NoteCutParticlesEffect __instance, ref Color32 color, ref int sparkleParticlesCount, ref int explosionParticlesCount, ref float lifetimeMultiplier)
        {
            ParticleSystem explosionPS = Plugin.GetExplosionPS(__instance);
            ParticleSystem sparklesPS = Plugin.GetSparklesPS(__instance);
            ParticleSystem corePS = Plugin.GetCorePS(__instance);

            sparkleParticlesCount = Mathf.FloorToInt(sparkleParticlesCount * Plugin.SlashParticleMultiplier);
            explosionParticlesCount = Mathf.FloorToInt(explosionParticlesCount * Plugin.ExplosionParticleMultiplier);
            lifetimeMultiplier *= Plugin.SlashParticleLifetimeMultiplier;

            if (Plugin.RainbowParticles)
                color = UnityEngine.Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);

            ParticleSystem.MainModule slashMain = sparklesPS.main;
            //Logger.Log("slash startSizeMultiplier is: " + slashMain.startSizeMultiplier, Logger.LogLevel.Debug);
            slashMain.maxParticles = int.MaxValue;
            // default start size multiplier is 0.015
            slashMain.startSizeMultiplier = Plugin.SlashParticleSizeMultiplier * 0.015f;
            //slashMain.startSpeedMultiplier = 200f;

            ParticleSystem.MainModule explosionMain = explosionPS.main;
            //Logger.Log("explosion startSizeMultiplier is: " + explosionMain.startSizeMultiplier, Logger.LogLevel.Debug);
            explosionMain.maxParticles = int.MaxValue;
            // default start lifetime multiplier is 0.6
            explosionMain.startLifetimeMultiplier = Plugin.ExplosionParticleLifetimeMultiplier * 0.6f;
            // default start size multiplier is 0.015
            explosionMain.startSizeMultiplier = Plugin.ExplosionParticleSizeMultiplier * 0.015f;

            ParticleSystem.MainModule coreMain = corePS.main;
            if (!Plugin.NoteCoreParticles)
            {
                coreMain.startLifetimeMultiplier = 0;
            }
        }
    }

}
