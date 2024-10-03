using ParticleOverdrive.Misc;
using SiraUtil.Affinity;
using UnityEngine;

namespace ParticleOverdrive.Patches
{
    class ObstacleSaberSparkleEffectPatch : IAffinity
    {
        private readonly ParticleConfig _config;

        private ObstacleSaberSparkleEffectPatch(ParticleConfig config)
        {
            _config = config;
        }

        [AffinityPatch(typeof(ObstacleSaberSparkleEffect), "Awake")]
        public void Postfix(ObstacleSaberSparkleEffect __instance)
        {
            ParticleSystem sparklePS = __instance._sparkleParticleSystem;

            ParticleSystem.EmissionModule sparkleEM = sparklePS.emission;
            ParticleSystem.MainModule sparkleMM = sparklePS.main;

            sparkleEM.rateOverDistanceMultiplier *= _config.ObstacleParticleMultiplier;
            sparkleEM.rateOverTimeMultiplier *= _config.ObstacleParticleMultiplier;
            sparkleMM.maxParticles = int.MaxValue;
            sparkleMM.startLifetimeMultiplier *= _config.ObstacleParticleLifetimeMultiplier;
            sparkleMM.startSizeMultiplier *= _config.ObstacleParticleSizeMultiplier;
        }
    }
}
