using BeatSaberMarkupLanguage.Settings;
using HarmonyLib;
using IPA;
using ParticleOverdrive.Controllers;
using ParticleOverdrive.Misc;
using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Logger = ParticleOverdrive.Misc.Logger;

namespace ParticleOverdrive
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public string Name => "Particle Overdive";
        public string Version => "1.4.0";
        IPA.Logging.Logger log;

        private static readonly string[] env = { "Init", "MenuViewControllers", "GameCore", "Credits" };

        public static GameObject _controller;
        public static WorldParticleController _particleController;
        public static CameraNoiseController _noiseController;

        #region Private Field Getters

        internal static RefGetter<NoteCutParticlesEffect, ParticleSystem> GetExplosionPS;
        internal static RefGetter<NoteCutParticlesEffect, ParticleSystem[]> GetSparklesPS;
        internal static RefGetter<BlueNoiseDitheringUpdater, BlueNoiseDithering> GetBlueNoiseDithering;
        internal static RefGetter<BlueNoiseDithering, Texture2D> GetNoiseTexture;
        #endregion

        internal static bool CameraNoiseWorldParticlesEnabled;
        internal static bool SlashExplosionParticlesEnabled;

        public static readonly string ModPrefsKey = "ParticleOverdrive";

        public static float SlashParticleMultiplier;
        public static float ExplosionParticleMultiplier;
        public static float SlashParticleLifetimeMultiplier;
        public static float ExplosionParticleLifetimeMultiplier;
        public static bool RainbowParticles;

        [Init]
        public void Init(IPA.Logging.Logger logger)
        {
            Config.Init();
            log = logger;
            Logger.logger = logger;
        }

        public void LoadConfig()
        {
            SlashParticleMultiplier = Config.SlashParticleMultiplier;
            ExplosionParticleMultiplier = Config.ExplosionParticleMultiplier;
            SlashParticleLifetimeMultiplier = Config.SlashParticleLifetimeMultiplier;
            ExplosionParticleLifetimeMultiplier = Config.ExplosionParticleLifetimeMultiplier;
            RainbowParticles = Config.RainbowParticles;
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
                log.Error($"Error creating private field accessors for camera noise and/or world particles, , these features will be disabled: {ex.Message}");
                log.Debug(ex);
                CameraNoiseWorldParticlesEnabled = false;
            }
            try
            {
                GetExplosionPS = Utilities.CreateRefGetter<NoteCutParticlesEffect, ParticleSystem>("_explosionPS");
                GetSparklesPS = Utilities.CreateRefGetter<NoteCutParticlesEffect, ParticleSystem[]>("_sparklesPS");
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
                        log.Error($"Error applying Harmony patches. {argEx.Message}.");//: {argEx.ParamName}");
                    }
                    else
                        log.Error($"Error applying Harmony patches: {e.Message}");
                    log.Debug(e);
                }

            }
            catch(Exception ex)
            {
                log.Error($"Error creating private field accessors for Slash/Explosion particles, these features will be disabled: {ex.Message}");
                log.Debug(ex);
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
            if (scene.name == "MenuViewControllers" && prevScene.name == "EmptyTransition")
            {
                BSMLSettings.instance.AddSettingsMenu("Particle Overdrive", "ParticleOverdrive.UI.POUI.bsml", UI.POUI.instance);
            }
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
