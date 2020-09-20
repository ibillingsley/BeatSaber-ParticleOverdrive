using BeatSaberMarkupLanguage.Attributes;
using ParticleOverdrive.Misc;
using System.Collections.Generic;

namespace ParticleOverdrive.UI
{
    public class POUI : PersistentSingleton<POUI>
    {
        internal const float Infinity = 100000f;
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
        [UIValue("lifetime-values")]
        internal static List<object> LifetimeValues = new List<object>
            {
                0f,
                0.1f,
                0.2f,
                0.3f,
                0.4f,
                0.5f,
                0.6f,
                0.7f,
                0.8f,
                0.9f,
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
                7.5f,
                10f,
                15f,
                20f,
                30f,
                40f,
                50f,
                75f,
                100f
            };

        [UIValue("slashParticleChoices")]
        private List<object> _slashParticleMultiplierChoices = particleMultiplierChoicesList;

        [UIValue("slashParticleSpeedChoices")]
        private List<object> _slashParticleSpeedChoices = particleMultiplierChoicesList;

        [UIValue("explosionParticleChoices")]
        private List<object> _explosionParticleMultiplierChoices = particleMultiplierChoicesList;

        [UIValue("clashParticleChoices")]
        private List<object> _clashParticleMultiplierChoices = particleMultiplierChoicesList;

        [UIValue("lifetimeChoices")]
        private List<object> _lifetimeChoices = LifetimeValues;

        [UIValue("cameraNoiseEnable")]
        public bool _cameraNoiseEnable
        {
            //get => Plugin._noiseController.Enabled;
            get => Config.CameraGrain;
            set
            {

                if (Plugin.CameraNoiseWorldParticlesEnabled)
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
                if (Plugin.CameraNoiseWorldParticlesEnabled)
                    Plugin._particleController.Enabled = value;
                Config.DustParticles = value;
            }
        }

        [UIValue("slashParticleChoice")]
        public float _slashParticleMultiplier
        {
            get => Config.SlashParticleMultiplier;
            set
            {
                Plugin.SlashParticleMultiplier = value;
                Config.SlashParticleMultiplier = value;
            }
        }

        [UIValue("slashParticleLifetimeChoice")]
        public float _slashParticleLifetimeMultiplier
        {
            get => Config.SlashParticleLifetimeMultiplier;
            set
            {
                Plugin.SlashParticleLifetimeMultiplier = value;
                Config.SlashParticleLifetimeMultiplier = value;
            }
        }

        //[UIValue("slashParticleSpeedChoice")]
        //public float _slashParticleSpeedMultiplier
        //{
        //    get => Config.SlashParticleSpeedMultiplier;
        //    set
        //    {
        //        Plugin.SlashParticleSpeedMultiplier = value;
        //        Config.SlashParticleSpeedMultiplier = value;
        //    }
        //}

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


        [UIValue("explosionParticleLifetimeChoice")]
        public float _explosionParticleLifetimeMultiplier
        {
            //get => Config.ExplosionParticleLifetimeMultiplier;
            get => Config.ExplosionParticleLifetimeMultiplier;
            set
            {
                Plugin.ExplosionParticleLifetimeMultiplier = value;
                Config.ExplosionParticleLifetimeMultiplier = value;
            }
        }

        [UIValue("rainbowParticlesEnable")]
        public bool _rainbowParticlesEnable
        {
            //get => Plugin._noiseController.Enabled;
            get => Config.RainbowParticles;
            set
            {
                Plugin.RainbowParticles = value;
                Config.RainbowParticles = value;
            }
        }

        [UIValue("clashParticleChoice")]
        public float _clashParticleMultiplier
        {
            //get => Config.ClashParticleMultiplier;
            get => Config.ClashParticleMultiplier;
            set
            {
                Plugin.ClashParticleMultiplier = value;
                Config.ClashParticleMultiplier = value;
            }
        }


        [UIValue("clashParticleLifetimeChoice")]
        public float _clashParticleLifetimeMultiplier
        {
            //get => Config.ClashParticleMultiplier;
            get => Config.ClashParticleLifetimeMultiplier;
            set
            {
                Plugin.ClashParticleLifetimeMultiplier = value;
                Config.ClashParticleLifetimeMultiplier = value;
            }
        }

        [UIAction("multiplierFormatter")]
        public string multiplierDisplay(float multiplier)
        {
            return $"{multiplier * 100f}%";
        }
    }
}
