using BS_Utils.Utilities;
using Zenject;

namespace ParticleOverdrive.Misc;

internal class ParticleConfig : IInitializable
{
    private readonly Config config;

    private const string ConfigName = "ParticleOverdrive";
    private const string SectionParticles = "Particles";

    private ParticleConfig()
    {
        config = new(ConfigName);
    }

    public bool DustParticles { get; set; }
    public bool CameraGrain { get; set; }

    public float SlashParticleMultiplier { get; set; }
    public float SlashParticleLifetimeMultiplier { get; set; }
    public float SlashParticleSizeMultiplier { get; set; }
    public float ExplosionParticleMultiplier { get; set; }
    public float ExplosionParticleLifetimeMultiplier { get; set; }
    public float ExplosionParticleSizeMultiplier { get; set; }
    public float ExplosionParticleSpeedMultiplier { get; set; }
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
        config.SetBool(SectionParticles, nameof(DustParticles), DustParticles);
        config.SetBool(SectionParticles, nameof(CameraGrain), CameraGrain);
        config.SetFloat(SectionParticles, nameof(SlashParticleMultiplier), SlashParticleMultiplier);
        config.SetFloat(SectionParticles, nameof(SlashParticleLifetimeMultiplier), SlashParticleLifetimeMultiplier);
        config.SetFloat(SectionParticles, nameof(SlashParticleSizeMultiplier), SlashParticleSizeMultiplier);
        config.SetFloat(SectionParticles, nameof(ExplosionParticleMultiplier), ExplosionParticleMultiplier);
        config.SetFloat(SectionParticles, nameof(ExplosionParticleLifetimeMultiplier), ExplosionParticleLifetimeMultiplier);
        config.SetFloat(SectionParticles, nameof(ExplosionParticleSizeMultiplier), ExplosionParticleSizeMultiplier);
        config.SetFloat(SectionParticles, nameof(ExplosionParticleSpeedMultiplier), ExplosionParticleSpeedMultiplier);
        config.SetBool(SectionParticles, nameof(RainbowParticles), RainbowParticles);
        config.SetBool(SectionParticles, nameof(NoteCoreParticles), NoteCoreParticles);
        config.SetFloat(SectionParticles, nameof(ClashParticleMultiplier), ClashParticleMultiplier);
        config.SetFloat(SectionParticles, nameof(ClashParticleLifetimeMultiplier), ClashParticleLifetimeMultiplier);
        config.SetFloat(SectionParticles, nameof(ClashParticleSizeMultiplier), ClashParticleSizeMultiplier);
        config.SetBool(SectionParticles, nameof(ClashGlow), ClashGlow);
        config.SetFloat(SectionParticles, nameof(ObstacleParticleMultiplier), ObstacleParticleMultiplier);
        config.SetFloat(SectionParticles, nameof(ObstacleParticleLifetimeMultiplier), ObstacleParticleLifetimeMultiplier);
        config.SetFloat(SectionParticles, nameof(ObstacleParticleSizeMultiplier), ObstacleParticleSizeMultiplier);
    }

    public void LoadConfig()
    {
        DustParticles = config.GetBool(SectionParticles, nameof(DustParticles), true, true);
        CameraGrain = config.GetBool(SectionParticles, nameof(CameraGrain), true, true);
        SlashParticleMultiplier = config.GetFloat(SectionParticles, nameof(SlashParticleMultiplier), 1.0f, true);
        SlashParticleLifetimeMultiplier = config.GetFloat(SectionParticles, nameof(SlashParticleLifetimeMultiplier), 1.0f, true);
        SlashParticleSizeMultiplier = config.GetFloat(SectionParticles, nameof(SlashParticleSizeMultiplier), 1.0f, true);
        ExplosionParticleMultiplier = config.GetFloat(SectionParticles, nameof(ExplosionParticleMultiplier), 1.0f, true);
        ExplosionParticleLifetimeMultiplier = config.GetFloat(SectionParticles, nameof(ExplosionParticleLifetimeMultiplier), 1.0f, true);
        ExplosionParticleSizeMultiplier = config.GetFloat(SectionParticles, nameof(ExplosionParticleSizeMultiplier), 1.0f, true);
        ExplosionParticleSpeedMultiplier = config.GetFloat(SectionParticles, nameof(ExplosionParticleSpeedMultiplier), 1.0f, true);
        RainbowParticles = config.GetBool(SectionParticles, nameof(RainbowParticles), false, true);
        NoteCoreParticles = config.GetBool(SectionParticles, nameof(NoteCoreParticles), true, true);
        ClashParticleMultiplier = config.GetFloat(SectionParticles, nameof(ClashParticleMultiplier), 1.0f, true);
        ClashParticleLifetimeMultiplier = config.GetFloat(SectionParticles, nameof(ClashParticleLifetimeMultiplier), 1.0f, true);
        ClashParticleSizeMultiplier = config.GetFloat(SectionParticles, nameof(ClashParticleSizeMultiplier), 1.0f, true);
        ClashGlow = config.GetBool(SectionParticles, nameof(ClashGlow), true, true);
        ObstacleParticleMultiplier = config.GetFloat(SectionParticles, nameof(ObstacleParticleMultiplier), 1.0f, true);
        ObstacleParticleLifetimeMultiplier = config.GetFloat(SectionParticles, nameof(ObstacleParticleLifetimeMultiplier), 1.0f, true);
        ObstacleParticleSizeMultiplier = config.GetFloat(SectionParticles, nameof(ObstacleParticleSizeMultiplier), 1.0f, true);
    }
}