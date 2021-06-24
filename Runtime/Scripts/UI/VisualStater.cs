using System;
using UnityEngine;
using System.Collections.Generic;
using ExpressoBits.Console.Stats;
using UnityEngine.UI;

namespace ExpressoBits.Console.UI
{
    [AddComponentMenu(menuName:"UI/Visual Stater")]
    public class VisualStater : MonoBehaviour
    {
        public InfoMessage infoMessagePrefab;
        public Theme theme;

        private readonly Dictionary<Info,InfoMessage> m_Stats = new Dictionary<Info,InfoMessage>();
        private Stater m_Stater;

        private void Awake()
        {
            m_Stater = FindObjectOfType<Stater>();
            m_Stater.onAddStat += AddInfo;
            m_Stater.onUpdateStat += UpdateInfo;
            m_Stater.onRemoveStat += RemoveInfo;
            m_Stater.onEnableStat += EnableInfo;
            m_Stater.onDisableStat += DisableInfo;
            foreach (var info in m_Stater.Infos)
            {
                AddInfo(info);
                DisableInfo(info);
            }
        }

        private void UpdateInfo(Info info)
        {
            //m_Stats[info].UpdateContent(info.content);
        }

        private void EnableInfo(Info info)
        {
            if (!m_Stats.TryGetValue(info, out var infoMessage)) return;
            infoMessage.gameObject.SetActive(true);
            LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
        }
        
        private void DisableInfo(Info info)
        {
            if (!m_Stats.TryGetValue(info, out var infoMessage)) return;
            infoMessage.gameObject.SetActive(false);
        }

        // Add new visual stat
        private void AddInfo(Info info)
        {
            var logMessage = Instantiate(infoMessagePrefab,transform);
            logMessage.Setup(info,theme.font);
            m_Stats.Add(info,logMessage);
        }

        private void RemoveInfo(Info info)
        {
            if (!m_Stats.TryGetValue(info, out var infoMessage)) return;
            Destroy(infoMessage.gameObject);
            m_Stats.Remove(info);

        }
    }

}

