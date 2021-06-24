using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ExpressoBits.Console.UI
{
    public class InfoMessage : MonoBehaviour
    {
        public Text text;
        public Image image;
        public Image background;

        public Info info;

        public void Setup(Info info,Font font)
        {
            this.info = info;
            text.font = font;
        }

        public void Setup(Info info,float timer,Font font)
        {
            Setup(info,font);
            Destroy(gameObject, timer);
        }

        private void Start()
        {
            if (info.logAttribute.icon)
            {
                image.sprite = info.logAttribute.icon;
            }
            else
            {
                image.color = new Color(0f,0f,0f,0f);
            }
            background.color = info.logAttribute.backgroundColor;
            UpdateContent();
        }
        
        public void UpdateContent()
        {
            text.text = info.content;
        }

        private void Update()
        {
            if(info.isUpdate)
            {
                UpdateContent();
            }
        }

    }
}

