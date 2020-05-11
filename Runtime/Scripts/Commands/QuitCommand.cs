using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    [CreateAssetMenu(fileName = "Quit Command", menuName = "Expresso Bits/Console/Quit Command")]
    public class QuitCommand : ConsoleCommand
    {
        private void Awake()
        {
            commandWord = "quit";
        }

        public override bool Process(string[] args)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
            return true;
        }
    }

}

