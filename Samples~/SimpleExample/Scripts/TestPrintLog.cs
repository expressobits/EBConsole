using ExpressoBits.Console;
using UnityEngine;

namespace ExpressoBits.Console
{
    public class TestPrintLog : MonoBehaviour
    {
        public Sprite spriteTest;

        // Start is called before the first frame update
        private void Start()
        {
            if (Consoler.Logs != null)
                Consoler.Logs.Log("Testing log in runtime!", spriteTest, Color.magenta);
        }

    }
}

