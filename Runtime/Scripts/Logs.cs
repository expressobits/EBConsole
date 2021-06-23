using System;
using System.Collections.Generic;
using UnityEngine;

namespace ExpressoBits.Console
{
    [AddComponentMenu(menuName:"Console/Logs")]
    [RequireComponent(typeof(Consoler))]
    public class Logs : MonoBehaviour
    {

        public enum LoggerType
        {
            Error,
            /// <summary>
            ///   <para>LogType used for Warnings.</para>
            /// </summary>
            Warning,
            /// <summary>
            ///   <para>LogType used for regular log messages.</para>
            /// </summary>
            Log,
            /// <summary>
            ///   <para>LogType used for Exceptions.</para>
            /// </summary>
            Exception,
            /// <summary>
            ///   <para>LogType used for Success.</para>
            /// </summary>
            Success,
            /// <summary>
            ///   <para>LogType used for Info.</para>
            /// </summary>
            Info,
        }

        public Queue<Info> infos = new Queue<Info>();
        public float defaultTimer = 8f;
        
        [Range(0,2048)]
        public int maxLogCount = 128;
        
        [SerializeField] private bool isLogUnityMessages;

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

        private void ApplicationOnlogMessageReceived(string condition, string stacktrace, LogType type)
        {
            Log(condition);
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
        
        public void Log(string logText, float timer)
        {
            var info = new Info(logText);
            Log(info, timer);
        }
        
        public void Log(string logText)
        {
            Log(logText, defaultTimer);
        }

        #region Utils
        public void LogWarn(string logText, float timer)
        {
            Log(logText, timer);
        }
        
        public void LogError(string logText, float timer)
        {
            Log(logText, timer);
        }
        
        public void LogHelp(string logText, float timer)
        {
            Log(logText, timer);
        }
        
        public void LogSuccess(string logText, float timer)
        {
            Log(logText, timer);
        }
        
        public void LogWarn(string logText)
        {
            Log(logText, defaultTimer);
        }
        
        public void LogError(string logText)
        {
            Log(logText, defaultTimer);
        }
        
        public void LogHelp(string logText)
        {
            Log(logText, defaultTimer);
        }
        
        public void LogSuccess(string logText)
        {
            Log(logText, defaultTimer);
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

