using UnityEngine;

namespace ExpressoBits.Console.Stats
{
    public class SystemStat : StatBehaviour
    {
        
        public Sprite graphicIcon;

        private Info _graphicsDeviceName;
        private Info _operatingSystem;
        private Info _processorType;

        private void Awake()
        {
            _graphicsDeviceName = new Info(
                string.Format(ColorText("{0}",color),SystemInfo.graphicsDeviceName),
                new LogAttribute(graphicIcon,Color.white));

            _operatingSystem = new Info(
                string.Format(ColorText("{0}",color),SystemInfo.operatingSystem),
                new LogAttribute(graphicIcon,Color.white));

            _processorType = new Info(
                string.Format(ColorText("{0}",color),SystemInfo.processorType),
                new LogAttribute(graphicIcon,Color.white));


            infos.Add(_graphicsDeviceName);
            infos.Add(_operatingSystem);
            infos.Add(_processorType);

            Stater = GetComponentInParent<Stater>();
          
        }
        
        
    }
}

