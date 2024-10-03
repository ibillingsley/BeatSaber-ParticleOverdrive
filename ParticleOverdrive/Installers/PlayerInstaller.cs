using ParticleOverdrive.Patches;
using Zenject;

namespace ParticleOverdrive.Installers
{
    internal class PlayerInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<NoteCutParticlesEffectPatch>().AsSingle();
            Container.BindInterfacesTo<ObstacleSaberSparkleEffectPatch>().AsSingle();
            Container.BindInterfacesTo<SaberClashEffectPatch>().AsSingle();
        }
    }
}
