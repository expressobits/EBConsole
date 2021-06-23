using UnityEngine;

namespace ExpressoBits.Console
{
    [System.Serializable]
    public struct Info
    {
        public string content;
        public bool isUpdate;
        private float timer;

        public Info(string content)
        {
            this.content = content;
            this.isUpdate = false;
            this.timer = Time.realtimeSinceStartup;
        }

        
    }
}

