using UnityEngine.Events;

namespace ExpressoBits.Console.Commands
{
    public class Command : ICommand
    {
        private string m_CommandWord;
        private UnityAction m_Action;

        public string CommandWord => m_CommandWord;

        public Command(string commandWord, UnityAction action)
        {
            this.m_CommandWord = commandWord;
            this.m_Action = action;
        }

        public bool Process(string[] args)
        {
            m_Action.Invoke();
            return true;
        }
    }
}
