using BeatSaberMarkupLanguage.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace ParticleOverdrive.UI
{
    internal class SettingsMenuManager : IInitializable, IDisposable
    {
        private readonly POUI _settingsMenu;
        private readonly BSMLSettings _bsmlSettings;

        private SettingsMenuManager(POUI poui, BSMLSettings bsmlSettings)
        {
            _settingsMenu = poui;
            _bsmlSettings = bsmlSettings;
        }

        public void Initialize()
        {
            _bsmlSettings.AddSettingsMenu("Particle Overdrive", "ParticleOverdrive.UI.POUI.bsml", _settingsMenu);
        }

        public void Dispose()
        {
            _bsmlSettings.RemoveSettingsMenu(_settingsMenu);
        }
    }
}
