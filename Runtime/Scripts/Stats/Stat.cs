using System.Collections.Generic;
using UnityEngine;


namespace ExpressoBits.Console.Stats
{
    public class StatBehaviour : MonoBehaviour
    {
        public bool startShow = false;
        public Color color;
        protected bool isShow;

        public string argumentName;

        public Stater Stater { get; set; }

        protected List<Info> infos = new List<Info>();

        static public string ColorText(string text, Color color) {
            return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + text + "</color>";
        }

        private void Start()
        {
            
            isShow = startShow;

            if(isShow)
            {
                foreach(Info info in infos)
                {
                    Stater.AddStat(info);
                }
            }
        
            Stater.statCommand.Add(argumentName,this);
        }

        public void Toggle()
        {
            isShow = !isShow;
            if(isShow){
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

