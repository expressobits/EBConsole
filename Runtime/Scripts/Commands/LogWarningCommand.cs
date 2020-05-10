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

            Debug.LogWarning(logText);
            if (Commander.Instance.GetComponent<Logs>() != null) Logs.Instance.LogWarn(logText);

            return true;
        }
    }
}