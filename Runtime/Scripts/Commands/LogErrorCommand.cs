using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Log Error Command", menuName = "Expresso Bits/Console/Log Error Command")]
    public class LogErrorCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);

            if (logText.Length <= 0) return false;

            Debug.LogError(logText);
            if (Commander.Instance.GetComponent<Logs>() != null) Logs.Instance.LogError(logText);

            return true;
        }
    }
}