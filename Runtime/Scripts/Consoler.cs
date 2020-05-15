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

        public VisualConsoler visualConsoler;

        public Commander Commander
        {
            get
            {
                return m_Commander;
            }
        }
        
        public Logs Logs
        {
            get
            {
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