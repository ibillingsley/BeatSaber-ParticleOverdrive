using ParticleOverdrive.Misc;
using SiraUtil.Affinity;
using SiraUtil.Logging;
using UnityEngine;

namespace ParticleOverdrive.Patches;

internal class NoteCutParticlesEffectPatch : IAffinity
{
    private readonly SiraLog _log;
    private readonly ParticleConfig _config;

    private NoteCutParticlesEffectPatch(SiraLog log, ParticleConfig config)
    {
        _log = log;
        _config = config;
    }

    private NoteCutCoreEffectsSpawner _effectsSpawner;

    [AffinityPatch(typeof(NoteCutCoreEffectsSpawner), nameof(NoteCutCoreEffectsSpawner.Start))]
    public void Initialize(NoteCutCoreEffectsSpawner __instance)
    {
        ParticleSystem.MainModule slashMain = __instance._noteCutParticlesEffect._sparklesPSMainModule;
        // default start size multiplier is 0.015
        //_log.Debug("slash startSizeMultiplier is: " + slashMain.startSizeMultiplier);
        slashMain.maxParticles = int.MaxValue;
        slashMain.startSizeMultiplier = _config.SlashParticleSizeMultiplier * 0.015f;

        ParticleSystem.MainModule explosionMain = __instance._noteCutParticlesEffect._explosionPS.main;
        // default start lifetime multiplier is 0.6
        //_log.Debug("explosion startLifetimeMultiplier is: " + explosionMain.startLifetimeMultiplier);
        // default start size multiplier is 0.015
        //_log.Debug("explosion startSizeMultiplier is: " + explosionMain.startSizeMultiplier);
        explosionMain.maxParticles = int.MaxValue;
        explosionMain.startLifetimeMultiplier = _config.ExplosionParticleLifetimeMultiplier * 0.6f;
        explosionMain.startSizeMultiplier = _config.ExplosionParticleSizeMultiplier * 0.015f;
            
        ParticleSystem.MainModule coreMain = __instance._noteCutParticlesEffect._explosionCorePSMainModule;
        if (!_config.NoteCoreParticles)
        {
            coreMain.startLifetimeMultiplier = 0f;
        }
    }

    [AffinityPrefix]
    [AffinityPatch(typeof(NoteCutParticlesEffect), nameof(NoteCutParticlesEffect.SpawnParticles))]
    public void SpawnParticlesPrefix(ref Color32 color, ref int sparkleParticlesCount, ref int explosionParticlesCount, ref float lifetimeMultiplier)
    {
        sparkleParticlesCount = Mathf.FloorToInt(sparkleParticlesCount * _config.SlashParticleMultiplier);
        explosionParticlesCount = Mathf.FloorToInt(explosionParticlesCount * _config.ExplosionParticleMultiplier);
        lifetimeMultiplier *= _config.SlashParticleLifetimeMultiplier;

        if (_config.RainbowParticles)
        {
            Color generatedColor = Color.HSVToRGB(Random.value, 1f, 1f);
            generatedColor.a = 0.5f;
            color = generatedColor;
        }
    }
}