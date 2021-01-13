using HarmonyLib;
using UnityEngine;


namespace ParticleOverdrive.Patches
{
    [HarmonyPatch(typeof(SaberClashEffect), "Start")]
    class SaberClashEffectStart
    {
        [HarmonyPostfix]
        internal static void SaberClashEffectStartPostfix(ref SaberClashEffect __instance)
        {
            ParticleSystem glowPS = Plugin.GetSaberClashGlowPS(__instance);
            ParticleSystem sparklePS = Plugin.GetSaberClashSparklePS(__instance);

            ParticleSystem.EmissionModule glowEM = glowPS.emission;
            ParticleSystem.EmissionModule sparkleEM = sparklePS.emission;

            ParticleSystem.MainModule glowMain = glowPS.main;
            ParticleSystem.MainModule sparkleMain = sparklePS.main;

            if (!Plugin.ClashGlow)
            {
                glowMain.startLifetimeMultiplier = 0;
            }

            sparkleEM.rateOverDistanceMultiplier = sparkleEM.rateOverDistanceMultiplier * Plugin.ClashParticleMultiplier;
            sparkleEM.rateOverTimeMultiplier = sparkleEM.rateOverTimeMultiplier * Plugin.ClashParticleMultiplier;
            sparkleMain.maxParticles = int.MaxValue;
            sparkleMain.startLifetimeMultiplier = sparkleMain.startLifetimeMultiplier * Plugin.ClashParticleLifetimeMultiplier;
            sparkleMain.startSizeMultiplier = sparkleMain.startSizeMultiplier * Plugin.ClashParticleSizeMultiplier;
        }
    }
}
