using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.Console.Commands;
using System.Linq;
using System;

namespace ExpressoBits.Console
{
    public class DeveloperConsole
    {
        private readonly string prefix;
        private readonly IEnumerable<IConsoleCommand> commands;

        private readonly IConsoleCommand commandWithoutPrefix;

        public DeveloperConsole(string prefix, IEnumerable<IConsoleCommand> commands, IConsoleCommand commandWithoutPrefix)
        {
            this.prefix = prefix;
            this.commands = commands;
            this.commandWithoutPrefix = commandWithoutPrefix;
        }

        public bool ProcessCommand(string inputValue)
        {
            if (!inputValue.StartsWith(prefix))
            {
                if (commandWithoutPrefix == null)
                {
                    return false;
                }
                else
                {
                    return ProcessCommand(commandWithoutPrefix.CommandWord, inputValue.Split(' '));
                }

            }
            else
            {
                inputValue = inputValue.Remove(0, prefix.Length);
                string[] inputSplit = inputValue.Split(' ');
                string commandInput = inputSplit[0];
                string[] args = inputSplit.Skip(1).ToArray();
                return ProcessCommand(commandInput, args);
            }



        }


        public bool ProcessCommand(string commandInput, string[] args)
        {
            foreach (var command in commands)
            {
                if (!commandInput.Equals(command.CommandWord, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                if (command.Process(args))
                {
                    return true;
                }
            }

            return false;
        }
    }

}

