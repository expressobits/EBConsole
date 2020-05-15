using ExpressoBits.Console.UI;
using ExpressoBits.Console.Utils;
using UnityEngine;

namespace ExpressoBits.Console
{
    [AddComponentMenu(menuName: "Console/Consoler")]
    public class Consoler : Singleton<Consoler>
    {
        private Commander m_Commander;
        private Logs m_Logs;
        
        [HideInInspector]
        public VisualConsoler visualConsoler;

        public Commander Commander
        {
            get
            {
                if (!m_Commander) m_Commander = GetComponent<Commander>();
                return m_Commander;
            }
        }
        
        public Logs Logs
        {
            get
            {
                if (!m_Logs) m_Logs = GetComponent<Logs>();
                return m_Logs;
            }
        }


        private void Awake()
        {
            m_Commander = GetComponent<Commander>();
            m_Logs = GetComponent<Logs>();
            
        }

        private void Start()
        {
            if (!visualConsoler)
            {
                Debug.LogError("An object with a visual consoler is missing in the scene!");
            }
        }
    }
}