using System;
using UnityEngine;
using System.Collections.Generic;

namespace ExpressoBits.Console.Stats
{
    public class Stater : MonoBehaviour
    {
        public StatCommand statCommand;

        public IEnumerable<Info> Infos => m_Infos;

        private readonly List<Info> m_Infos = new List<Info>();

        public Action<Info> onAddStat;
        public Action<Info> onRemoveStat;
        public Action<Info> onUpdateStat;
        public Action<Info> onEnableStat;
        public Action<Info> onDisableStat;
        
        private void Awake()
        {
            statCommand = new StatCommand();
            Consoler.Commander.AddCommand(statCommand);
        }


        public void AddStat(Info info)
        {
            if (m_Infos.Contains(info))
            {
                onUpdateStat?.Invoke(info);
            }
            else
            {
                m_Infos.Add(info);
                onAddStat?.Invoke(info);
                onDisableStat?.Invoke(info);
            }

        }

        public void EnableInfo(Info info)
        {
            onEnableStat?.Invoke(info);
        }

        public void DisableInfo(Info info)
        {
            onDisableStat?.Invoke(info);
        }

        public void RemoveStat(Info info)
        {
            if (!m_Infos.Contains(info)) return;
            onRemoveStat?.Invoke(info);
            m_Infos.Remove(info);

        }


    }
}