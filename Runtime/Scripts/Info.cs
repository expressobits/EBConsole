using UnityEngine;

namespace ExpressoBits.Console
{
    [System.Serializable]
    public class Info
    {
        public string content;
        public bool isUpdate;
        public LogAttribute logAttribute;
        private float m_Timer;

        public Info(string content,LogAttribute logAttribute)
        {
            this.content = content;
            this.isUpdate = false;
            this.logAttribute = logAttribute;
            this.m_Timer = Time.realtimeSinceStartup;
        }

        
    }
}

