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

        public void Setup(Info info)
        {
            this._info = info;
        }

        public void Setup(Info info,float timer)
        {
            Setup(info);
            Destroy(gameObject, timer);
        }

        private void Start()
        {
            text.font = Consoler.Instance.visualConsoler.font;
            image.sprite = _info.logAttribute.icon;
            background.color = _info.logAttribute.backgroundColor;
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

