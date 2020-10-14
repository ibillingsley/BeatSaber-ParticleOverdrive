using HarmonyLib;
using UnityEngine;

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

            sparkleParticlesCount = Mathf.FloorToInt(sparkleParticlesCount * Plugin.SlashParticleMultiplier);
            explosionParticlesCount = Mathf.FloorToInt(explosionParticlesCount * Plugin.ExplosionParticleMultiplier);
            lifetimeMultiplier *= Plugin.SlashParticleLifetimeMultiplier;

            if (Plugin.RainbowParticles)
                color = UnityEngine.Random.ColorHSV(0, 1, 1, 1, 1, 1, 1, 1);

            ParticleSystem.MainModule slashMain = sparklesPS.main;
            slashMain.maxParticles = int.MaxValue;
            //slashMain.startSpeedMultiplier = 200f;

            ParticleSystem.MainModule explosionMain = explosionPS.main;
            explosionMain.maxParticles = int.MaxValue;
            explosionMain.startLifetimeMultiplier = Plugin.ExplosionParticleLifetimeMultiplier;
        }
    }

}
