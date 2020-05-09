using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Gravity Command", menuName = "Expresso Bits/Console/Gravity Command")]
    public class GravityCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {

            if (args.Length == 3)
            {
                if (!float.TryParse(args[0], out float x))
                {
                    return false;
                }
                if (!float.TryParse(args[1], out float y))
                {
                    return false;
                }
                if (!float.TryParse(args[2], out float z))
                {
                    return false;
                }
                Physics.gravity = new Vector3(x, y, z);
                if (Commander.Instance.GetComponent<Logs>() != null)
                    Logs.Instance.Log("Update gravity to <color=yellow>" + Physics.gravity + "</color>");
                return true;
            }

            if (args.Length == 1)
            {
                if (!float.TryParse(args[0], out float value))
                {
                    return false;
                }
                Physics.gravity = new Vector3(Physics.gravity.x, value, Physics.gravity.z);
                if (Commander.Instance.GetComponent<Logs>() != null)
                    Logs.Instance.Log("Update gravity to <color=yellow>" + Physics.gravity + "</color>");
                return true;
            }



            // Debug.LogWarning(logText);
            // 
            if (Commander.Instance.GetComponent<Logs>() != null)
                Logs.Instance.LogWarning("Gravity command need 3 or 1 argument number!");
            return false;
        }
    }
}