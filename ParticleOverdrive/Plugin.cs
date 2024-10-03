using BeatSaberMarkupLanguage.Settings;
using HarmonyLib;
using IPA;
using ParticleOverdrive.Controllers;
using ParticleOverdrive.Misc;
using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using SiraUtil.Zenject;
using IPA.Loader;
using ParticleOverdrive.Installers;
using UnityEngine.SceneManagement;
using Logger = ParticleOverdrive.Misc.Logger;
using IPALogger = IPA.Logging.Logger;

namespace ParticleOverdrive
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public string Name { get; }
        public string Version { get; }        
        
        private static readonly string[] env = { "Init", "MainMenu", "GameCore", "Credits" };

        public static GameObject _controller;
        public static WorldParticleController _particleController;
        public static CameraNoiseController _noiseController;

        #region Private Field Getters
        internal static RefGetter<NoteCutParticlesEffect, ParticleSystem> GetExplosionPS;
        internal static RefGetter<NoteCutParticlesEffect, ParticleSystem> GetSparklesPS;
        internal static RefGetter<NoteCutParticlesEffect, ParticleSystem> GetCorePS;
        internal static RefGetter<BlueNoiseDitheringUpdater, BlueNoiseDithering> GetBlueNoiseDithering;
        internal static RefGetter<BlueNoiseDithering, Texture2D> GetNoiseTexture;
        internal static RefGetter<ObstacleSaberSparkleEffect, ParticleSystem> GetObstacleSaberSparklePS;
        internal static RefGetter<SaberClashEffect, ParticleSystem> GetSaberClashGlowPS;
        internal static RefGetter<SaberClashEffect, ParticleSystem> GetSaberClashSparklePS;
        #endregion

        internal static bool CameraNoiseWorldParticlesEnabled;
        internal static bool SlashExplosionParticlesEnabled;

        public static readonly string ModPrefsKey = "ParticleOverdrive";

        public static float SlashParticleMultiplier;
        public static float ExplosionParticleMultiplier;
        public static float ClashParticleMultiplier;
        public static float SlashParticleLifetimeMultiplier;
        public static float ExplosionParticleLifetimeMultiplier;
        public static float ClashParticleLifetimeMultiplier;
        public static float SlashParticleSizeMultiplier;
        public static float ExplosionParticleSizeMultiplier;
        public static float ClashParticleSizeMultiplier;
        //public static float SlashParticleSpeedMultiplier;
        public static float ObstacleParticleMultiplier;
        public static float ObstacleParticleLifetimeMultiplier;
        public static float ObstacleParticleSizeMultiplier;
        public static bool ClashGlow;
        public static bool RainbowParticles;
        public static bool NoteCoreParticles;

        [Init]
        public Plugin(Zenjector zenjector, PluginMetadata metadata, IPALogger logger)
        {
            Config.Init();

            Name = metadata.Name;
            Version = metadata.HVersion.ToString();
            Logger.logger = logger;

            zenjector.UseLogger(logger);
            zenjector.Install<MenuInstaller>(Location.Menu);
        }

        public void LoadConfig()
        {
            SlashParticleMultiplier = Config.SlashParticleMultiplier;
            ExplosionParticleMultiplier = Config.ExplosionParticleMultiplier;
            ClashParticleMultiplier = Config.ClashParticleMultiplier;
            SlashParticleLifetimeMultiplier = Config.SlashParticleLifetimeMultiplier;
            ExplosionParticleLifetimeMultiplier = Config.ExplosionParticleLifetimeMultiplier;
            ClashParticleLifetimeMultiplier = Config.ClashParticleLifetimeMultiplier;
            SlashParticleSizeMultiplier = Config.SlashParticleSizeMultiplier;
            ExplosionParticleSizeMultiplier = Config.ExplosionParticleSizeMultiplier;
            ClashParticleSizeMultiplier = Config.ClashParticleSizeMultiplier;
            //SlashParticleSpeedMultiplier = Config.SlashParticleSpeedMultiplier;
            ObstacleParticleMultiplier = Config.ObstacleParticleMultiplier;
            ObstacleParticleLifetimeMultiplier = Config.ObstacleParticleLifetimeMultiplier;
            ObstacleParticleSizeMultiplier = Config.ObstacleParticleSizeMultiplier;
            ClashGlow = Config.ClashGlow;
            RainbowParticles = Config.RainbowParticles;
            NoteCoreParticles = Config.NoteCoreParticles;
        }

        [OnStart]
        public void OnStart()
        {
            LoadConfig();
            try
            {
                GetBlueNoiseDithering = Utilities.CreateRefGetter<BlueNoiseDitheringUpdater, BlueNoiseDithering>("_blueNoiseDithering");
                GetNoiseTexture = Utilities.CreateRefGetter<BlueNoiseDithering, Texture2D>("_noiseTexture");
                CameraNoiseWorldParticlesEnabled = true;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error creating private field accessors for camera noise and/or world particles, , these features will be disabled: {ex.Message}", Logger.LogLevel.Error);
                Logger.Log(ex.ToString(), Logger.LogLevel.Debug);
                CameraNoiseWorldParticlesEnabled = false;
            }
            try
            {
                GetExplosionPS = Utilities.CreateRefGetter<NoteCutParticlesEffect, ParticleSystem>("_explosionPS");
                GetSparklesPS = Utilities.CreateRefGetter<NoteCutParticlesEffect, ParticleSystem>("_sparklesPS");
                GetCorePS = Utilities.CreateRefGetter<NoteCutParticlesEffect, ParticleSystem>("_explosionCorePS");
                GetObstacleSaberSparklePS = Utilities.CreateRefGetter<ObstacleSaberSparkleEffect, ParticleSystem>("_sparkleParticleSystem");
                GetSaberClashGlowPS = Utilities.CreateRefGetter<SaberClashEffect, ParticleSystem>("_glowParticleSystem");
                GetSaberClashSparklePS = Utilities.CreateRefGetter<SaberClashEffect, ParticleSystem>("_sparkleParticleSystem");
                SlashExplosionParticlesEnabled = true;
                try
                {
                    Harmony harmony = new Harmony("com.jackbaron.beatsaber.particleoverdrive");
                    harmony.PatchAll(Assembly.GetExecutingAssembly());
                }
                catch (Exception e)
                {
                    SlashExplosionParticlesEnabled = false;
                    if (e.InnerException is ArgumentException argEx)
                    {
                        Logger.Log($"Error applying Harmony patches. {argEx.Message}.", Logger.LogLevel.Error);//: {argEx.ParamName}");
                    }
                    else
                        Logger.Log($"Error applying Harmony patches: {e.Message}", Logger.LogLevel.Error);
                    Logger.Log(e.ToString(), Logger.LogLevel.Debug);
                }

            }
            catch(Exception ex)
            {
                Logger.Log($"Error creating private field accessors for Slash/Explosion particles, these features will be disabled: {ex.Message}", Logger.LogLevel.Error);
                Logger.Log(ex.ToString(), Logger.LogLevel.Debug);
                SlashExplosionParticlesEnabled = false;
            }

            AddEvents();
        }

        [OnExit]
        public void OnExit()
        {
            RemoveEvents();
        }

        public void OnActiveSceneChanged(Scene prevScene, Scene scene)
        {
            LoadConfig();
            if (!CameraNoiseWorldParticlesEnabled)
                return;
            if (_controller == null)
            {
                _controller = new GameObject("WorldEffectController");
                GameObject.DontDestroyOnLoad(_controller);

                _particleController = _controller.AddComponent<WorldParticleController>();
                _noiseController = _controller.AddComponent<CameraNoiseController>();

                bool particleState = Config.DustParticles;
                _particleController.Init(particleState);

                bool noiseState = Config.CameraGrain;
                _noiseController.Init(noiseState);
            }

            if (env.Contains(scene.name))
            {
                _particleController.OnSceneChange(scene);
                _noiseController.OnSceneChange(scene);
            }
        }

        private void AddEvents()
        {
            RemoveEvents();
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }

        private void RemoveEvents()
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
        }

    }
}
