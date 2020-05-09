using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Log Warning Command", menuName = "Expresso Bits/Console/Log Warning Command")]
    public class LogWarningCommand : ConsoleCommand
    {

        private void Awake()
        {
            commandWord = "warning";
        }

        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);

            if (logText.Length <= 0) return false;

            Debug.LogWarning(logText);
            if (Commander.Instance.GetComponent<Logs>() != null) Logs.Instance.LogWarning(logText);

            return true;
        }
    }
}