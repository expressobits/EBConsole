using System.Collections.Generic;
using ExpressoBits.Console.Commands;
using System.Linq;
using System;

namespace ExpressoBits.Console
{
    public class DeveloperConsole
    {
        private readonly string m_Prefix;
        public List<ICommand> m_Commands;

        private readonly ICommand m_CommandWithoutPrefix;

        public DeveloperConsole(string prefix, List<ICommand> commands, ICommand commandWithoutPrefix)
        {
            this.m_Prefix = prefix;
            this.m_Commands = commands;
            this.m_CommandWithoutPrefix = commandWithoutPrefix;
        }

        public bool ProcessCommand(string inputValue)
        {
            if (!inputValue.StartsWith(m_Prefix))
            {
                if (m_CommandWithoutPrefix == null)
                {
                    return false;
                }
                else
                {
                    return ProcessCommand(m_CommandWithoutPrefix.CommandWord, inputValue.Split(' '));
                }

            }
            else
            {
                inputValue = inputValue.Remove(0, m_Prefix.Length);
                string[] inputSplit = inputValue.Split(' ');
                string commandInput = inputSplit[0];
                string[] args = inputSplit.Skip(1).ToArray();
                return ProcessCommand(commandInput, args);
            }



        }


        public bool ProcessCommand(string commandInput, string[] args)
        {
            foreach (var command in m_Commands)
            {
                if (!commandInput.Equals(command.CommandWord, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                if (command.Process(args))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }

}

