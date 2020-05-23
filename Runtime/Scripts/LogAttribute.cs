using UnityEngine;

namespace ExpressoBits.Console
{
    [System.Serializable]
    public class LogAttribute
    {
        public Sprite icon;
        public Color backgroundColor;

        public LogAttribute(Sprite icon,Color backgroundColor)
        {
            this.icon = icon;
            this.backgroundColor = backgroundColor;
        }
    }
}