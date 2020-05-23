using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.Console.UI;

namespace ExpressoBits.Console
{
    [AddComponentMenu(menuName:"Console/Logs")]
    [RequireComponent(typeof(Consoler))]
    public class Logs : MonoBehaviour
    {
        public Queue<InfoMessage> messages = new Queue<InfoMessage>();

        public float defaultTimer = 8f;
        
        [Range(0,2048)]
        public int maxLogCount = 128;

        public void Log(Info info, float timer)
        {
            var logMessage = Consoler.Instance.visualConsoler.InstantiateLogsAndReturnToastLog(info, timer);
            if (!Consoler.Instance.Commander) return;
            messages.Enqueue(logMessage);
            if (messages.Count <= maxLogCount) return;
            var e = messages.Dequeue();
            Destroy(e.gameObject);

        }

        // REVIEW - Problem with garbage, info and logattribute recreates
        // Solution - Use pools
        
        public void Log(string logText, float timer, LogAttribute logAttribute)
        {
            Info info = new Info(logText,logAttribute);
            Log(info, timer);
        }

        public void Log(string logText, float timer, Sprite icon, Color backgroundColor)
        {
            LogAttribute logAttribute = new LogAttribute(icon, backgroundColor);
            Log(logText, timer, logAttribute);
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
            Log(logText, timer, Consoler.Instance.visualConsoler.theme.defaultLogAttribute);
        }

        public void LogWarn(string logText, float timer)
        {
            Log(logText, timer, Consoler.Instance.visualConsoler.theme.warnLogAttribute);
        }

        public void LogError(string logText, float timer)
        {
            Log(logText, timer,Consoler.Instance.visualConsoler.theme.errorLogAttribute );
        }

        public void LogHelp(string logText, float timer)
        {
            Log(logText, timer,Consoler.Instance.visualConsoler.theme.helpLogAttribute);
        }

        public void LogSuccess(string logText, float timer)
        {
            Log(logText, timer, Consoler.Instance.visualConsoler.theme.successLogAttribute);
        }

        /**
         * Clear the history logs
         */
        public void Clear()
        {
            for (var i = messages.Count - 1; i >= 0; i--)
            {
                var e = messages.Dequeue();
                Destroy(e.gameObject);
            }
        }
        #endregion

    }



}

