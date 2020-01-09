using BeatSaberMarkupLanguage.Settings;
using Harmony;
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
    public class Plugin : IBeatSaberPlugin
    {
        public string Name => "Particle Overdive";
        public string Version => "1.0.0";

        private static readonly string[] env = { "Init", "MenuViewControllers", "GameCore", "Credits" };

        public static GameObject _controller;
        public static WorldParticleController _particleController;
        public static CameraNoiseController _noiseController;

        public static readonly string ModPrefsKey = "ParticleOverdrive";

        public static float SlashParticleMultiplier;
        public static float ExplosionParticleMultiplier;

        public void Init(IPA.Logging.Logger logger)
        {
            Config.Init();
            Logger.logger = logger;
        }

        public void OnApplicationStart()
        {
            SlashParticleMultiplier = Config.SlashParticleMultiplier;
            ExplosionParticleMultiplier = Config.ExplosionParticleMultiplier;

            try
            {
                HarmonyInstance harmony = HarmonyInstance.Create("com.jackbaron.beatsaber.particleoverdrive");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception e)
            {
                Logger.Log("This plugin requires Harmony. Make sure you " +
                    "installed the plugin properly, as the Harmony DLL should have been installed with it.");
                Console.WriteLine(e);
            }

        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
        {

        }

        public void OnActiveSceneChanged(Scene _, Scene scene)
        {
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

            if (scene.name == "MenuViewControllers")
            {
                BSMLSettings.instance.AddSettingsMenu("Particle Overdrive", "ParticleOverdrive.UI.POUI.bsml", UI.POUI.instance);
            }
        }

        public void OnApplicationQuit() { }

        public void OnLevelWasInitialized(int level) { }

        public void OnLevelWasLoaded(int level) { }

        public void OnUpdate() { }

        public void OnFixedUpdate() { }

        public void OnSceneUnloaded(Scene scene) { }
    }
}
