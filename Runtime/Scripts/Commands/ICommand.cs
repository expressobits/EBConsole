namespace ExpressoBits.Console.Commands
{

    public delegate bool MethodDelegate(string[] args);

    public interface ICommand
    {
        // Command word 
        string CommandWord { get; }

        string Description { get; }

        MethodDelegate Method { get; }

        int Tag { get; }

        // Process command and return true if success
        bool Process(string[] args);
    }

}

