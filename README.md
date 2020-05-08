# Welcome to Expresso Bits Console 👋
![Version](https://img.shields.io/badge/version-0.3.0-blue.svg?cacheSeconds=2592000)
[![Documentation](https://img.shields.io/badge/documentation-no-brightgreen.svg)](todo-doc)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](MIT)
[![Twitter: ScriptsEngineer](https://img.shields.io/twitter/follow/ScriptsEngineer.svg?style=social)](https://twitter.com/ScriptsEngineer)

![Demo2](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/Demo2.gif)

## Install


To install open <b>Window</b> > <b>Package Manager</b> and click on the + package icon and choose <b>"Add package from git url"</b> and type:

> https://github.com/ExpressoBits/EBConsole.git

and you're done!



## Usage
Add prefab Console to scene! 
For it to work correctly, an EventSystem is needed in your scene.

### Toggle Commander
By default the component added to the prefab called <i>ToggleCommander</i> opens the console with <i>Enter</i> and closes the console with <i>Esc</i>. You can modify these keys for your convenience, and you can also remove this component if you want another component / object to handle the commander.

### Commands
You can create custom commands by extending the <i>ConsoleCommand</i> class. 
Then just add the command's scriptable object to the <i>Commander</i> component.

### Commandos de log
![LogTypes](https://raw.githubusercontent.com/wiki/ExpressoBits/EBConsole/LogTypes.png)

It still has basic log commands that add messages to a panel below the console. These can be called up with:

```Logs.Instance.Log("Log Default");```

```Logs.Instance.LogWarning("Warning log");```

```Logs.Instance.LogError("Error log");```



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
