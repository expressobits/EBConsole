using UnityEngine;
using UnityEngine.UI;

namespace ExpressoBits.Console.UI
{
    public class LogMessage : MonoBehaviour
    {
        public Text text;
        public Image image;

        public Image background;

        private string logText;
        private float timer = 2f;

        public void Setup(string logText, Font font, float timer, Sprite sprite, Color color)
        {
            Setup(logText, font, sprite, color);
            this.timer = timer;
            Destroy(gameObject, timer);
        }

        public void Setup(string logText, Font font, Sprite sprite, Color color)
        {
            this.logText = logText;
            text.font = font;
            image.sprite = sprite;
            color.a = background.color.a;
            background.color = color;

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

