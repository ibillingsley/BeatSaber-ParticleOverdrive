using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = ParticleOverdrive.Misc.Logger;


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

            //Logger.Log("clash startLifetimeMultiplier is: " + sparkleMain.startLifetimeMultiplier, Logger.LogLevel.Debug);
            //Logger.Log("clash startSizeMultiplier is: " + sparkleMain.startSizeMultiplier, Logger.LogLevel.Debug);

            sparkleEM.rateOverDistanceMultiplier = sparkleEM.rateOverDistanceMultiplier * Plugin.ClashParticleMultiplier;
            sparkleEM.rateOverTimeMultiplier = sparkleEM.rateOverTimeMultiplier * Plugin.ClashParticleMultiplier;
            sparkleMain.maxParticles = int.MaxValue;
            // default start lifetime multiplier is 0.3
            sparkleMain.startLifetimeMultiplier = Plugin.ClashParticleLifetimeMultiplier * 0.3f;
            // default start size multiplier is 0.008
            sparkleMain.startSizeMultiplier = Plugin.ClashParticleSizeMultiplier * 0.008f;
        }
    }
}
