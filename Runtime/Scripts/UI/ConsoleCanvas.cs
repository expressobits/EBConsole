using System;
using UnityEngine;
using UnityEngine.UI;

namespace ExpressoBits.Console.UI
{
    public class ConsoleCanvas : MonoBehaviour
    {
        private Commander m_Commander;
        private Logs m_Logs;
        
        [Header("UI Prefabs")]
        public InputField consoleInputPrefab;
        public LogPanel messagePanel;
        public LogMessage uiLogPrefab;

        public Font font;
        
        [HideInInspector]
        public InputField consoleInput;
        
        private LogPanel m_LogPanel;
        
        private void Awake()
        {
            m_Commander = GetComponentInParent<Commander>();
            consoleInput = Instantiate(consoleInputPrefab, transform);
            
            consoleInput.onValueChanged.AddListener(delegate
            {
                if (!consoleInput.text.Contains("\n")) return;
                var text = (consoleInput.text).Remove(consoleInput.text.LastIndexOf("\n", StringComparison.Ordinal));
                consoleInput.text = text;
                m_Commander.ProcessCommand(text);
            });

            consoleInput.GetComponentInChildren<Text>().font = font;

            consoleInput.gameObject.SetActive(false);
            
            m_Commander.onCloseCommander.AddListener(delegate {
                consoleInput.gameObject.SetActive(false);
                //consoleInput.DeactivateInputField();
            });
            
            m_Commander.onOpenCommander.AddListener(delegate
            {
                consoleInput.gameObject.SetActive(true);
                consoleInput.ActivateInputField();
            });
            
            m_Commander.onFinishProcessCommand.AddListener(delegate
            {
                consoleInput.text = string.Empty;
            });
    
            // Check if logs exists
            m_Logs = GetComponentInParent<Logs>();
            if (m_Logs)
            {
                m_LogPanel = Instantiate(messagePanel, transform);
                
                m_Commander.onCloseCommander.AddListener(delegate
                {
                    m_LogPanel.logPanelScroll.SetActive(false);
                    m_LogPanel.logToast.SetActive(true);
                });
                
                m_Commander.onOpenCommander.AddListener(delegate
                {
                    m_LogPanel.logPanelScroll.SetActive(true);
                    m_LogPanel.logToast.SetActive(false);
                });
            }

        }

        public bool IsEnableInput()
        {
            return consoleInput.gameObject.activeSelf;
        }

        public LogMessage InstantiateLogsAndReturnToastLog(string logText,float timer, Sprite sprite, Color color)
        {
            var staticLog = Instantiate(uiLogPrefab, m_LogPanel.logToast.transform);
            staticLog.transform.SetSiblingIndex(0);
            staticLog.Setup(logText,font, timer, sprite, color);
            
            var toastLog = Instantiate(uiLogPrefab, m_LogPanel.logScroll.transform);
            toastLog.transform.SetSiblingIndex(0);
            toastLog.Setup(logText, font, sprite, color);

            return toastLog;
        }
    }

}

