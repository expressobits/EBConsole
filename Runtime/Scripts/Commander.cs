using System;
using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.Console.Commands;
using UnityEngine.Events;

namespace ExpressoBits.Console
{
    [AddComponentMenu(menuName: "Console/Commander")]
    [RequireComponent(typeof(Consoler))]
    public class Commander : MonoBehaviour
    {

        [Header("General Settings")]
        public string prefix = string.Empty;

        [Header("List of valid Static commands")]
        public ConsoleCommand[] staticCommands;
        public readonly List<ICommand> commands = new List<ICommand>();

        public ConsoleCommand commandWithoutPrefix;

        [Header("Events")]
        public UnityEvent onCloseCommander;
        public UnityEvent onOpenCommander;
        public UnityEvent onProcessCommand;
        public UnityEvent onFinishProcessCommand;

        public Action<string> onChangeInputCommander;

        public bool IsOpen => m_IsOpen;
        public string Input
        {
            get => m_Input;
            set
            {
                m_Input = value;
                onChangeInputCommander?.Invoke(m_Input);
            }
        }
        
        #region private values
        private bool m_IsOpen;
        private string m_Input = string.Empty;
        private DeveloperConsole m_DeveloperConsole;
        private DeveloperConsole DeveloperConsole
        {
            get
            {
                if (m_DeveloperConsole != null) { return m_DeveloperConsole; }
                foreach (var item in staticCommands)
                {
                    commands.Add(item);
                }
                return m_DeveloperConsole = new DeveloperConsole(prefix, commands, commandWithoutPrefix);
            }
        }

        #endregion

        private void Start()
        {
            CloseCommander();
        }

        #region Open/Close
        // Close commander
        public void CloseCommander()
        {
            if (!m_IsOpen) return;
            m_IsOpen = false;
            onCloseCommander.Invoke();
        }

        // Open commander
        public void OpenCommander()
        {
            if (m_IsOpen) return;
            m_IsOpen = true;
            onOpenCommander.Invoke();
        }

        // Enable/disable commander
        public void Toggle()
        {
            if (m_IsOpen)
            {
                CloseCommander();
            }
            else
            {
                OpenCommander();
            }
        }

        #endregion

        #region Command actions
        // Process command per string input
        public void ProcessCommand()
        {

            DeveloperConsole.ProcessCommand(Input);
            onProcessCommand.Invoke();
            onFinishProcessCommand.Invoke();
            Input = string.Empty;
        }

        // Add command create in runtime, create new command with
        // <code>new Command("test",delegate{ Test(); })</code>
        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        // Add command create in runtime with action
        public void AddCommand(string commandWord, UnityAction action)
        {
            commands.Add(new Command(commandWord,action));
        }
        #endregion

    }

}

