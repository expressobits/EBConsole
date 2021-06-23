using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExpressoBits.Console
{
    [AddComponentMenu(menuName:"Console/Logs")]
    [RequireComponent(typeof(Consoler))]
    public class Logs : MonoBehaviour
    {

        public Queue<Info> infos = new Queue<Info>();
        public float defaultTimer = 8f;
        
        [Range(0,2048)]
        public int maxLogCount = 128;
        
        [SerializeField] private bool isLogUnityMessages;
        [SerializeField] private bool isLogUnityStackTraces;

        public Action<Info> onLog;
        public Action<Info> onDequeue;
        public Action OnClearLog;
        

        private void Start()
        {
            if(isLogUnityMessages) Application.logMessageReceived += ApplicationOnlogMessageReceived;
        }

        private void OnDestroy()
        {
            if(isLogUnityMessages) Application.logMessageReceived -= ApplicationOnlogMessageReceived;
        }

        private void ApplicationOnlogMessageReceived(string message, string stacktrace, LogType type)
        {
            switch (type)
            {
                case LogType.Assert:
                    LogHelp(message);
                    break;
                case LogType.Exception:
                case LogType.Error:
                    LogError(message);
                    if(isLogUnityStackTraces && stacktrace.Length > 0) LogError(stacktrace);
                    break;
                case LogType.Warning:
                    LogWarn(message);
                    break;
                default:
                    Log(message);
                    break;
            }
        }

        public void Log(Info info, float timer)
        {
            if (!Consoler.Instance.Commander) return;
            infos.Enqueue(info);
            onLog?.Invoke(info);
            if (infos.Count <= maxLogCount) return;
            var e = infos.Dequeue();
            onDequeue?.Invoke(e);
        }
        
        public void Log(string logText,LogAttribute logAttribute, float timer)
        {
            var info = new Info(logText,logAttribute);
            Log(info, timer);
        }
        
        #region 
        public LogAttribute defaultLogAttribute;
        public LogAttribute warnLogAttribute;
        public LogAttribute errorLogAttribute;
        public LogAttribute helpLogAttribute;
        public LogAttribute successLogAttribute;
        #endregion
        
        
        
        public void Log(string logText, Sprite sprite, Color color)
        {
            Log(logText, new LogAttribute(sprite,color), defaultTimer);
        }
        
        public void Log(string logText,LogAttribute logAttribute)
        {
            Log(logText, logAttribute, defaultTimer);
        }

        #region Utils
        
        public void Log(string logText)
        {
            Log(logText, defaultTimer);
        }
        
        public void Log(string logText, float timer)
        {
            Log(logText,defaultLogAttribute, timer);
        }
        
        public void LogWarn(string logText, float timer)
        {
            Log(logText,warnLogAttribute, timer);
        }
        
        public void LogError(string logText, float timer)
        {
            Log(logText,errorLogAttribute, timer);
        }
        
        public void LogHelp(string logText, float timer)
        {
            Log(logText,helpLogAttribute, timer);
        }
        
        public void LogSuccess(string logText, float timer)
        {
            Log(logText,successLogAttribute, timer);
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

        /**
         * Clear the history logs
         */
        public void Clear()
        {
            for (var i = infos.Count - 1; i >= 0; i--)
            {
                var e = infos.Dequeue();
                onDequeue?.Invoke(e);
            }
            OnClearLog?.Invoke();
        }
        #endregion

    }



}

