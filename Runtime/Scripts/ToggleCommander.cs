using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpressoBits.Console
{
    [RequireComponent(typeof(Commander))]
    public class ToggleCommander : MonoBehaviour
    {

        public KeyCode openKey;

        private Commander commander;

        private void Awake()
        {
            commander = GetComponent<Commander>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(openKey))
            {
                commander.Toogle();
            }
        }



    }

}

