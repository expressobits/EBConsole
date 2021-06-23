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
                string.Format(ColorText("{0}",color)+" RAM",SystemInfo.systemMemorySize));

            _infoVram = new Info(
                string.Format(ColorText("{0}",Color.green)+" VRAM",SystemInfo.graphicsMemorySize));

            infos.Add(_infoMemory);
            infos.Add(_infoVram);

            Stater = GetComponentInParent<Stater>();
        }
        
    }
}

