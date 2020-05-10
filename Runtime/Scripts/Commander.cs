using System;
using System.Collections.Generic;
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
        public List<ConsoleCommand> commands = new List<ConsoleCommand>();

        [SerializeField] private ConsoleCommand commandWithoutPrefix;


        [Header("UI")]
        public InputField consoleInputPrefab;

        public Font font;

        [Header("Events")]
        public UnityEvent onCloseCommander;
        public UnityEvent onOpenCommander;

        #region private values
        private Canvas m_UiCanvas;

        private InputField m_ConsoleInput;

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

            m_ConsoleInput = Instantiate(consoleInputPrefab, m_UiCanvas.gameObject.transform);
            m_ConsoleInput.onValueChanged.AddListener(delegate { Send(); });

            m_ConsoleInput.GetComponentInChildren<Text>().font = font;

            m_ConsoleInput.gameObject.SetActive(false);


        }


        #region Open/Close
        public void CloseCommander()
        {
            m_ConsoleInput.gameObject.SetActive(false);
            //consoleInput.DeactivateInputField();
            onCloseCommander.Invoke();
        }

        public void OpenCommander()
        {
            m_ConsoleInput.gameObject.SetActive(true);
            m_ConsoleInput.ActivateInputField();
            onOpenCommander.Invoke();
        }

        #endregion

        public void ProcessCommand(string inputValue)
        {
            DeveloperConsole.ProcessCommand(inputValue);

            m_ConsoleInput.text = string.Empty;
        }

        public void Send()
        {
            if (!m_ConsoleInput.text.Contains("\n")) return;
            var text = (m_ConsoleInput.text).Remove(m_ConsoleInput.text.LastIndexOf("\n", StringComparison.Ordinal));
            m_ConsoleInput.text = text;
            ProcessCommand(text);
        }

        public void Toggle()
        {
            if (m_ConsoleInput.gameObject.activeSelf)
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

