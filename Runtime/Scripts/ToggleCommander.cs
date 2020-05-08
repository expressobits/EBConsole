using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpressoBits.Console
{
    [RequireComponent(typeof(Commander))]
    public class ToggleCommander : MonoBehaviour
    {

        public KeyCode openKey = KeyCode.Return;
        public KeyCode closeKey = KeyCode.Escape;

        private Commander commander;

        private void Awake()
        {
            commander = GetComponent<Commander>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(openKey))
            {
                commander.OpenCommander();
            }

            if (Input.GetKeyDown(closeKey))
            {
                commander.CloseCommander();
            }
        }



    }

}

