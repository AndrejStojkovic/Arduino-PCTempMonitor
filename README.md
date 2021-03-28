<p align="center">
  <a href="https://github.com/AndrejStojkovic/Arduino-TempControl">
    <img src="/misc/ArduinoTempLogo.png" alt="Logo" width=150 height=125>
  </a>

  <h3 align="center">Arduino PC Temperature Monitor</h3>

  <p align="center">
    An Arduino project that I made in my free time to monitor my CPU and GPU temperature from my PC. 
    <br>
    <a href="https://github.com/AndrejStojkovic/Arduino-TempControl/issues">Report Bug or Request a Feature</a>
  </p>
</p>


## Table of contents

- [Quick start](#quick-start)
- [What's included](#whats-included)
- [Schematics](#schematics)
- [Preview](#preview)
- [TO-DO](#to-do)
- [Bugs and feature requests](#bugs-and-feature-requests)
- [Contributing](#contributing)
- [Creators](#creators)
- [License](#license)


## Quick start

What you will need for this project:
- Arduino UNO
- C# with .NET Framework 4.5+

Steps to make this work:
1. Download the release version from here: https://github.com/AndrejStojkovic/Arduino-PCTempMonitor/releases/tag/1.0 (Arduino-PCTempMonitor.zip)
2. Extract the files somewhere.
3. Plug in your Arduino to your PC and set it up according to the schematics.  
4. Upload the sketch from the sketches folder according to the schematic you followed. (W/o button - first sketch, with button - second sketch)
5. Then open the ConsoleTemp project from the Software Projects folder or just open the Debug folder and run the program.
6. Enter your 'COMx' from the Arduino (you can find this either in Device Manager or the Arduino IDE program) and enter the interval you want the stats to change.
7. And voila! It should work.


## What's included

```text
Arduino-PCTempMonitor/
└── Arduino/
    ├── Sketches/
    │   ├── sketch1.ino
    │   └── sketch2.ino
    └── I2Cscan/
        └── I2Cscan.ino
└── Software Projects/
    ├── ConsoleTemp/
    │   ├── bin/
    |   |   └── Debug/
    |   |       └── ConsoleTemp.exe
    |   |       └── ConsoleTemp.exe.config
    |   |       └── ConsoleTemp.pdb
    |   |       └── OpenHardwareMonitorLib.dll
    │   ├── App.config
    |   ├── ConsoleTemp.csproj
    |   ├── ConsoleTemp.sln
    |   └── app.manifest
    └── PCTempMonitor/
        └── empty
└── Schematics/
    ├── Schematic_1.fzz
    ├── Schematic_1.png
    ├── Schematic_2.fzz
    └── Schematic_2.png
└── misc/
    ├── ArduinoTempLogo.png
    ├── preview1.jpg
    └── preview2.jpg
```

## Schematics

Here are the schematics for the Arduino part.
Schematics were made with Fritzing.

Schematic 1:
<img src="/Schematics/Schematic_1.png" alt="Schematic 1">
  
  
Schematic 2: (The button is for turning off/on the backlight from the LCD)
<img src="/Schematics/Schematic_2.png" alt="Schematic 2">

## Preview

Here are some pictures of the project.

<img src="/misc/preview1.jpg" alt="Preview 1">
<img src="/misc/preview2.jpg" alt="Preview 2">

## TO-DO

- Add 'stop command' to C# program to stop displaying the temperature.
- Create an UI for the software.

## Bugs and feature requests

Have a bug or a feature request? Go to [Issues](https://github.com/AndrejStojkovic/Arduino-PCTempMonitor/issues) and post there.

## Contributing

To contribute, you can just make a Pull Request or go to [Issues](https://github.com/AndrejStojkovic/Arduino-PCTempMonitor/issues) and post there.

## Creators

- [Andrej Stojkovic](https://github.com/AndrejStojkovic)

## License

Code released under the [MIT License](LICENSE.md).

Enjoy :metal:
