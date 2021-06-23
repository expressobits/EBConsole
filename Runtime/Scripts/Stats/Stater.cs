using System;
using UnityEngine;
using System.Collections.Generic;
using ExpressoBits.Console.Commands;

namespace ExpressoBits.Console.Stats
{
    public class Stater : MonoBehaviour
    {

        [HideInInspector]
        public StatCommand statCommand;

        private readonly List<Info> m_Infos = new List<Info>();

        public Action<Info> onAddStat;
        public Action<Info> onRemoveStat;
        public Action<Info> onUpdateInfo;
        
        private void Awake()
        {
            statCommand = new StatCommand();
            Consoler.Commander.AddCommand(statCommand);
        }


        public void AddStat(Info info)
        {
            if (m_Infos.Contains(info))
            {
                onUpdateInfo?.Invoke(info);
            }
            else
            {
                m_Infos.Add(info);
                onAddStat?.Invoke(info);
            }

        }

        public void RemoveStat(Info info)
        {
            if (!m_Infos.Contains(info)) return;
            onRemoveStat?.Invoke(info);
            m_Infos.Remove(info);

        }


    }
}