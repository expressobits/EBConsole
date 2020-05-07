using UnityEngine;
using UnityEngine.UI;

namespace ExpressoBits.Console.Logs
{
    public class LogMessage : MonoBehaviour
    {
        private Text text;

        private string logText;
        private float timer = 2f;

        public void Setup(string logText, float timer)
        {
            this.logText = logText;
            this.timer = timer;
            Destroy(gameObject, timer);
        }

        public void Setup(string logText)
        {
            this.logText = logText;
        }

        private void Awake()
        {
            text = GetComponentInChildren<Text>();
        }

        private void Start()
        {
            text.text = logText;
        }



    }
}

