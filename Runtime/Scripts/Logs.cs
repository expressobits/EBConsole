using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.Console.UI;
using ExpressoBits.Console.Utils;

namespace ExpressoBits.Console
{
    [AddComponentMenu(menuName:"Console/Logs")]
    [RequireComponent(typeof(Commander))]
    public class Logs : Singleton<Logs>
    {
        

        public Queue<LogMessage> messages = new Queue<LogMessage>();

        public float defaultTimer = 8f;
        
        [Header("Log Attributes")]
        public LogAttribute defaultLogAttribute;
        public LogAttribute warnLogAttribute;
        public LogAttribute errorLogAttribute;
        public LogAttribute helpLogAttribute;
        public LogAttribute successLogAttribute;

        private VisualConsole m_VisualConsole;
        [Range(0,2048)]
        public int maxLogCount = 128;


        private void Awake()
        {
            m_VisualConsole = GetComponentInChildren<VisualConsole>();
        }
        
        public void Log(string logText, float timer, Sprite sprite, Color color)
        {
            var logMessage = m_VisualConsole.InstantiateLogsAndReturnToastLog(logText, timer, sprite, color);
            messages.Enqueue(logMessage);
            if (messages.Count <= maxLogCount) return;
            var e = messages.Dequeue();
            Destroy(e.gameObject);
        }
        
        public void Log(string logText, float timer, LogAttribute logAttribute)
        {
            Log(logText, timer, logAttribute.icon, logAttribute.backgroundColor);
        }


        #region Utils
        public void Log(string logText)
        {
            Log(logText, defaultTimer);
        }

        public void LogWarn(string logText)
        {
            LogWarn(logText, defaultTimer);
        }

        public void LogError(string logText)
        {
            LogError(logText, defaultTimer);
        }

        public void LogHelp(string logText)
        {
            LogHelp(logText, defaultTimer);
        }

        public void LogSuccess(string logText)
        {
            LogSuccess(logText, defaultTimer);
        }

        public void Log(string logText, float timer)
        {
            Log(logText, timer, defaultLogAttribute);
        }

        public void LogWarn(string logText, float timer)
        {
            Log(logText, timer, warnLogAttribute);
        }

        public void LogError(string logText, float timer)
        {
            Log(logText, timer,errorLogAttribute );
        }

        public void LogHelp(string logText, float timer)
        {
            Log(logText, timer,helpLogAttribute);
        }

        public void LogSuccess(string logText, float timer)
        {
            Log(logText, timer, successLogAttribute);
        }

        /**
         * Clear the history logs
         */
        public void Clear()
        {
            for (int i = messages.Count - 1; i >= 0; i--)
            {
                LogMessage e = messages.Dequeue();
                Destroy(e.gameObject);
            }
        }
        #endregion

    }



}

