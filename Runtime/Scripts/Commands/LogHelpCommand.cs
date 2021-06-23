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
                if (Consoler.Logs == null) return false;
                foreach (ICommand command in Consoler.Commander.commands)
                {
                    Consoler.Logs.LogHelp("/" + command.CommandWord);
                }
                Consoler.Logs.LogHelp("--- All Valid Commands ---");
                return true;
            }

            if (Consoler.Logs != null) Consoler.Logs.LogHelp(logText);

            return true;
        }

    }
}