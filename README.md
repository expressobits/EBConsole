# Welcome to Expresso Bits Console 👋
![Version](https://img.shields.io/badge/version-0.8.0-blue.svg?cacheSeconds=2592000)
[![Documentation](https://img.shields.io/badge/documentation-yes-brightgreen.svg)](todo-doc)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](MIT)
[![Twitter: ScriptsEngineer](https://img.shields.io/twitter/follow/ScriptsEngineer.svg?style=social)](https://twitter.com/ScriptsEngineer)

![Demo2](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/Demo3.gif)

## Install


To install open <b>Window</b> > <b>Package Manager</b> and click on the + package icon and choose <b>"Add package from git url"</b> and type:

> https://github.com/ExpressoBits/EBConsole.git

and you're done!



## Usage
Add prefab Console to scene! 
For it to work correctly, an EventSystem is needed in your scene.

## Components

### ![Commander](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/commander.png) Commander component

The main component of the console system.
You can create custom commands by extending the <i>ConsoleCommand</i> class for add in commander component. 
Then just add the command's scriptable object to the <i>Commander</i> component.

### ![Logs](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Editor/Textures/messageLog.png) Logs component

Component that displays responses from the console, when added creates a new visual component that allows displaying logs in toasts (when the commander is closed) and persistent logs until the defined limit is exceeded (this is displayed when the commander is open).

Here are a variety of settings to make:
- Log limit on the console
- Standard time to exit toast
- Log type colors and icons

> Note: <b>Rich text</b> is accepted in logs and commands

#### Log methods
![LogTypes](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/LogTypes.png)

It still has basic log commands that add messages to a panel below the console. These can be called up with:


| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/commander.png) | Log Type  | In Script    | In console |
|:---:|:-------------------------|:------|:-----|
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/log.png) | Default Log |  ```Logs.Instance.Log("Log Default");``` | ```/log Log Default``` |
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/warn.png) | Warning Log |  ```Logs.Instance.LogWarn("Warning log");```  |   ```/warn Warning log``` |
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/error.png) | Error Log | ```Logs.Instance.LogError("Error log");``` |    ```/error Error log``` |
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/sucess.png) | Success Log | ```Logs.Instance.LogSuccess("Success log");``` |    ```/error Success log``` |
| ![icon](https://raw.githubusercontent.com/ExpressoBits/EBConsole/master/Runtime/Textures/help.png) | Help Log | ```Logs.Instance.LogHelp("Help log");``` |    ```/error Help log``` |
|   | Clear the Log| ```Logs.Instance.Clear();``` |    ```/clear``` |
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
