using BeatSaberMarkupLanguage.Attributes;
using ParticleOverdrive.Misc;
using System.Collections.Generic;

namespace ParticleOverdrive.UI;

public class SettingsMenu
{
    private readonly ParticleConfig config;

    private SettingsMenu(ParticleConfig config)
    {
        this.config = config;
    }

    [UIValue("slashParticleChoices")]
    private List<object> slashParticleMultiplierChoices = ParticleMultiplierChoicesList;

    [UIValue("explosionParticleChoices")]
    private List<object> explosionParticleMultiplierChoices = ParticleMultiplierChoicesList;

    [UIValue("clashParticleChoices")]
    private List<object> clashParticleMultiplierChoices = ParticleMultiplierChoicesList;

    [UIValue("obstacleParticleChoices")]
    private List<object> obstacleParticleMultiplierChoices = ParticleMultiplierChoicesList;

    [UIValue("lifetime-values")] 
    private List<object> lifetimeValues = LifetimeValues;
    
    [UIValue("lifetimeChoices")]
    private List<object> lifetimeChoices = LifetimeValues;

    [UIValue("cameraNoiseEnable")]
    public bool CameraGrain
    {
        get => config.CameraGrain;
        set => config.CameraGrain = value;
    }

    [UIValue("dustParticleEnable")]
    public bool DustParticles
    {
        get => config.DustParticles;
        set => config.DustParticles = value;
    }

    [UIValue("slashParticleChoice")]
    public float SlashParticleMultiplier
    {
        get => config.SlashParticleMultiplier;
        set => config.SlashParticleMultiplier = value;
    }

    [UIValue("slashParticleLifetimeChoice")]
    public float SlashParticleLifetimeMultiplier
    {
        get => config.SlashParticleLifetimeMultiplier;
        set => config.SlashParticleLifetimeMultiplier = value;
    }

    [UIValue("slashParticleSizeChoice")]
    public float SlashParticleSizeMultiplier
    {
        get => config.SlashParticleSizeMultiplier;
        set => config.SlashParticleSizeMultiplier = value;
    }

    [UIValue("explosionParticleChoice")]
    public float ExplosionParticleMultiplier
    {
        get => config.ExplosionParticleMultiplier;
        set => config.ExplosionParticleMultiplier = value;
    }

    [UIValue("explosionParticleLifetimeChoice")]
    public float ExplosionParticleLifetimeMultiplier
    {
        get => config.ExplosionParticleLifetimeMultiplier;
        set => config.ExplosionParticleLifetimeMultiplier = value;
    }

    [UIValue("explosionParticleSizeChoice")]
    public float ExplosionParticleSizeMultiplier
    {
        get => config.ExplosionParticleSizeMultiplier;
        set => config.ExplosionParticleSizeMultiplier = value;
    }

    [UIValue("explosionParticleSpeedChoice")]
    public float ExplosionParticleSpeedMultiplier
    {
        get => config.ExplosionParticleSpeedMultiplier;
        set => config.ExplosionParticleSpeedMultiplier = value;
    }

    [UIValue("rainbowParticlesEnable")]
    public bool RainbowParticles
    {
        get => config.RainbowParticles;
        set => config.RainbowParticles = value;
    }

    [UIValue("noteCoreParticlesEnable")]
    public bool NoteCoreParticles
    {
        get => config.NoteCoreParticles;
        set => config.NoteCoreParticles = value;
    }

    [UIValue("clashParticleChoice")]
    public float ClashParticleMultiplier
    {
        get => config.ClashParticleMultiplier;
        set => config.ClashParticleMultiplier = value;
    }


    [UIValue("clashParticleLifetimeChoice")]
    public float ClashParticleLifetimeMultiplier
    {
        get => config.ClashParticleLifetimeMultiplier;
        set => config.ClashParticleLifetimeMultiplier = value;
    }

    [UIValue("clashParticleSizeChoice")]
    public float ClashParticleSizeMultiplier
    {
        get => config.ClashParticleSizeMultiplier;
        set => config.ClashParticleSizeMultiplier = value;
    }

    [UIValue("clashGlowEnable")]
    public bool ClashGlow
    {
        get => config.ClashGlow;
        set => config.ClashGlow = value;
    }

    [UIValue("obstacleParticleChoice")]
    public float ObstacleParticleMultiplier
    {
        get => config.ObstacleParticleMultiplier;
        set => config.ObstacleParticleMultiplier = value;
    }
         

    [UIValue("obstacleParticleLifetimeChoice")]
    public float ObstacleParticleLifetimeMultiplier
    {
        get => config.ObstacleParticleLifetimeMultiplier;
        set => config.ObstacleParticleLifetimeMultiplier = value;
    }

    [UIValue("obstacleParticleSizeChoice")]
    public float ObstacleParticleSizeMultiplier
    {
        get => config.ObstacleParticleSizeMultiplier;
        set => config.ObstacleParticleSizeMultiplier = value;
    }

    [UIAction("multiplierFormatter")]
    public string MultiplierDisplay(float multiplier) => $"{multiplier * 100f}%";
    
    private static readonly List<object> ParticleMultiplierChoicesList =
    [
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
    ];
        
    private static readonly List<object> LifetimeValues =
    [
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
    ];
}