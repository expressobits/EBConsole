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
            if(Consoler.Instance.Logs != null)
                Consoler.Instance.Logs.Log("Testing log in runtime!",10f,spriteTest,Color.magenta);
        }

    }
}

