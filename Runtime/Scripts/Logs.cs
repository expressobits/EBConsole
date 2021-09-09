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
        [SerializeField] private float defaultTimer = 8f;
        [Range(0,2048)]
        [SerializeField] private int maxLogCount = 128;
        [SerializeField] private bool isLogUnityMessages;
        [SerializeField] private bool isLogWarnUnityMessages;
        [SerializeField] private bool isLogErrorUnityMessages;
        [SerializeField] private bool isLogUnityStackTraces;
        [SerializeField] private bool isLogAssertUnityMessages;

        #region Actions
        public Action<Info> OnLog;
        public Action<Info> OnDequeue;
        public Action OnClearLog;
        #endregion
        
        private void Start()
        {
            Application.logMessageReceived += ApplicationOnlogMessageReceived;
        }

        private void OnDestroy()
        {
            Application.logMessageReceived -= ApplicationOnlogMessageReceived;
        }

        private void ApplicationOnlogMessageReceived(string message, string stacktrace, LogType type)
        {
            switch (type)
            {
                case LogType.Assert:
                    if(isLogAssertUnityMessages) LogHelp(message);
                    break;
                case LogType.Exception:
                case LogType.Error:
                    if(isLogErrorUnityMessages) LogError(message);
                    if(isLogUnityStackTraces && stacktrace.Length > 0) LogError(stacktrace);
                    break;
                case LogType.Warning:
                    if(isLogWarnUnityMessages) LogWarn(message);
                    break;
                case LogType.Log:
                    if(isLogUnityMessages) Log(message);
                    break;
                default:
                    if(isLogUnityMessages) Log(message);
                    break;
            }
        }

        public void Log(Info info, float timer)
        {
            if (!Consoler.Commander) return;
            infos.Enqueue(info);
            OnLog?.Invoke(info);
            if (infos.Count <= maxLogCount) return;
            var e = infos.Dequeue();
            OnDequeue?.Invoke(e);
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
                OnDequeue?.Invoke(e);
            }
            OnClearLog?.Invoke();
        }
        #endregion

    }



}

