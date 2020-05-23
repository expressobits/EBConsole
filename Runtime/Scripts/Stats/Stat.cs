using System.Collections.Generic;
using UnityEngine;


namespace ExpressoBits.Console.Stats
{
    public class StatBehaviour : MonoBehaviour
    {
        public bool startShow = false;
        public Color color;
        protected bool m_isShow;

        public string ArgumentName;

        public Stater Stater { get; set; }

        protected List<Info> infos = new List<Info>();

        static public string ColorText(string text, Color color) {
            return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + text + "</color>";
        }

        private void Start()
        {
            
            m_isShow = startShow;

            if(m_isShow)
            {
                foreach(Info info in infos)
                {
                    Stater.AddStat(info);
                }
            }
        
            Stater.statCommand.Add(ArgumentName,this);
        }

        public void Toggle()
        {
            m_isShow = !m_isShow;
            if(m_isShow){
                foreach(Info info in infos)
                {
                    Stater.AddStat(info);
                }
            }
            else{
                foreach(Info info in infos)
                {
                    Stater.RemoveStat(info);
                }
            }
            
        }

    }
}

