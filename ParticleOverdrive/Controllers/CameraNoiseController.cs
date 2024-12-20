using UnityEngine;
using ParticleOverdrive.Misc;
using Zenject;

namespace ParticleOverdrive.Controllers;

internal class CameraNoiseController : IInitializable
{
    private readonly ParticleConfig config;
    private readonly Texture2D blankNoiseTexture;

    private CameraNoiseController(ParticleConfig config)
    {
        this.config = config;
        blankNoiseTexture = Texture2D.blackTexture;
        var pixelColors = blankNoiseTexture.GetPixels32();
        for (int i = 0; i < pixelColors.Length; i++) pixelColors[i] = Color.black;
        blankNoiseTexture.SetPixels32(pixelColors);
        blankNoiseTexture.Apply();
    }

    private BlueNoiseDitheringUpdater? ditheringUpdater;
    private Texture2D? originalNoiseTexture;

    public void Initialize()
    {
        ditheringUpdater = GameObject.Find("BlueNoiseHelper").GetComponent<BlueNoiseDitheringUpdater>();
        SetCameraNoiseActive(config.CameraGrain);
    }

    public void SetCameraNoiseActive(bool active)
    {
        if (ditheringUpdater != null)
        {
            originalNoiseTexture ??= ditheringUpdater._blueNoiseDithering._noiseTexture;
            ditheringUpdater._blueNoiseDithering._noiseTexture = active ? originalNoiseTexture : blankNoiseTexture;
        }
    }
}