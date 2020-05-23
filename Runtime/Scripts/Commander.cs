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
        public List<ICommand> commands = new List<ICommand>();

        public ConsoleCommand commandWithoutPrefix;

        [Header("Events")]
        public UnityEvent onCloseCommander;
        public UnityEvent onOpenCommander;
        public UnityEvent onProcessCommand;
        public UnityEvent onFinishProcessCommand;

        #region private values

        private bool m_ActiveInput;
        private DeveloperConsole m_DeveloperConsole;
        private DeveloperConsole DeveloperConsole
        {
            get
            {
                foreach (var item in staticCommands)
                {
                    commands.Add(item);
                }
                if (m_DeveloperConsole != null) { return m_DeveloperConsole; }
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
            m_ActiveInput = false;
            onCloseCommander.Invoke();
        }

        // Open commander
        public void OpenCommander()
        {
            m_ActiveInput = true;
            onOpenCommander.Invoke();
        }

        // Enable/disable commander
        public void Toggle()
        {
            if (m_ActiveInput)
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
        public void ProcessCommand(string inputValue)
        {

            DeveloperConsole.ProcessCommand(inputValue);
            onProcessCommand.Invoke();
            onFinishProcessCommand.Invoke();

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

