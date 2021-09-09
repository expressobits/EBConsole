using System.Collections.Generic;
using ExpressoBits.Console.Commands;


namespace ExpressoBits.Console.Stats{

    public class StatCommand : ICommand
    {
        public string CommandWord => "stat";

        public string Description => "stat command";

        public MethodDelegate Method => Process;

        public int Tag => 0;

        private readonly Dictionary<string,StatBehaviour> m_InfoArgDictionary = new Dictionary<string, StatBehaviour>();

        public bool Process(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                {
                    foreach(var info in m_InfoArgDictionary.Keys)
                    {
                        Consoler.Logs.Log("->"+info);
                    }
                    Consoler.Logs.Log("Valid stat arguments:");
                    break;
                }
                case 1:
                {
                    if (m_InfoArgDictionary.TryGetValue(args[0], out var statBehaviour))
                    {
                        statBehaviour.Toggle();
                        return true;
                    }
                    else
                    {
                        Consoler.Logs.Log("Invalid stat argument:\""+args[0]+"\"");
                    }
                    break;
                }
                default:
                    Consoler.Logs.LogWarn("Stat command accepts only one argument!");
                    break;
            }

            return false;
        }

        public void Add(string command,StatBehaviour statBehaviour)
        {
            m_InfoArgDictionary.Add(command,statBehaviour);
        }

        bool ICommand.Process(string[] args)
        {
            throw new System.NotImplementedException();
        }
    }

}

