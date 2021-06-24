using UnityEngine;

namespace ExpressoBits.Console.Stats
{
    public class MemoryStat : StatBehaviour
    {
        
        public Sprite ramIcon;
        public Sprite vRamIcon;

        private Info m_InfoMemory;
        private Info m_InfoVram;

        private void Awake()
        {
            m_InfoMemory = new Info(
                string.Format(ColorText("{0}",color)+" RAM",SystemInfo.systemMemorySize),
                new LogAttribute(ramIcon,new Color(0f,0f,0f,0f)));

            m_InfoVram = new Info(
                string.Format(ColorText("{0}",Color.green)+" VRAM",SystemInfo.graphicsMemorySize),
                new LogAttribute(vRamIcon,new Color(0f,0f,0f,0f)));

            infos.Add(m_InfoMemory);
            infos.Add(m_InfoVram);

            Stater = GetComponentInParent<Stater>();
        }
        
    }
}

