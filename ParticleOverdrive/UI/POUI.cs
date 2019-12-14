using BeatSaberMarkupLanguage.Attributes;
using ParticleOverdrive.Misc;
using System.Collections.Generic;

namespace ParticleOverdrive.UI
{
    public class POUI : PersistentSingleton<POUI>
    {
        public static readonly List<object> particleMultiplierChoicesList = new List<object>()
        {
            0f,
            1f,
            1.1f,
            1.2f,
            1.3f,
            1.4f,
            1.5f,
            1.6f,
            1.7f,
            1.8f,
            1.9f,
            2f,
            2.25f,
            2.5f,
            2.75f,
            3f,
            3.25f,
            3.5f,
            3.75f,
            4f,
            4.25f,
            4.5f,
            4.75f,
            5f,
            5.5f,
            6f,
            6.5f,
            7f,
            7.5f,
            8f,
            8.5f,
            9f,
            9.5f,
            10f,
            11f,
            12f,
            13f,
            14f,
            15f,
            16f,
            17f,
            18f,
            19f,
            20f,
            22.5f,
            25f,
            27.5f,
            30f,
            32.5f,
            35f,
            37.5f,
            40f,
            42.5f,
            45f,
            47.5f,
            50f,
            55f,
            60f,
            65f,
            70f,
            75f,
            80f,
            85f,
            90f,
            100f,
            110f,
            120f,
            130f,
            140f,
            150f,
            160f,
            170f,
            180f,
            190f,
            200f
        };

        [UIValue("slashParticleChoices")]
        private List<object> _slashParticleMultiplierChoices = particleMultiplierChoicesList;

        [UIValue("explosionParticleChoices")]
        private List<object> _explosionParticleMultiplierChoices = particleMultiplierChoicesList;

        [UIValue("cameraNoiseEnable")]
        public bool _cameraNoiseEnable
        {
            //get => Plugin._noiseController.Enabled;
            get => Config.CameraGrain;
            set
            {
                Plugin._noiseController.Enabled = value;
                Config.CameraGrain = value;
            }
        }

        [UIValue("dustParticleEnable")]
        public bool _dustParticleEnable
        {
            //get => Plugin._particleController.Enabled;
            get => Config.DustParticles;
            set
            {
                Plugin._particleController.Enabled = value;
                Config.DustParticles = value;
            }
        }

        [UIValue("slashParticleChoice")]
        public float _slashParticleMultiplier
        {
            //get => Config.SlashParticleMultiplier;
            get => Config.SlashParticleMultiplier;
            set
            {
                Plugin.SlashParticleMultiplier = value;
                Config.SlashParticleMultiplier = value;
            }
        }

        [UIValue("explosionParticleChoice")]
        public float _explosionParticleMultiplier
        {
            //get => Config.ExplosionParticleMultiplier;
            get => Config.ExplosionParticleMultiplier;
            set
            {
                Plugin.ExplosionParticleMultiplier = value;
                Config.ExplosionParticleMultiplier = value;
            }
        }

        [UIAction("multiplierFormatter")]
        public string multiplierDisplay (float multiplier)
        {
            return $"{multiplier * 100f}%";
        }
    }
}
