using ParticleOverdrive.Misc;
using Zenject;

namespace ParticleOverdrive.Installers;

internal class AppInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<ParticleConfig>().AsSingle();
    }
}