using UnityEngine;

namespace ExpressoBits.Console.Stats
{
    public class MemoryStat : StatBehaviour
    {
        
        public Sprite ramIcon;
        public Sprite vRamIcon;

        private Info _infoMemory;
        private Info _infoVram;

        private void Awake()
        {
            _infoMemory = new Info(
                string.Format(ColorText("{0}",color)+" RAM",SystemInfo.systemMemorySize),
                new LogAttribute(ramIcon,new Color(0f,0f,0f,0f)));

            _infoVram = new Info(
                string.Format(ColorText("{0}",Color.green)+" VRAM",SystemInfo.graphicsMemorySize),
                new LogAttribute(vRamIcon,new Color(0f,0f,0f,0f)));

            infos.Add(_infoMemory);
            infos.Add(_infoVram);

            Stater = GetComponentInParent<Stater>();
        }
        
    }
}

