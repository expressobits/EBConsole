namespace ExpressoBits.Console.Commands
{
    public interface ICommand
    {
        // Command word 
        string CommandWord { get; }

        // Process command and return true if success
        bool Process(string[] args);
    }

}

