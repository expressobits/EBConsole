using UnityEngine;

namespace ExpressoBits.Console.Commands
{
    public abstract class ConsoleCommand : ScriptableObject, ICommand
    {
        [SerializeField] protected string commandWord = string.Empty;
        [SerializeField] protected string description = string.Empty;
        [SerializeField] protected int tag = 0;

        public string CommandWord => commandWord;
        public string Description => description;
        public MethodDelegate Method => Process;
        public int Tag => tag;

        public abstract bool Process(string[] args);
    }
}

