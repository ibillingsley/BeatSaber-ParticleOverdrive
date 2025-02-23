using ParticleOverdrive.Misc;
using SiraUtil.Affinity;
using UnityEngine;


namespace ParticleOverdrive.Patches;

public class SaberClashEffectPatch : IAffinity
{
    private readonly ParticleConfig config;

    private SaberClashEffectPatch(ParticleConfig config)
    {
        this.config = config;
    }

    [AffinityPatch(typeof(SaberClashEffect), nameof(SaberClashEffect.Start))]
    public void Postfix(ref SaberClashEffect __instance)
    {
        var glowEmissionModule = __instance._glowParticleSystem.emission;
        var sparkleEmissionModule = __instance._sparkleParticleSystem.emission;

        var glowMainModule = __instance._glowParticleSystem.main;
        var sparkleMainModule = __instance._sparkleParticleSystem.main;

        if (!config.ClashGlow)
        {
            glowMainModule.startLifetimeMultiplier = 0;
        }

        sparkleEmissionModule.rateOverDistanceMultiplier *= config.ClashParticleMultiplier;
        sparkleEmissionModule.rateOverTimeMultiplier *= config.ClashParticleMultiplier;

        glowEmissionModule.rateOverDistanceMultiplier *= config.ClashParticleMultiplier;
        glowEmissionModule.rateOverTimeMultiplier *= config.ClashParticleMultiplier;

        sparkleMainModule.maxParticles = int.MaxValue;
        sparkleMainModule.startLifetimeMultiplier *= config.ClashParticleLifetimeMultiplier;
        sparkleMainModule.startSizeMultiplier *= config.ClashParticleSizeMultiplier;
    }
}