# Welcome to Expresso Bits Console 👋
![Version](https://img.shields.io/badge/version-1.1.1-blue.svg?cacheSeconds=2592000)
[![Documentation](https://img.shields.io/badge/documentation-yes-brightgreen.svg)](todo-doc)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](MIT)
[![Twitter: ScriptsEngineer](https://img.shields.io/twitter/follow/ScriptsEngineer.svg?style=social)](https://twitter.com/ScriptsEngineer)

![Demo4](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/Demo4.gif)

## Features

✔️ Commands with easy access.

✔️ Persistent logs in the form of toasts.

✔️ Command history.

✔️ Commands pre-established or added at run time.

✔️ Display Debug.Log messages in the console.

✔️ Adding status messages (Example: FPS)

🔨 Easy change of themes and visual by having separate interface and logic codes.


## Install


To install open <b>Window</b> > <b>Package Manager</b> and click on the + package icon and choose <b>"Add package from git url"</b> and type:

> https://github.com/ExpressoBits/EBConsole.git

and you're done!



## Usage
Add the prefab consoler in the scene and the visual consoler in a permanent visual interface (One that is not destroyed between scenes).
For it to work correctly, an EventSystem is needed in your scene.

## Components

### ![Consoler](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/Consoler.png) Consoler

The main component of the console system. The component is basically a utility for calling Singleton Commander and 
Log methods.Just add the components you want for a console of your taste!

### ![Commander](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/commander.png) Commander component

This component creates a visual bar for typing commands, it can be opened and closed using the ToggleCommander component or directly via code.
You can create custom commands by extending the <i>ConsoleCommand</i> class for add in commander component. 
Then just add the command's scriptable object to the <i>Commander</i> component.

### ![Logs](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/Logs.png) Logs component

![Demo3](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/Demo3.gif)

Component that displays responses from the console, when added creates a new visual component that allows displaying logs in toasts (when the commander is closed) and persistent logs until the defined limit is exceeded (this is displayed when the commander is open).

Here are a variety of settings to make:
- Log limit on the console
- Standard time to exit toast
- Log type colors and icons

> Note: <b>Rich text</b> is accepted in logs and commands

#### Log methods
![LogTypes](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/LogTypes.png)

It still has basic log commands that add messages to a panel below the console. These can be called up with:


| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/commander.png) | Log Type  | In Script    | In Commander |
|:---:|:-------------------------|:------|:-----|
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/log.png) | Default Log |  ```Consoler.Instance.Logs.Log("Log Default");``` | ```/log Log Default``` |
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/warn.png) | Warning Log |  ```Consoler.Instance.Logs.LogWarn("Warning log");```  |   ```/warn Warning log``` |
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/error.png) | Error Log | ```Consoler.Instance.Logs.LogError("Error log");``` |    ```/error Error log``` |
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/sucess.png) | Success Log | ```Consoler.Instance.Logs.LogSuccess("Success log");``` |    ```/error Success log``` |
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/help.png) | Help Log | ```Consoler.Instance.Logs.LogHelp("Help log");``` |    ```/error Help log``` |
|   | Clear the Log| ```Consoler.Instance.Logs.Clear();``` |    ```/clear``` |
> Note: the <b>/</b> prefix can be modified by the user in the commander component.


### ![ToggleCommander](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/ToggleCommander.png) Toggle Commander Component

By default the component added to the prefab called <i>ToggleCommander</i> opens the console with <i>Enter</i> and closes the console with <i>Esc</i>. You can modify these keys for your convenience, and you can also remove this component if you want another component / object to handle the commander.

### ![HelperCommander](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/HelpCommander.png) Helper commander component

![Demo2](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/helper.png)

Prints help messages to open the console, to close and the console version.

### ![History](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/history.png) History component

![Demo2](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/history.gif)

Stores the history of commands entered on the console, 
and also manages keyboard entries to navigate between the history (by default up and down arrow keys.

### ![Visual Consoler](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/VisualConsoler.png) Visual Consoler

Here what interface magic happens, where you can modify how you can visually represent the console!
> Note:This component must be placed as a child of some visual resource such as a Canvas, Panel.

### ![Theme](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/Theme.png) Theme

By default the comforting look comes with the <i>Pixel</i> theme, but can be modified to another customized theme. Just add it via the <i>Expresso Bits > Console > Theme</i> menu.

### Sample commands

| Command  |  Description |
|----------|:-------------------------|
| /log (message) |  ... | 
| /error (message) | ... |
| /warn (message) | ... |
| /error (message) | ... |
| /success (message) | ... |
| /help (message) | ... |
| /history | ... |
| /clear | ... |
| /gravity (float) / (float) (float) (float) | ... |
| /help | ... |

Please let me know some command ideas to be added here, use the [issues page](https://github.com/ExpressoBits/EBConsole/issues) for that!


### ![Stater](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/Stater.png) Stater

![Stater](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/Stats.png)

This component other is used alone, it is used to add power feature display messages that stay somewhere on the screen with status function . A good example is the use of fps (Frames per second) status that is used by a prefab with the Stater component.

At the moment it is extremely simple and should always be linked to a Visual Stater

### ![Visual Stater](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/VisualStater.png) Visual Stater

Just like Visual Consoler, it separates every visual part of the stater. Here can be defined a visual prefab that I have InfoMessage as a component.

> Note: Can be modified to anywhere and corner of the screen the component.


## Authors

👤 **Rafael Correa**
(Script)
* Twitter: [@ScriptsEngineer](https://twitter.com/ScriptsEngineer)
* Github: [@scriptsengineer](https://github.com/scriptsengineer)


## 🤝 Contributing

Contributions, issues and feature requests are welcome!

Feel free to check [issues page](https://github.com/ExpressoBits/EBConsole/issues).

## Show your support

Give a ⭐️ if this project helped you!


## 📝 License

Copyright © 2020 [Rafael Correa](https://github.com/scriptsengineer).

This project is [MIT](MIT) licensed.

***
_This README was generated with ❤️ by [readme-md-generator](https://github.com/kefranabg/readme-md-generator)_
