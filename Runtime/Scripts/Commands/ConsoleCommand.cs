using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    public abstract class ConsoleCommand : ScriptableObject, ICommand
    {
        [SerializeField] protected string commandWord = string.Empty;

        public string CommandWord => commandWord;

        public abstract bool Process(string[] args);
    }
}

