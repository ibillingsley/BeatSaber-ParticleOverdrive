using ParticleOverdrive.Misc;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace ParticleOverdrive.Controllers
{
    public class DustParticleController : IInitializable
    {
        private readonly ParticleConfig _config;
        private readonly ICoroutineStarter _coroutineStarter;

        private DustParticleController(ParticleConfig config, ICoroutineStarter coroutineStarter)
        {
            _config = config;
            _coroutineStarter = coroutineStarter;
        }

        private ParticleSystem _dustPS = null;

        public void Initialize()
        {
            // only has to be done in a coroutine because of MultiPlayer being like a frame too early...
            _coroutineStarter.StartCoroutine(InitializeCoroutine());
        }

        public void SetDustParticlesActive(bool active)
        {
            if (_dustPS) _dustPS.gameObject.SetActive(active);
        }

        private IEnumerator InitializeCoroutine()
        {
            yield return new WaitUntil(() => GetDustParticleSystem() != null);
            SetDustParticlesActive(_config.DustParticles);
        }

        private ParticleSystem GetDustParticleSystem() =>
            _dustPS = Object.FindObjectsOfType<ParticleSystem>().Where(p => p.name == "DustPS").FirstOrDefault();
    }
}
