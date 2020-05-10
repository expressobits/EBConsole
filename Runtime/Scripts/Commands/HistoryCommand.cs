using ExpressoBits.Console;
using ExpressoBits.Console.Commands;
using UnityEngine;

namespace Runtime.Scripts.Commands
{
    [CreateAssetMenu(fileName = "History Command", menuName = "Expresso Bits/Console/History Command")]
    public class HistoryCommand : ConsoleCommand
    {
        private void Awake()
        {
            commandWord = "history";
        }
        
        public override bool Process(string[] args)
        {
            var history = Commander.Instance.GetComponent<History>();
            var logs = Commander.Instance.GetComponent<Logs>();
            if (!history || !logs) return false;
            if (history.history.Count <= 0) return false;
            
            logs.Log("████████████████████████████████████████████████████");
            foreach (var command in history.history)
            {
                logs.Log("█ "+command);
            }

            var text = $"█████ HISTORY COMMANDS ███ TOTAL: {history.history.Count:  0} ██████████";
            logs.Log(text);
            return true;

        }
    }
}