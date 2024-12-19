using UnityEngine;
using ParticleOverdrive.Misc;
using Zenject;

namespace ParticleOverdrive.Controllers;

public class CameraNoiseController : IInitializable
{
    private readonly ParticleConfig _config;
    private readonly Texture2D _blankNoiseTexture;

    private CameraNoiseController(ParticleConfig config)
    {
        _config = config;
        _blankNoiseTexture = Texture2D.blackTexture;
        Color32 black = new(0, 0, 0, 255);
        Color32[] pixels = _blankNoiseTexture.GetPixels32();
        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = black;
        _blankNoiseTexture.SetPixels32(pixels);
        _blankNoiseTexture.Apply();
    }

    private BlueNoiseDitheringUpdater _ditheringUpdater;
    private Texture2D _originalNoiseTexture;

    public void Initialize()
    {
        _ditheringUpdater = GameObject.Find("BlueNoiseHelper").GetComponent<BlueNoiseDitheringUpdater>();
        SetCameraNoiseActive(_config.CameraGrain);
    }

    public void SetCameraNoiseActive(bool active)
    {
        if (_ditheringUpdater != null)
        {
            _originalNoiseTexture ??= _ditheringUpdater._blueNoiseDithering._noiseTexture;
            _ditheringUpdater._blueNoiseDithering._noiseTexture = active ? _originalNoiseTexture : _blankNoiseTexture;
        }
    }
}