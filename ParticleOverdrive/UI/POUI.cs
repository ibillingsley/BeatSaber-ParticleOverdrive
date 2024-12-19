using BeatSaberMarkupLanguage.Attributes;
using ParticleOverdrive.Misc;
using System.Collections.Generic;

namespace ParticleOverdrive.UI;

public class POUI
{
    private readonly ParticleConfig _config;

    private POUI(ParticleConfig config)
    {
        _config = config;
    }

    public static readonly List<object> particleMultiplierChoicesList = new List<object>()
    {
        0f,
        1f,
        1.1f,
        1.2f,
        1.3f,
        1.4f,
        1.5f,
        1.6f,
        1.7f,
        1.8f,
        1.9f,
        2f,
        2.25f,
        2.5f,
        2.75f,
        3f,
        3.25f,
        3.5f,
        3.75f,
        4f,
        4.25f,
        4.5f,
        4.75f,
        5f,
        5.5f,
        6f,
        6.5f,
        7f,
        7.5f,
        8f,
        8.5f,
        9f,
        9.5f,
        10f,
        11f,
        12f,
        13f,
        14f,
        15f,
        16f,
        17f,
        18f,
        19f,
        20f,
        22.5f,
        25f,
        27.5f,
        30f,
        32.5f,
        35f,
        37.5f,
        40f,
        42.5f,
        45f,
        47.5f,
        50f,
        55f,
        60f,
        65f,
        70f,
        75f,
        80f,
        85f,
        90f,
        100f,
        110f,
        120f,
        130f,
        140f,
        150f,
        160f,
        170f,
        180f,
        190f,
        200f
    };
    [UIValue("lifetime-values")]
    internal static List<object> LifetimeValues = new List<object>
    {
        0f,
        0.1f,
        0.2f,
        0.3f,
        0.4f,
        0.5f,
        0.6f,
        0.7f,
        0.8f,
        0.9f,
        1f,
        1.1f,
        1.2f,
        1.3f,
        1.4f,
        1.5f,
        1.6f,
        1.7f,
        1.8f,
        1.9f,
        2f,
        2.25f,
        2.5f,
        2.75f,
        3f,
        3.25f,
        3.5f,
        3.75f,
        4f,
        4.25f,
        4.5f,
        4.75f,
        5f,
        7.5f,
        10f,
        15f,
        20f,
        30f,
        40f,
        50f,
        75f,
        100f
    };

    [UIValue("slashParticleChoices")]
    private List<object> _slashParticleMultiplierChoices = particleMultiplierChoicesList;

    [UIValue("explosionParticleChoices")]
    private List<object> _explosionParticleMultiplierChoices = particleMultiplierChoicesList;

    [UIValue("clashParticleChoices")]
    private List<object> _clashParticleMultiplierChoices = particleMultiplierChoicesList;

    [UIValue("obstacleParticleChoices")]
    private List<object> _obstacleParticleMultiplierChoices = particleMultiplierChoicesList;

    [UIValue("lifetimeChoices")]
    private List<object> _lifetimeChoices = LifetimeValues;

    [UIValue("cameraNoiseEnable")]
    public bool _cameraNoiseEnable
    {
        get => _config.CameraGrain;
        set => _config.CameraGrain = value;
    }

    [UIValue("dustParticleEnable")]
    public bool _dustParticleEnable
    {
        get => _config.DustParticles;
        set => _config.DustParticles = value;
    }

    [UIValue("slashParticleChoice")]
    public float _slashParticleMultiplier
    {
        get => _config.SlashParticleMultiplier;
        set => _config.SlashParticleMultiplier = value;
    }

    [UIValue("slashParticleLifetimeChoice")]
    public float _slashParticleLifetimeMultiplier
    {
        get => _config.SlashParticleLifetimeMultiplier;
        set => _config.SlashParticleLifetimeMultiplier = value;
    }

    [UIValue("slashParticleSizeChoice")]
    public float _slashParticleSizeMultiplier
    {
        get => _config.SlashParticleSizeMultiplier;
        set => _config.SlashParticleSizeMultiplier = value;
    }

    [UIValue("explosionParticleChoice")]
    public float _explosionParticleMultiplier
    {
        get => _config.ExplosionParticleMultiplier;
        set => _config.ExplosionParticleMultiplier = value;
    }

    [UIValue("explosionParticleLifetimeChoice")]
    public float _explosionParticleLifetimeMultiplier
    {
        get => _config.ExplosionParticleLifetimeMultiplier;
        set => _config.ExplosionParticleLifetimeMultiplier = value;
    }

    [UIValue("explosionParticleSizeChoice")]
    public float _explosionParticleSizeMultiplier
    {
        get => _config.ExplosionParticleSizeMultiplier;
        set => _config.ExplosionParticleSizeMultiplier = value;
    }

    [UIValue("rainbowParticlesEnable")]
    public bool _rainbowParticlesEnable
    {
        get => _config.RainbowParticles;
        set => _config.RainbowParticles = value;
    }

    [UIValue("noteCoreParticlesEnable")]
    public bool _noteCoreParticlesEnable
    {
        get => _config.NoteCoreParticles;
        set => _config.NoteCoreParticles = value;
    }

    [UIValue("clashParticleChoice")]
    public float _clashParticleMultiplier
    {
        get => _config.ClashParticleMultiplier;
        set => _config.ClashParticleMultiplier = value;
    }


    [UIValue("clashParticleLifetimeChoice")]
    public float _clashParticleLifetimeMultiplier
    {
        get => _config.ClashParticleLifetimeMultiplier;
        set => _config.ClashParticleLifetimeMultiplier = value;
    }

    [UIValue("clashParticleSizeChoice")]
    public float _clashParticleSizeMultiplier
    {
        get => _config.ClashParticleSizeMultiplier;
        set => _config.ClashParticleSizeMultiplier = value;
    }

    [UIValue("clashGlowEnable")]
    public bool _clashGlowEnable
    {
        get => _config.ClashGlow;
        set => _config.ClashGlow = value;
    }

    [UIValue("obstacleParticleChoice")]
    public float _obstacleParticleMultiplier
    {
        get => _config.ObstacleParticleMultiplier;
        set => _config.ObstacleParticleMultiplier = value;
    }
         

    [UIValue("obstacleParticleLifetimeChoice")]
    public float _obstacleParticleLifetimeMultiplier
    {
        get => _config.ObstacleParticleLifetimeMultiplier;
        set => _config.ObstacleParticleLifetimeMultiplier = value;
    }

    [UIValue("obstacleParticleSizeChoice")]
    public float _obstacleParticleSizeMultiplier
    {
        get => _config.ObstacleParticleSizeMultiplier;
        set => _config.ObstacleParticleSizeMultiplier = value;
    }

    [UIAction("multiplierFormatter")]
    public string MultiplierDisplay(float multiplier) => $"{multiplier * 100f}%";
}