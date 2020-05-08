using UnityEngine;
using ExpressoBits.Console.Commands;
using UnityEngine.UI;
using UnityEngine.Events;
using ExpressoBits.Console.Utils;

namespace ExpressoBits.Console
{
    public class Commander : Singleton<Commander>
    {

        [Header("General Settings")]
        [SerializeField]
        private string prefix = string.Empty;

        [Header("List of valid commands")]
        [SerializeField]
        private ConsoleCommand[] commands = new ConsoleCommand[0];

        [SerializeField]
        /** Command process when process string without prefix */
        private ConsoleCommand commandWithoutPrefix = null;


        [Header("UI")]
        public InputField consoleInputPrefab;

        public Font font;

        [Header("Events")]
        public UnityEvent OnCloseCommander;
        public UnityEvent OnOpenCommander;

        #region private values
        private Canvas UICanvas = null;

        private InputField consoleInput;

        private DeveloperConsole developerConsole;
        private DeveloperConsole DeveloperConsole
        {
            get
            {
                if (developerConsole != null) { return developerConsole; }
                return developerConsole = new DeveloperConsole(prefix, commands, commandWithoutPrefix);
            }
        }

        #endregion

        private void Awake()
        {

            UICanvas = GetComponentInChildren<Canvas>();

            consoleInput = Instantiate<InputField>(consoleInputPrefab, UICanvas.gameObject.transform);
            consoleInput.onValueChanged.AddListener(delegate { Send(); });

            consoleInput.GetComponentInChildren<Text>().font = font;

            consoleInput.gameObject.SetActive(false);


        }


        #region Open/Close
        public void CloseCommander()
        {
            consoleInput.gameObject.SetActive(false);
            //consoleInput.DeactivateInputField();
            OnCloseCommander.Invoke();
        }

        public void OpenCommander()
        {
            consoleInput.gameObject.SetActive(true);
            consoleInput.ActivateInputField();
            OnOpenCommander.Invoke();
        }

        #endregion

        public void ProcessCommand(string inputValue)
        {
            bool success = DeveloperConsole.ProcessCommand(inputValue);

            consoleInput.text = string.Empty;
        }

        public void Send()
        {

            if (consoleInput.text.Contains("\n"))
            {
                consoleInput.text = consoleInput.text.Remove(consoleInput.text.LastIndexOf("\n"));
                ProcessCommand(consoleInput.text);
            }



        }

        public void Toggle()
        {
            if (consoleInput.gameObject.activeSelf)
            {
                CloseCommander();
            }
            else
            {
                OpenCommander();
            }
        }
    }

}

