using ParticleOverdrive.Misc;
using SiraUtil.Affinity;
using UnityEngine;

namespace ParticleOverdrive.Patches;

internal class NoteCutParticlesEffectPatch : IAffinity
{
    private readonly ParticleConfig config;

    private NoteCutParticlesEffectPatch(ParticleConfig config)
    {
        this.config = config;
    }

    [AffinityPatch(typeof(NoteCutCoreEffectsSpawner), nameof(NoteCutCoreEffectsSpawner.Start))]
    public void Initialize(NoteCutCoreEffectsSpawner __instance)
    {
        var slashMainModule = __instance._noteCutParticlesEffect._sparklesPSMainModule;
        // default start size multiplier is 0.015
        //_log.Debug("slash startSizeMultiplier is: " + slashMain.startSizeMultiplier);
        slashMainModule.maxParticles = int.MaxValue;
        slashMainModule.startSizeMultiplier = config.SlashParticleSizeMultiplier * 0.015f;

        var explosionMainModule = __instance._noteCutParticlesEffect._explosionPS.main;
        // default start lifetime multiplier is 0.6
        //_log.Debug("explosion startLifetimeMultiplier is: " + explosionMain.startLifetimeMultiplier);
        // default start size multiplier is 0.015
        //_log.Debug("explosion startSizeMultiplier is: " + explosionMain.startSizeMultiplier);
        explosionMainModule.maxParticles = int.MaxValue;
        explosionMainModule.startLifetimeMultiplier = config.ExplosionParticleLifetimeMultiplier * 0.6f;
        explosionMainModule.startSizeMultiplier = config.ExplosionParticleSizeMultiplier * 0.015f;
            
        var coreMainModule = __instance._noteCutParticlesEffect._explosionCorePSMainModule;
        if (!config.NoteCoreParticles)
        {
            coreMainModule.startLifetimeMultiplier = 0f;
        }
    }

    [AffinityPrefix]
    [AffinityPatch(typeof(NoteCutParticlesEffect), nameof(NoteCutParticlesEffect.SpawnParticles))]
    public void SpawnParticlesPrefix(ref Color32 color, ref int sparkleParticlesCount, ref int explosionParticlesCount, ref float lifetimeMultiplier)
    {
        sparkleParticlesCount = Mathf.FloorToInt(sparkleParticlesCount * config.SlashParticleMultiplier);
        explosionParticlesCount = Mathf.FloorToInt(explosionParticlesCount * config.ExplosionParticleMultiplier);
        lifetimeMultiplier *= config.SlashParticleLifetimeMultiplier;

        if (config.RainbowParticles)
        {
            color = Color.HSVToRGB(Random.value, 1f, 1f) with { a = 0.5f };
        }
    }
}