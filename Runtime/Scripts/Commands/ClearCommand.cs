using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Clear Command", menuName = "Expresso Bits/Console/Clear Command")]
    public class ClearCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {

            if (Commander.Instance.GetComponent<Logs>() != null)
                Logs.Instance.Clear();
            return true;
        }
    }
}