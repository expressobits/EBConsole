using UnityEngine;
using UnityEngine.UI;

namespace ExpressoBits.Console.UI
{
    public class InfoMessage : MonoBehaviour
    {
        public Text text;
        public Image image;
        public Image background;

        public Info _info;

        public void Setup(Info info,Font font)
        {
            this._info = info;
            text.font = font;
        }

        public void Setup(Info info,float timer,Font font)
        {
            Setup(info,font);
            Destroy(gameObject, timer);
        }

        private void Start()
        {
            // image.sprite = _info.logAttribute.icon;
            // background.color = _info.logAttribute.backgroundColor;
            UpdateContent();
        }

        public void UpdateContent()
        {
            text.text = _info.content;
        }

        private void Update()
        {
            if(_info.isUpdate)
            {
                UpdateContent();
            }
        }

    }
}

