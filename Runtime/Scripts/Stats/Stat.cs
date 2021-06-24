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

        protected static string ColorText(string text, Color color) {
            return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + text + "</color>";
        }

        private void Start()
        {
            foreach(var info in infos)
            {
                Stater.AddStat(info,startShow);
            }
            Stater.statCommand.Add(argumentName,this);
        }

        public void Toggle()
        {
            isShow = !isShow;
            foreach(var info in infos)
            {
                if (isShow)
                {
                    Stater.EnableInfo(info);
                }
                else
                {
                    Stater.DisableInfo(info);
                }
            }
            
        }

    }
}

