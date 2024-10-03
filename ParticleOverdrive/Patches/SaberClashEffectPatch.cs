using ParticleOverdrive.Misc;
using SiraUtil.Affinity;
using UnityEngine;


namespace ParticleOverdrive.Patches
{
    public class SaberClashEffectPatch : IAffinity
    {
        private readonly ParticleConfig _config;

        private SaberClashEffectPatch(ParticleConfig config)
        {
            _config = config;
        }

        [AffinityPatch(typeof(SaberClashEffect), nameof(SaberClashEffect.Start))]
        public void Postfix(ref SaberClashEffect __instance)
        {
            ParticleSystem.EmissionModule glowEM = __instance._glowParticleSystem.emission;
            ParticleSystem.EmissionModule sparkleEM = __instance._sparkleParticleSystem.emission;

            ParticleSystem.MainModule glowMain = __instance._glowParticleSystem.main;
            ParticleSystem.MainModule sparkleMain = __instance._sparkleParticleSystem.main;

            if (!_config.ClashGlow)
            {
                glowMain.startLifetimeMultiplier = 0;
            }

            sparkleEM.rateOverDistanceMultiplier *= _config.ClashParticleMultiplier;
            sparkleEM.rateOverTimeMultiplier *= _config.ClashParticleMultiplier;

            glowEM.rateOverDistanceMultiplier *= _config.ClashParticleMultiplier;
            glowEM.rateOverTimeMultiplier *= _config.ClashParticleMultiplier;

            sparkleMain.maxParticles = int.MaxValue;
            sparkleMain.startLifetimeMultiplier *= _config.ClashParticleLifetimeMultiplier;
            sparkleMain.startSizeMultiplier *= _config.ClashParticleSizeMultiplier;
        }
    }
}
