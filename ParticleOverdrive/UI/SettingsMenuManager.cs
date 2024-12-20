using BeatSaberMarkupLanguage.Settings;
using ParticleOverdrive.Misc;
using SiraUtil.Affinity;
using System;
using Zenject;

namespace ParticleOverdrive.UI;

internal class SettingsMenuManager : IInitializable, IDisposable, IAffinity
{
    private readonly SettingsMenu settingsMenu;
    private readonly BSMLSettings bsmlSettings;
    private readonly ParticleConfig config;

    private SettingsMenuManager(SettingsMenu settingsMenu, BSMLSettings bsmlSettings, ParticleConfig config)
    {
        this.settingsMenu = settingsMenu;
        this.bsmlSettings = bsmlSettings;
        this.config = config;
    }

    public void Initialize()
    {
        bsmlSettings.AddSettingsMenu("Particle Overdrive", "ParticleOverdrive.UI.SettingsMenu.bsml", settingsMenu);
    }

    [AffinityPatch(typeof(ModSettingsFlowCoordinator), nameof(ModSettingsFlowCoordinator.Ok))]
    public void OkPressedButThisPatchIsOnlyTemporaryBecauseThisIsCurrentlyTheMostElegantWayToGetThisButtonEvent_uwu()
    {
        config.SaveConfig();
    }

    public void Dispose()
    {
        bsmlSettings.RemoveSettingsMenu(settingsMenu);
    }
}