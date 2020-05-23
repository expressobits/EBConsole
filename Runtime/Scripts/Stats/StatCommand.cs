using System.Collections.Generic;
using ExpressoBits.Console.Commands;


namespace ExpressoBits.Console.Stats{

    public class StatCommand : ICommand
    {
        public string CommandWord => "stat";

        public Dictionary<string,StatBehaviour> infoArgDictionary = new Dictionary<string, StatBehaviour>();
        public List<string> infos = new List<string>();

        public Stater stater;

        public bool Process(string[] args)
        {
            if(args.Length == 0)
            {
                foreach(string info in infoArgDictionary.Keys)
                {
                    Consoler.Instance.Logs.Log("->"+info);
                }
                Consoler.Instance.Logs.Log("Valid stat arguments:");
                
            }
            else if(args.Length == 1)
            {
                if (infoArgDictionary.TryGetValue(args[0], out StatBehaviour statBehaviour))
                {
                    statBehaviour.Toggle();
                    return true;
                }
            }
            else
            {
                Consoler.Instance.Logs.LogWarn("Stat command accepts only one argument!");
            }
            return false;
            
        }

        public void Add(string command,StatBehaviour statBehaviour)
        {
            infoArgDictionary.Add(command,statBehaviour);
        }

        
    }

}

