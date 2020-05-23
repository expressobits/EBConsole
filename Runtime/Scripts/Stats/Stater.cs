using UnityEngine;
using ExpressoBits.Console.UI;
using System.Collections.Generic;
using ExpressoBits.Console.Commands;

namespace ExpressoBits.Console.Stats
{
    public class Stater : MonoBehaviour
    {
        public VisualStater visualStater;

        [HideInInspector]
        public StatCommand statCommand;

        private readonly List<Info> m_infos = new List<Info>();

        
        private void Awake()
        {
            statCommand = new StatCommand();
            Consoler.Instance.Commander.AddCommand(statCommand);
        }


        public void AddStat(Info info)
        {
            if (m_infos.Contains(info))
            {
                //visualStats.Update(info);
            }
            else
            {
                m_infos.Add(info);
                visualStater.AddInfo(info);
            }

        }

        public void RemoveStat(Info info)
        {
            if (m_infos.Contains(info))
            {
                visualStater.RemoveInfo(info);
                m_infos.Remove(info);
            }

        }


    }
}