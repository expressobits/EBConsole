using UnityEngine;
using UnityEngine.Events;

namespace ExpressoBits.Console
{
    [RequireComponent(typeof(Commander), typeof(ToggleCommander))]
    public class HelpCommander : MonoBehaviour
    {
        [TextArea]
        public string helpTextToOpen = "Type <b><color=lightgreen>ENTER</color></b> to open the console";

        [TextArea]
        public string helpTextToClose = "Type <b><color=lightgreen>ESC</color></b> to open the console";

        private Commander m_Commander;
        private ToggleCommander m_ToggleCommander;

        private UnityAction m_Open;

        private void Awake()
        {
            m_Commander = GetComponent<Commander>();
        }

        private void Start()
        {
            //NOTE get package version?
            Logs.Instance.Log("Expresso Bits Console <color=red>v0.6.0</color>", 3f);

            Logs.Instance.LogHelp(helpTextToOpen);

            m_Open =
            (
                delegate
                {
                    Logs.Instance.LogHelp(helpTextToClose);
                    m_Commander.onOpenCommander.RemoveListener(this.m_Open);
                }
            );
            m_Commander.onOpenCommander.AddListener(m_Open);
        }


    }
}
