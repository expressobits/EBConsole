using System;
using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.Console.Commands;
using UnityEngine.UI;
using UnityEngine.Events;
using ExpressoBits.Console.Utils;
using UnityEngine.Serialization;

namespace ExpressoBits.Console
{
    public class Commander : Singleton<Commander>
    {

        [Header("General Settings")]
        [SerializeField]
        private string prefix = string.Empty;

        [Header("List of valid commands")]
        public List<ConsoleCommand> commands = new List<ConsoleCommand>();

        [SerializeField] private ConsoleCommand commandWithoutPrefix;


        [Header("UI")]
        public InputField consoleInputPrefab;

        public Font font;

        [Header("Events")]
        public UnityEvent onCloseCommander;
        public UnityEvent onOpenCommander;
        public UnityEvent onProcessCommand;
        
        #region private values
        private Canvas m_UiCanvas;
        
        [HideInInspector]
        public InputField consoleInput;

        private DeveloperConsole m_DeveloperConsole;
        private DeveloperConsole DeveloperConsole
        {
            get
            {
                if (m_DeveloperConsole != null) { return m_DeveloperConsole; }
                return m_DeveloperConsole = new DeveloperConsole(prefix, commands, commandWithoutPrefix);
            }
        }

        #endregion

        private void Awake()
        {

            m_UiCanvas = GetComponentInChildren<Canvas>();

            consoleInput = Instantiate(consoleInputPrefab, m_UiCanvas.gameObject.transform);
            consoleInput.onValueChanged.AddListener(delegate { Send(); });

            consoleInput.GetComponentInChildren<Text>().font = font;

            consoleInput.gameObject.SetActive(false);


        }


        #region Open/Close
        public void CloseCommander()
        {
            consoleInput.gameObject.SetActive(false);
            //consoleInput.DeactivateInputField();
            onCloseCommander.Invoke();
        }

        public void OpenCommander()
        {
            consoleInput.gameObject.SetActive(true);
            consoleInput.ActivateInputField();
            onOpenCommander.Invoke();
        }

        #endregion

        public void ProcessCommand(string inputValue)
        {
            DeveloperConsole.ProcessCommand(inputValue);
            
            onProcessCommand.Invoke();

            consoleInput.text = string.Empty;
        }

        public void Send()
        {
            if (!consoleInput.text.Contains("\n")) return;
            var text = (consoleInput.text).Remove(consoleInput.text.LastIndexOf("\n", StringComparison.Ordinal));
            consoleInput.text = text;
            ProcessCommand(text);
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

        // TODO create métodos que adicionam action para comandos
        public void AddCommand(ConsoleCommand command)
        {
            commands.Add(command);
        }

    }

}

