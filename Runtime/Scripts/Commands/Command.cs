using UnityEngine.Events;

namespace ExpressoBits.Console.Commands
{
    public class Command : ICommand
    {
        private readonly string m_CommandWord;
        private readonly string m_Description;
        private readonly MethodDelegate m_Method;
        private int m_Tag;

        public string CommandWord => m_CommandWord;
        public string Description => m_Description;
        public MethodDelegate Method => m_Method;
        public int Tag => m_Tag;

        public Command(string commandWord, MethodDelegate action, int tag = 0)
        {
            this.m_CommandWord = commandWord;
            this.m_Method = action;
            this.m_Tag = tag;
        }

        public Command(string commandWord, string description, MethodDelegate action, int tag = 0)
        {
            this.m_CommandWord = commandWord;
            this.m_Description = description;
            this.m_Method = action;
            this.m_Tag = tag;
        }

        public bool Process(string[] args)
        {
            m_Method.Invoke(args);
            return true;
        }
    }
}
