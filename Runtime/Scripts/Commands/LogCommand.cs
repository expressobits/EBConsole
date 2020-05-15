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
            string logText = string.Join(" ", args);

            if (logText.Length <= 0) return false;

            Debug.Log(logText);
            if (Consoler.Instance.Logs != null) Consoler.Instance.Logs.Log(logText);

            return true;
        }
    }
}