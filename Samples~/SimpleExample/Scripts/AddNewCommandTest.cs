using ExpressoBits.Console;
using UnityEngine;

namespace ExpressoBits.Console
{
    public class AddNewCommandTest : MonoBehaviour
    {
        public Sprite spriteTest;
    
        // Start is called before the first frame update
        private void Start()
        {
            if(Consoler.Instance.Commander != null)
                Consoler.Instance.Commander.AddCommand("test", delegate { Command("Testing add command in runtime! "); });
        }

        public void Command(string test)
        {
            if(Consoler.Instance.Commander != null)
                Consoler.Instance.Logs.Log(test,10f,spriteTest,Color.cyan);
        }
    }
}
