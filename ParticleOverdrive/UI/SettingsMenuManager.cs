using BeatSaberMarkupLanguage.Settings;
using ParticleOverdrive.Misc;
using SiraUtil.Affinity;
using System;
using Zenject;

namespace ParticleOverdrive.UI
{
    internal class SettingsMenuManager : IInitializable, IDisposable, IAffinity
    {
        private readonly POUI _settingsMenu;
        private readonly BSMLSettings _bsmlSettings;
        private readonly ParticleConfig _config;

        private SettingsMenuManager(POUI poui, BSMLSettings bsmlSettings, ParticleConfig config)
        {
            _settingsMenu = poui;
            _bsmlSettings = bsmlSettings;
            _config = config;
        }

        public void Initialize()
        {
            _bsmlSettings.AddSettingsMenu("Particle Overdrive", "ParticleOverdrive.UI.POUI.bsml", _settingsMenu);
        }

        [AffinityPatch(typeof(ModSettingsFlowCoordinator), nameof(ModSettingsFlowCoordinator.Ok))]
        public void OkPressedButThisPatchIsOnlyTemporaryBecauseThisIsCurrentlyTheMostElegantWayToGetThisButtonEvent_uwu()
        {
            _config.SaveConfig();
        }

        public void Dispose()
        {
            _bsmlSettings.RemoveSettingsMenu(_settingsMenu);
        }
    }
}
