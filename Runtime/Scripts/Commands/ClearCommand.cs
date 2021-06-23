using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Clear Command", menuName = "Expresso Bits/Console/Clear Command")]
    public class ClearCommand : ConsoleCommand
    {

        private void Awake()
        {
            commandWord = "clear";
        }

        public override bool Process(string[] args)
        {

            if (Consoler.Logs != null)
                Consoler.Logs.Clear();
            return true;
        }
    }
}