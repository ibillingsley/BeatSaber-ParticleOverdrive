using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            glowMain.maxParticles = int.MaxValue;

            sparkleEM.rateOverDistanceMultiplier = sparkleEM.rateOverDistanceMultiplier * Plugin.ClashParticleMultiplier;
            sparkleEM.rateOverTimeMultiplier = sparkleEM.rateOverTimeMultiplier * Plugin.ClashParticleMultiplier;
            sparkleMain.maxParticles = int.MaxValue;
            sparkleMain.startLifetimeMultiplier = Plugin.ClashParticleLifetimeMultiplier;
        }
    }
}
