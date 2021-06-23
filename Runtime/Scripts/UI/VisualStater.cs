using UnityEngine;
using System.Collections.Generic;
using ExpressoBits.Console.Stats;

namespace ExpressoBits.Console.UI
{
    [AddComponentMenu(menuName:"UI/Visual Stater")]
    public class VisualStater : MonoBehaviour
    {
        public InfoMessage infoMessagePrefab;
        public Theme theme;

        private readonly Dictionary<Info,InfoMessage> m_Stats = new Dictionary<Info,InfoMessage>();
        private Stater m_Stater;

        private void Start()
        {
            m_Stater = FindObjectOfType<Stater>();
            m_Stater.onAddStat += AddInfo;
            m_Stater.onUpdateInfo += UpdateInfo;
            m_Stater.onRemoveStat += RemoveInfo;

        }

        private void UpdateInfo(Info info)
        {
            //m_Stats[info].UpdateContent(info.content);
        }

        // Add new visual stat
        private void AddInfo(Info info)
        {
            var logMessage = Instantiate(infoMessagePrefab,transform);
            logMessage.Setup(info,theme.font);
            m_Stats.Add(info,logMessage);
            logMessage.transform.SetSiblingIndex(0);
        }

        private void RemoveInfo(Info info)
        {
            if (m_Stats.TryGetValue(info, out var infoMessage))
            {
                Destroy(infoMessage.gameObject);
                m_Stats.Remove(info);
            }

        }
    }

}

