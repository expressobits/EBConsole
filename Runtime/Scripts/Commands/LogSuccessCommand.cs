using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Log Success Command", menuName = "Expresso Bits/Console/Log Success Command")]
    public class LogSuccessCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);

            if (logText.Length <= 0) return false;

            Debug.LogWarning(logText);
            if (Commander.Instance.GetComponent<Logs>() != null) Logs.Instance.LogSuccess(logText);

            return true;
        }
    }
}