using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.Console.Commands;
using UnityEngine.UI;
using UnityEngine.Events;
using ExpressoBits.Console.Utils;

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
            Logs.Instance.LogHelp(helpTextToOpen, 4f);

            open =
            (
                delegate
                {
                    Logs.Instance.LogHelp(helpTextToClose, 4f);
                    commander.OnOpenCommander.RemoveListener(this.open);
                }
            );
            commander.OnOpenCommander.AddListener(open);
        }


    }
}
