using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Log Command", menuName = "Expresso Bits/Console/Log Command")]
    public class LogCommand : ConsoleCommand
    {

        private void Awake()
        {
            commandWord = "log";
        }

        public override bool Process(string[] args)
        {
            var logText = string.Join(" ", args);

            if (logText.Length <= 0) return false;

            if (Consoler.Logs != null) Consoler.Logs.Log(logText);

            return true;
        }
    }
}