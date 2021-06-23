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

        public Action<Info> OnAddStat;
        public Action<Info> OnRemoveStat;
        
        private void Awake()
        {
            statCommand = new StatCommand();
            Consoler.Instance.Commander.AddCommand(statCommand);
        }


        public void AddStat(Info info)
        {
            if (m_Infos.Contains(info))
            {
                //visualStats.Update(info);
            }
            else
            {
                m_Infos.Add(info);
                OnAddStat?.Invoke(info);
            }

        }

        public void RemoveStat(Info info)
        {
            if (!m_Infos.Contains(info)) return;
            OnRemoveStat?.Invoke(info);
            m_Infos.Remove(info);

        }


    }
}