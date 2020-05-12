using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Log Help Command", menuName = "Expresso Bits/Console/Log Help Command")]
    public class LogHelpCommand : ConsoleCommand
    {

        private void Awake()
        {
            commandWord = "help";
        }

        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);

            if (logText.Length <= 0)
            {
                if (Commander.Instance.GetComponent<Logs>() == null) return false;
                foreach (ICommand command in Commander.Instance.commands)
                {
                    Logs.Instance.LogHelp("/" + command.CommandWord);
                }
                Logs.Instance.LogHelp("--- All Valid Commands ---");
                return true;
            }

            Debug.Log(logText);
            if (Commander.Instance.GetComponent<Logs>() != null) Logs.Instance.LogHelp(logText);

            return true;
        }

    }
}