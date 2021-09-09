using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExpressoBits.Console.UI
{
    [AddComponentMenu("UI/Visual Consoler")]
    public class VisualConsoler : MonoBehaviour
    {
        public ConsoleAlign align;
        public Theme theme;
        
        [Header("UI Prefabs")]
        public InputField consoleInputPrefab;
        public LogPanel messagePanel;
        public InfoMessage uiLogPrefab;

        
        [HideInInspector]
        public InputField consoleInput;
        
        private LogPanel m_LogPanel;

        private readonly Dictionary<Info, InfoMessage> m_InfoMessages = new Dictionary<Info, InfoMessage>();

        private void Awake()
        {
            if (Consoler.Commander)
            {
                SetupConsoleInput();
                consoleInput.onValueChanged.AddListener(delegate
                {
                    if (!consoleInput.text.Contains("\n")) return;
                    var text = (consoleInput.text).Remove(consoleInput.text.LastIndexOf("\n", StringComparison.Ordinal));
                    consoleInput.text = text;
                    Consoler.Commander.Input = text;
                    Consoler.Commander.ProcessCommand();
                });

                consoleInput.GetComponentInChildren<Text>().font = theme.font;

                consoleInput.gameObject.SetActive(false);
            
                Consoler.Commander.onCloseCommander.AddListener(delegate {
                    consoleInput.gameObject.SetActive(false);
                    //consoleInput.DeactivateInputField();
                });
            
                Consoler.Commander.onOpenCommander.AddListener(delegate
                {
                    consoleInput.gameObject.SetActive(true);
                    consoleInput.ActivateInputField();
                });
            }
            
            InitLogs();
            Consoler.Commander.onChangeInputCommander += SetInputText;
        }

        private void InitLogs()
        {
            if (Consoler.Logs)
            {
                SetupLogPanel();
                Consoler.Logs.OnLog += AddInfo;
                Consoler.Logs.OnDequeue += Dequeue;
                if (Consoler.Commander)
                {
                    Consoler.Commander.onCloseCommander.AddListener(delegate
                    {
                        SetOpenLogScroll(false);
                    });
                
                    Consoler.Commander.onOpenCommander.AddListener(delegate
                    {
                        SetOpenLogScroll(true);
                    });
                }
            }
            SetOpenLogScroll(false);

        }
        
        private void SetOpenLogScroll(bool active)
        {
            m_LogPanel.logPanelScroll.SetActive(active);
            m_LogPanel.logPanelToast.SetActive(!active);
        }

        private void AddInfo(Info info)
        {
            InfoMessage message = InstantiateLogsAndReturnToastLog(info);
            m_InfoMessages.Add(info,message);
        }

        private void Dequeue(Info info)
        {
            var infoMessage = m_InfoMessages[info];
            m_InfoMessages.Remove(info);
            if (infoMessage != null)
            {
                Destroy(infoMessage.gameObject);
            }
            LayoutRebuilder.ForceRebuildLayoutImmediate(m_LogPanel.logScrollContent.GetComponent<RectTransform>());
        }


        private void SetupLogPanel()
        {
            m_LogPanel = Instantiate(messagePanel, transform);
            if (align != ConsoleAlign.Bottom) return;
            var r = m_LogPanel.GetComponent<RectTransform>();
            r.offsetMin = new Vector2(r.offsetMin.x, 24);
            r.offsetMax = new Vector2(r.offsetMax.x, 0);

            var verticalLayoutGroup = m_LogPanel.logPanelToast.GetComponent<VerticalLayoutGroup>();
            verticalLayoutGroup.childAlignment = TextAnchor.LowerCenter;

            var verticalLayoutGroup2 = m_LogPanel.logScrollContent.GetComponent<VerticalLayoutGroup>();
            verticalLayoutGroup2.childAlignment = TextAnchor.LowerCenter;
            var r3 = m_LogPanel.logScrollContent.GetComponent<RectTransform>();
            r3.pivot = new Vector2(r3.pivot.x, 0);
            r3.anchorMin = new Vector2(r3.anchorMin.x, 0);
            r3.anchorMax = new Vector2(r3.anchorMax.x, 0);

            var r2 = m_LogPanel.logScrollContent.GetComponent<RectTransform>();
            r2.pivot = new Vector2(r2.pivot.x, 0);
            r2.anchorMin = new Vector2(r2.anchorMin.x, 0);
            r2.anchorMax = new Vector2(r2.anchorMax.x, 0);
        }

        private void SetupConsoleInput()
        {
            consoleInput = Instantiate(consoleInputPrefab, transform);

            if (align != ConsoleAlign.Bottom) return;
            var r = consoleInput.GetComponent<RectTransform>();
            //r.pivot = Vector2.down;
            r.pivot = new Vector2(r.pivot.x,0);
            r.anchorMin = new Vector2(r.anchorMin.x,0);
            r.anchorMax = new Vector2(r.anchorMax.x,0);


        }

        public bool IsEnableInput()
        {
            return consoleInput.gameObject.activeSelf;
        }

        private InfoMessage InstantiateLogsAndReturnToastLog(Info info)
        {

            var toastLog = Instantiate(uiLogPrefab, m_LogPanel.logPanelToast.transform);
            toastLog.GetComponent<RectTransform>().ForceUpdateRectTransforms();
            if(align == ConsoleAlign.Top)toastLog.transform.SetSiblingIndex(0);
            
            toastLog.Setup(info,8f,theme.font);
            
            if (!Consoler.Commander) return toastLog;
            var staticLog = Instantiate(uiLogPrefab, m_LogPanel.logScrollContent.transform);
            staticLog.GetComponent<RectTransform>().ForceUpdateRectTransforms();
            if(align == ConsoleAlign.Top)staticLog.transform.SetSiblingIndex(0);
            staticLog.Setup(info,theme.font);
            return staticLog;
        }

        public string GetActualText()
        {
            return consoleInput.text;
        }

        private void SetInputText(string text)
        {
            consoleInput.text = text;
            SetCaretInputPosition(consoleInput.text.Length);
        }

        private void SetCaretInputPosition(int position)
        {
            consoleInput.caretPosition = position;
        }
    }

}

