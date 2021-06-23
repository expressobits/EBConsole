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
                if (Consoler.Instance.Logs == null) return false;
                foreach (ICommand command in Consoler.Instance.Commander.commands)
                {
                    Consoler.Instance.Logs.LogHelp("/" + command.CommandWord);
                }
                Consoler.Instance.Logs.LogHelp("--- All Valid Commands ---");
                return true;
            }

            if (Consoler.Instance.Logs != null) Consoler.Instance.Logs.LogHelp(logText);

            return true;
        }

    }
}