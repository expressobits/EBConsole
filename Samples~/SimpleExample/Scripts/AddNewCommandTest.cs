using UnityEngine;
using ExpressoBits.Console.Commands;

namespace ExpressoBits.Console
{
    public class AddNewCommandTest : MonoBehaviour
    {
        public Sprite spriteTest;

        // Start is called before the first frame update
        private void Start()
        {
            if (Consoler.Commander != null)
            {
                Consoler.Commander.AddCommand(new TestCommand(spriteTest));
            }    
        }
    }

    public struct TestCommand : ICommand
    {
        public string CommandWord => "test";

        public string Description => "Testing add command in runtime";

        public MethodDelegate Method => Process;

        public int Tag => 0;

        private Sprite spriteTest;

        public TestCommand(Sprite sprite)
        {
            this.spriteTest = sprite;
        }

        public bool Process(string[] args)
        {
            if (Consoler.Commander != null)
            {
                Consoler.Logs.Log("Testing add command in runtime", spriteTest, Color.cyan);
                return true;
            }  
            return false;
        }
    }
}
