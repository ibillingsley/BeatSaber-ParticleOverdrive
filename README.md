# Particle Overdrive
*Plugin for [Beat Saber](http://beatsaber.com/)*

* Plugin made by lolPants
* BSIPA conversion by Steven 🎀
* Additional contributions by Zingabopp

## Features
* Disable Camera Noise
* Disable global particle haze
* Configure note slash particle amount, lifetime and size
* Configure note explosion particle amount, lifetime and size
* Disable note core particles
* Configure saber clash particle amount, lifetime and size
* Configure saber wall particle amount, lifetime and size
* Disable saber clash glow
* Add rainbow colors to particles

## Usage
You can either configure the plugin by editing `UserData\ParticleOverdrive.ini`, but the preferred method of configuration is using the in-game settings menu.  

## Thanks
* **SkyKiwi** // Creating ChromaToggle, the mod that inspired this mod. (I also used some of it's code as a starting point `<3`)

## Developers

### Contributing to ParticleOverdrive
In order to build this project, you'll need a local, modded installation of Beat Saber with the required mod dependencies installed. Add a `ParticleOverdrive.csproj.user` file in the project directory and specify where your game is located on your disk:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <!-- Change this path if necessary. Make sure it doesn't end with a backslash. -->
    <BeatSaberDir>C:\Program Files\Steam\steamapps\common\Beat Saber\</BeatSaberDir>
  </PropertyGroup>
</Project>
```
