using ExpressoBits.Console.Utils;
using UnityEngine;

namespace ExpressoBits.Console
{
    [AddComponentMenu(menuName: "Console/Consoler")]
    public class Consoler : Singleton<Consoler>
    {
        public static IVisualConsoler Visual => Instance.visual;

        public void SetVisual(IVisualConsoler newVisual)
        {
            visual = newVisual;
        }
        private IVisualConsoler visual;
        private Commander m_Commander;
        private Logs m_Logs;
        

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

    }
}