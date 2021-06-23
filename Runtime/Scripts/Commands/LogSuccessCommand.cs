using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Log Success Command", menuName = "Expresso Bits/Console/Log Success Command")]
    public class LogSuccessCommand : ConsoleCommand
    {

        private void Awake()
        {
            commandWord = "success";
        }

        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);

            if (logText.Length <= 0) return false;

            if (Consoler.Logs != null) Consoler.Logs.LogSuccess(logText);

            return true;
        }
    }
}