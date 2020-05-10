using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ExpressoBits.Console
{
    [RequireComponent(typeof(Commander))]
    public class History : MonoBehaviour
    {
        public KeyCode upKeyCode = KeyCode.UpArrow;
        public KeyCode downKeyCode = KeyCode.DownArrow;

        private Commander m_Commander;

        [Range(0, 256)] public int maxHistoryRegistry;
        
        [HideInInspector]
        public List<string> history;
        private int m_ActualIndex;
        
        private static readonly int NoValue = -1;
        
        private void Awake()
        {
            m_Commander = GetComponent<Commander>();
            history = new List<string>();
        }

        private void Start()
        {
            m_Commander.onOpenCommander.AddListener(delegate { enabled = true; });
            m_Commander.onCloseCommander.AddListener(delegate { enabled = false; });
        }

        private void OnEnable()
        {
            m_Commander.onProcessCommand.AddListener(AddLastCommand);
        }

        private void OnDisable()
        {
            m_Commander.onProcessCommand.RemoveListener(AddLastCommand);
        }

        private void AddLastCommand()
        {
            if (m_Commander.consoleInput.text.Length > 0)
            {
                history.Add(m_Commander.consoleInput.text);
                if (history.Count > maxHistoryRegistry)
                {
                    history.RemoveAt(0);
                }

            }
            
            m_ActualIndex = NoValue;
        }

        private void Update()
        {
            if (Input.GetKeyDown(downKeyCode))
            {
                if (history.Count == 0) return;
                m_ActualIndex++;
                if (m_ActualIndex == history.Count) m_ActualIndex = 0;
                m_Commander.consoleInput.text = history[m_ActualIndex];
                m_Commander.consoleInput.caretPosition = m_Commander.consoleInput.text.Length;
            }

            else if (Input.GetKeyDown(upKeyCode))
            {
                if (history.Count == 0) return;
                m_ActualIndex--;
                if (m_ActualIndex == NoValue)
                {
                    m_Commander.consoleInput.text = "";
                    return;
                }

                if (m_ActualIndex == -2) m_ActualIndex = history.Count-1;
                m_Commander.consoleInput.text = history[m_ActualIndex];
                m_Commander.consoleInput.caretPosition = m_Commander.consoleInput.text.Length;
            }
        }
        
        

    }
}