using BS_Utils.Utilities;
using Zenject;

namespace ParticleOverdrive.Misc;

internal class ParticleConfig : IInitializable
{
    private readonly Config config;

    private const string configName = "ParticleOverdrive";
    private const string sectionParticles = "Particles";

    private ParticleConfig()
    {
        config = new Config(configName);
    }

    public bool DustParticles { get; set; }
    public bool CameraGrain { get; set; }

    public float SlashParticleMultiplier { get; set; }
    public float SlashParticleLifetimeMultiplier { get; set; }
    public float SlashParticleSizeMultiplier { get; set; }
    public float ExplosionParticleMultiplier { get; set; }
    public float ExplosionParticleLifetimeMultiplier { get; set; }
    public float ExplosionParticleSizeMultiplier { get; set; }
    public bool RainbowParticles { get; set; }
    public bool NoteCoreParticles { get; set; }

    public float ClashParticleMultiplier { get; set; }
    public float ClashParticleLifetimeMultiplier { get; set; }
    public float ClashParticleSizeMultiplier { get; set; }
    public bool ClashGlow { get; set; }

    public float ObstacleParticleMultiplier { get; set; }
    public float ObstacleParticleLifetimeMultiplier { get; set; }
    public float ObstacleParticleSizeMultiplier { get; set; }

    public void Initialize()
    {
        LoadConfig();
    }

    public void SaveConfig()
    {
        config.SetBool(sectionParticles, nameof(DustParticles), DustParticles);
        config.SetBool(sectionParticles, nameof(CameraGrain), CameraGrain);
        config.SetFloat(sectionParticles, nameof(SlashParticleMultiplier), SlashParticleMultiplier);
        config.SetFloat(sectionParticles, nameof(SlashParticleLifetimeMultiplier), SlashParticleLifetimeMultiplier);
        config.SetFloat(sectionParticles, nameof(SlashParticleSizeMultiplier), SlashParticleSizeMultiplier);
        config.SetFloat(sectionParticles, nameof(ExplosionParticleMultiplier), ExplosionParticleMultiplier);
        config.SetFloat(sectionParticles, nameof(ExplosionParticleLifetimeMultiplier), ExplosionParticleLifetimeMultiplier);
        config.SetFloat(sectionParticles, nameof(ExplosionParticleSizeMultiplier), ExplosionParticleSizeMultiplier);
        config.SetBool(sectionParticles, nameof(RainbowParticles), RainbowParticles);
        config.SetBool(sectionParticles, nameof(NoteCoreParticles), NoteCoreParticles);
        config.SetFloat(sectionParticles, nameof(ClashParticleMultiplier), ClashParticleMultiplier);
        config.SetFloat(sectionParticles, nameof(ClashParticleLifetimeMultiplier), ClashParticleLifetimeMultiplier);
        config.SetFloat(sectionParticles, nameof(ClashParticleSizeMultiplier), ClashParticleSizeMultiplier);
        config.SetBool(sectionParticles, nameof(ClashGlow), ClashGlow);
        config.SetFloat(sectionParticles, nameof(ObstacleParticleMultiplier), ObstacleParticleMultiplier);
        config.SetFloat(sectionParticles, nameof(ObstacleParticleLifetimeMultiplier), ObstacleParticleLifetimeMultiplier);
        config.SetFloat(sectionParticles, nameof(ObstacleParticleSizeMultiplier), ObstacleParticleSizeMultiplier);
    }

    public void LoadConfig()
    {
        DustParticles = config.GetBool(sectionParticles, nameof(DustParticles), true, true);
        CameraGrain = config.GetBool(sectionParticles, nameof(CameraGrain), true, true);
        SlashParticleMultiplier = config.GetFloat(sectionParticles, nameof(SlashParticleMultiplier), 1.0f, true);
        SlashParticleLifetimeMultiplier = config.GetFloat(sectionParticles, nameof(SlashParticleLifetimeMultiplier), 1.0f, true);
        SlashParticleSizeMultiplier = config.GetFloat(sectionParticles, nameof(SlashParticleSizeMultiplier), 1.0f, true);
        ExplosionParticleMultiplier = config.GetFloat(sectionParticles, nameof(ExplosionParticleMultiplier), 1.0f, true);
        ExplosionParticleLifetimeMultiplier = config.GetFloat(sectionParticles, nameof(ExplosionParticleLifetimeMultiplier), 1.0f, true);
        ExplosionParticleSizeMultiplier = config.GetFloat(sectionParticles, nameof(ExplosionParticleSizeMultiplier), 1.0f, true);
        RainbowParticles = config.GetBool(sectionParticles, nameof(RainbowParticles), false, true);
        NoteCoreParticles = config.GetBool(sectionParticles, nameof(NoteCoreParticles), true, true);
        ClashParticleMultiplier = config.GetFloat(sectionParticles, nameof(ClashParticleMultiplier), 1.0f, true);
        ClashParticleLifetimeMultiplier = config.GetFloat(sectionParticles, nameof(ClashParticleLifetimeMultiplier), 1.0f, true);
        ClashParticleSizeMultiplier = config.GetFloat(sectionParticles, nameof(ClashParticleSizeMultiplier), 1.0f, true);
        ClashGlow = config.GetBool(sectionParticles, nameof(ClashGlow), true, true);
        ObstacleParticleMultiplier = config.GetFloat(sectionParticles, nameof(ObstacleParticleMultiplier), 1.0f, true);
        ObstacleParticleLifetimeMultiplier = config.GetFloat(sectionParticles, nameof(ObstacleParticleLifetimeMultiplier), 1.0f, true);
        ObstacleParticleSizeMultiplier = config.GetFloat(sectionParticles, nameof(ObstacleParticleSizeMultiplier), 1.0f, true);
    }
}