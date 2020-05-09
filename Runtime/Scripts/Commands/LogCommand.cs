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
            if (Commander.Instance.GetComponent<Logs>() != null) Logs.Instance.Log(logText);

            return true;
        }
    }
}