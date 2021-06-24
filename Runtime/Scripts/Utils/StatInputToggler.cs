using System.Collections.Generic;
using ExpressoBits.Console.Stats;
using UnityEngine;

namespace ExpressoBits.Console.Utils
{
    public class StatInputToggler : MonoBehaviour
    {
        [System.Serializable]
        public struct InputStat
        {
            public KeyCode key;
            public StatBehaviour stat;
        }

        public List<InputStat> inputsStats = new List<InputStat>();

        private void Update()
        {
            foreach (var input in inputsStats)
            {
                if (Input.GetKeyDown(input.key))
                {
                    input.stat.Toggle();
                }
            }
        }
    }
}