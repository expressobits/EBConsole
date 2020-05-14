using ExpressoBits.Console;
using UnityEngine;

public class AddNewCommandTest : MonoBehaviour
{
    public Sprite spriteTest;
    
    // Start is called before the first frame update
    private void Start()
    {
        Commander.Instance.AddCommand("test", delegate { Command("Testing add command in runtime! "); });
    }

    public void Command(string test)
    {
        Logs.Instance.Log(test,10f,spriteTest,Color.cyan);
    }
}
