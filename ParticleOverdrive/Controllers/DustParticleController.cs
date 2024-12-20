using ParticleOverdrive.Misc;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace ParticleOverdrive.Controllers;

internal class DustParticleController : IInitializable
{
    private readonly ParticleConfig config;
    private readonly ICoroutineStarter coroutineStarter;
    private readonly string dustParticlesName;
    
    private DustParticleController(ParticleConfig config, ICoroutineStarter coroutineStarter, [InjectOptional] EnvironmentSceneSetupData? environmentData)
    {
        this.config = config;
        this.coroutineStarter = coroutineStarter;
        dustParticlesName = environmentData == null ? "DustPS" : environmentData.environmentInfo.serializedName switch
        {
            "BritneyEnvironment" => "DustBritney",
            _ => "DustPS"
        };
    }

    private ParticleSystem? dustPS;

    public void Initialize()
    {
        // only has to be done in a coroutine because of MultiPlayer being like a frame too early...
        coroutineStarter.StartCoroutine(InitializeCoroutine());
    }

    private IEnumerator InitializeCoroutine()
    {
        yield return new WaitUntil(() =>
        {
            dustPS = Object.FindObjectsOfType<ParticleSystem>().FirstOrDefault(p => p.name == dustParticlesName);
            return dustPS != null;
        });
        if (dustPS != null) dustPS.gameObject.SetActive(config.DustParticles);
    }
}