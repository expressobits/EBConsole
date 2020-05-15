using System;
using ExpressoBits.Console.UI;
using ExpressoBits.Console.Utils;

namespace ExpressoBits.Console
{
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
    }
}