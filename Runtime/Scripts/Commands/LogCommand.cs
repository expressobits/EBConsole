using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Log Command", menuName = "Expresso Bits/Console/Log Command")]
    public class LogCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);

            if (logText.Length <= 0) return false;

            Debug.Log(logText);
            if (Commander.Instance.GetComponent<Logger>() != null) Logger.Instance.Log(logText);

            return true;
        }
    }
}