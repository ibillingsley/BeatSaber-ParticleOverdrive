using ParticleOverdrive.Controllers;
using ParticleOverdrive.UI;
using Zenject;

namespace ParticleOverdrive.Installers;

internal class MenuInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<POUI>().AsSingle();
        Container.BindInterfacesTo<SettingsMenuManager>().AsSingle();
    }
}