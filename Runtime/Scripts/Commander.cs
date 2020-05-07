using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.Console.Commands;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ExpressoBits.Console
{
    public class Commander : Singleton<Commander>
    {
        [SerializeField]
        private string prefix = string.Empty;

        [SerializeField]
        private ConsoleCommand[] commands = new ConsoleCommand[0];

        [SerializeField]
        private ConsoleCommand commandWithoutPrefix = null;

        [Header("UI")]

        [SerializeField]
        private GameObject UICanvas = null;

        [SerializeField]
        private GameObject ToastMessages = null;

        [SerializeField]
        private InputField inputField = null;

        public UnityEvent OnCloseCommander;
        public UnityEvent OnOpenCommander;

        ///
        private static Commander instance;

        private DeveloperConsole developerConsole;
        private DeveloperConsole DeveloperConsole
        {
            get
            {
                if (developerConsole != null) { return developerConsole; }
                return developerConsole = new DeveloperConsole(prefix, commands, commandWithoutPrefix);
            }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        public void Toggle()
        {
            if (UICanvas.activeSelf)
            {
                CloseCommander();
            }
            else
            {
                OpenCommander();
            }
        }

        public void CloseCommander()
        {
            UICanvas.SetActive(false);
            ToastMessages.SetActive(true);
            OnCloseCommander.Invoke();
        }

        public void OpenCommander()
        {

            UICanvas.SetActive(true);
            ToastMessages.SetActive(false);
            //inputField.ActivateInputField();
            OnOpenCommander.Invoke();
        }

        public void ProcessCommand(string inputValue)
        {
            DeveloperConsole.ProcessCommand(inputValue);

            inputField.text = string.Empty;
        }


        public void Send()
        {
            if (inputField.text.Contains("\n"))
            {
                inputField.text = inputField.text.Remove(inputField.text.LastIndexOf("\n"));
                ProcessCommand(inputField.text);
            }
        }
    }

}

