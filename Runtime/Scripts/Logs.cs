using System.Collections.Generic;
using UnityEngine;
using ExpressoBits.Console.UI;
using ExpressoBits.Console.Utils;
using UnityEngine.Serialization;

namespace ExpressoBits.Console
{
    [RequireComponent(typeof(Commander))]
    public class Logs : Singleton<Logs>
    {
        [Header("Prefabs")]
        public LogPanel messagePanel;
        public LogMessage uiLogPrefab;

        public Queue<LogMessage> messages = new Queue<LogMessage>();

        public float defaultTimer = 8f;
        
        [Header("Log Attributes")]
        public LogAttribute defaultLogAttribute;
        public LogAttribute warnLogAttribute;
        public LogAttribute errorLogAttribute;
        public LogAttribute helpLogAttribute;
        public LogAttribute successLogAttribute;
        
        private Commander m_Commander;
        private Canvas m_UiCanvas;
        private LogPanel m_LogPanel;

        private void Awake()
        {
            m_Commander = GetComponent<Commander>();
            m_UiCanvas = GetComponentInChildren<Canvas>();

            m_LogPanel = Instantiate(messagePanel, m_UiCanvas.gameObject.transform);
        }

        private void Start()
        {

            m_Commander.onOpenCommander.AddListener(OnOpenCommander);
            m_Commander.onCloseCommander.AddListener(OnCloseCommander);
            OnCloseCommander();
        }
        
        

        // TODO default value
        public void Log(string logText, float timer, Sprite sprite, Color color)
        {

            var log = Instantiate(uiLogPrefab, m_LogPanel.logToast.transform);
            log.transform.SetSiblingIndex(0);
            log.Setup(logText, m_Commander.font, timer, sprite, color);

            var logA = Instantiate(uiLogPrefab, m_LogPanel.logScroll.transform);
            logA.transform.SetSiblingIndex(0);
            logA.Setup(logText, m_Commander.font, sprite, color);

            messages.Enqueue(logA);
            if (messages.Count <= 32) return;
            var e = messages.Dequeue();
            Destroy(e.gameObject);
        }
        
        public void Log(string logText, float timer, LogAttribute logAttribute)
        {
            Log(logText, timer, logAttribute.icon, logAttribute.backgroundColor);
        }

        public void OnOpenCommander()
        {
            m_LogPanel.logPanelScroll.SetActive(true);
            m_LogPanel.logToast.SetActive(false);
        }

        public void OnCloseCommander()
        {
            m_LogPanel.logPanelScroll.SetActive(false);
            m_LogPanel.logToast.SetActive(true);
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

