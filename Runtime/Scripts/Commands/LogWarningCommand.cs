using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Log Warning Command", menuName = "Expresso Bits/Console/Log Warning Command")]
    public class LogWarningCommand : ConsoleCommand
    {

        private void Awake()
        {
            commandWord = "warn";
        }

        public override bool Process(string[] args)
        {
            var logText = string.Join(" ", args);

            if (logText.Length <= 0) return false;

            if (Consoler.Instance.Logs != null) Consoler.Instance.Logs.LogWarn(logText);

            return true;
        }
    }
}