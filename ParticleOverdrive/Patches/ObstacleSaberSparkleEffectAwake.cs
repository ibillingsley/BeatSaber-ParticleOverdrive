using HarmonyLib;
using UnityEngine;
using Logger = ParticleOverdrive.Misc.Logger;


namespace ParticleOverdrive.Patches
{
    [HarmonyPatch(typeof(ObstacleSaberSparkleEffect), "Awake")]
    class ObstacleSaberSparkleEffectAwake
    {
        [HarmonyPostfix]
        internal static void ObstacleSaberSparkleEffectStartPostfix(ref ObstacleSaberSparkleEffect __instance)
        {
            ParticleSystem sparklePS = Plugin.GetObstacleSaberSparklePS(__instance);

            ParticleSystem.EmissionModule sparkleEM = sparklePS.emission;
            ParticleSystem.MainModule sparkleMM = sparklePS.main;

            sparkleEM.rateOverDistanceMultiplier = sparkleEM.rateOverDistanceMultiplier * Plugin.ObstacleParticleMultiplier;
            sparkleEM.rateOverTimeMultiplier = sparkleEM.rateOverTimeMultiplier * Plugin.ObstacleParticleMultiplier;
            sparkleMM.maxParticles = int.MaxValue;
            sparkleMM.startLifetimeMultiplier = sparkleMM.startLifetimeMultiplier * Plugin.ObstacleParticleLifetimeMultiplier;
            sparkleMM.startSizeMultiplier = sparkleMM.startSizeMultiplier * Plugin.ObstacleParticleSizeMultiplier;
        }
    }
}
