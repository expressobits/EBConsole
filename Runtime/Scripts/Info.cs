using UnityEngine;

namespace ExpressoBits.Console
{
    [System.Serializable]
    public struct Info
    {
        public string content;
        public bool isUpdate;
        public LogAttribute logAttribute;
        private float timer;

        public Info(string content,LogAttribute logAttribute)
        {
            this.content = content;
            this.isUpdate = false;
            this.logAttribute = logAttribute;
            this.timer = Time.realtimeSinceStartup;
        }

        
    }
}

