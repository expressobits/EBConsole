using UnityEngine;
using UnityEngine.UI;

namespace ExpressoBits.Console.UI
{
    public class LogMessage : MonoBehaviour
    {
        public Text text;
        public Image image;

        public Image background;

        private string m_LogText;

        public void Setup(string logText, Font font, float timer, Sprite sprite, Color color)
        {
            Setup(logText, font, sprite, color);
            Destroy(gameObject, timer);
        }

        public void Setup(string logText, Font font, Sprite sprite, Color color)
        {
            this.m_LogText = logText;
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
            text.text = m_LogText;
        }


    }
}

