using ExpressoBits.Console.Utils;
using UnityEngine;

namespace ExpressoBits.Console
{
    [AddComponentMenu(menuName: "Console/Consoler")]
    public class Consoler : Singleton<Consoler>
    {
        
        private Commander m_Commander;
        private Logs m_Logs;

        public static Commander Commander
        {
            get
            {
                if (!Instance) return null;
                if (!Instance.m_Commander) Instance.m_Commander = Instance.GetComponent<Commander>();
                return Instance.m_Commander;
            }
        }
        
        public static Logs Logs
        {
            get
            {
                if (!Instance) return null;
                if (!Instance.m_Logs) Instance.m_Logs = Instance.GetComponent<Logs>();
                return Instance.m_Logs;
            }
        }


        private void Awake()
        {
            m_Commander = GetComponent<Commander>();
            m_Logs = GetComponent<Logs>();
        }

    }
}