using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.Console.Commands;
using UnityEngine.UI;
using UnityEngine.Events;
using ExpressoBits.Console.Utils;
using UnityEditor.PackageManager;

namespace ExpressoBits.Console
{
    [RequireComponent(typeof(Commander), typeof(ToggleCommander))]
    public class HelpCommander : MonoBehaviour
    {
        [TextArea]
        public string helpTextToOpen = "Type <b><color=lightgreen>ENTER</color></b> to open the console";

        [TextArea]
        public string helpTextToClose = "Type <b><color=lightgreen>ESC</color></b> to open the console";

        private Commander commander;
        private ToggleCommander toggleCommander;

        private UnityAction open;

        private void Awake()
        {
            commander = GetComponent<Commander>();
        }

        private void Start()
        {
            //NOTE get package version?
            Logs.Instance.Log("Expresso Bits Console <color=red>v0.5.1</color>", 3f);

            Logs.Instance.LogHelp(helpTextToOpen);

            open =
            (
                delegate
                {
                    Logs.Instance.LogHelp(helpTextToClose);
                    commander.OnOpenCommander.RemoveListener(this.open);
                }
            );
            commander.OnOpenCommander.AddListener(open);
        }


    }
}
