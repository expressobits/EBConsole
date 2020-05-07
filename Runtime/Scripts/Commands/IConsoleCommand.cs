using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    public interface IConsoleCommand
    {
        // Command word 
        string CommandWord { get; }
        // Process command and return true if success
        bool Process(string[] args);
    }

}

