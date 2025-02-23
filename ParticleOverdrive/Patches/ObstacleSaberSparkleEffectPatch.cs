using ParticleOverdrive.Misc;
using SiraUtil.Affinity;
using UnityEngine;

namespace ParticleOverdrive.Patches;

internal class ObstacleSaberSparkleEffectPatch : IAffinity
{
    private readonly ParticleConfig config;

    private ObstacleSaberSparkleEffectPatch(ParticleConfig config)
    {
        this.config = config;
    }

    [AffinityPatch(typeof(ObstacleSaberSparkleEffect), nameof(ObstacleSaberSparkleEffect.Awake))]
    public void Postfix(ObstacleSaberSparkleEffect __instance)
    {
        var sparkleParticles = __instance._sparkleParticleSystem;
        var sparkleEmission = sparkleParticles.emission;
        var sparkleMainModule = sparkleParticles.main;

        sparkleEmission.rateOverDistanceMultiplier *= config.ObstacleParticleMultiplier;
        sparkleEmission.rateOverTimeMultiplier *= config.ObstacleParticleMultiplier;
        sparkleMainModule.maxParticles = int.MaxValue;
        sparkleMainModule.startLifetimeMultiplier *= config.ObstacleParticleLifetimeMultiplier;
        sparkleMainModule.startSizeMultiplier *= config.ObstacleParticleSizeMultiplier;
    }
}