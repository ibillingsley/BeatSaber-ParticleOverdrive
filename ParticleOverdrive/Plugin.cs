﻿using IPA;
using ParticleOverdrive.Installers;
using SiraUtil.Zenject;
using IPA.Loader;
using IPALogger = IPA.Logging.Logger;

namespace ParticleOverdrive;

[Plugin(RuntimeOptions.SingleStartInit), NoEnableDisable]
public class Plugin
{
    [Init]
    public Plugin(Zenjector zenjector, PluginMetadata metadata, IPALogger logger)
    {
        zenjector.UseLogger(logger);
        zenjector.Install<AppInstaller>(Location.App);
        zenjector.Install<MenuInstaller>(Location.Menu);
        zenjector.Install<PlayerInstaller>(Location.Player);
        zenjector.Install<WorldParticlesInstaller>(Location.Menu | Location.Player);
        
        logger.Info($"{metadata.Name} {metadata.HVersion} initialized.");
    }
}