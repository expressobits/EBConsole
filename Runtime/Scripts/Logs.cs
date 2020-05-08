using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExpressoBits.Console.UI;
using ExpressoBits.Console.Utils;

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

        [Header("Sprites")]
        public Sprite defaultLogSprite;
        public Color defaultColor;
        public Sprite warnLogSprite;
        public Color warnColor;
        public Sprite errorLogSprite;
        public Color errorColor;
        public Sprite helpLogSprite;
        public Color helpColor;
        public Sprite successLogSprite;
        public Color successColor;

        private Commander commander;
        private Canvas UICanvas = null;
        private LogPanel logPanel;

        private void Awake()
        {
            commander = GetComponent<Commander>();
            UICanvas = GetComponentInChildren<Canvas>();

            logPanel = Instantiate<LogPanel>(messagePanel, UICanvas.gameObject.transform);
        }

        private void Start()
        {

            commander.OnOpenCommander.AddListener(delegate { OnOpenCommander(); });
            commander.OnCloseCommander.AddListener(delegate { OnCloseCommander(); });
        }

        // TODO default value
        public void Log(string logText, float timer, Sprite sprite, Color color)
        {

            LogMessage log = Instantiate<LogMessage>(uiLogPrefab, logPanel.logToast.transform);
            log.transform.SetSiblingIndex(0);
            log.Setup(logText, commander.font, timer, sprite, color);

            LogMessage logA = Instantiate<LogMessage>(uiLogPrefab, logPanel.logScroll.transform);
            logA.transform.SetSiblingIndex(0);
            logA.Setup(logText, commander.font, sprite, color);

            messages.Enqueue(logA);
            if (messages.Count > 32)
            {
                LogMessage e = messages.Dequeue();
                Destroy(e.gameObject);
            }

        }

        public void OnOpenCommander()
        {
            logPanel.logPanelScroll.SetActive(true);
            logPanel.logToast.SetActive(false);
        }

        public void OnCloseCommander()
        {
            logPanel.logPanelScroll.SetActive(false);
            logPanel.logToast.SetActive(true);
        }


        #region Utils
        public void Log(string logText)
        {
            Log(logText, defaultTimer);
        }

        public void LogWarning(string logText)
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
            Log(logText, timer, defaultLogSprite, defaultColor);
        }

        public void LogWarn(string logText, float timer)
        {
            Log(logText, timer, warnLogSprite, warnColor);
        }

        public void LogError(string logText, float timer)
        {
            Log(logText, timer, errorLogSprite, errorColor);
        }

        public void LogHelp(string logText, float timer)
        {
            Log(logText, timer, helpLogSprite, helpColor);
        }

        public void LogSuccess(string logText, float timer)
        {
            Log(logText, timer, successLogSprite, successColor);
        }
        #endregion

    }



}

