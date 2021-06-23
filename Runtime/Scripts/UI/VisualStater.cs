using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace ExpressoBits.Console.UI
{
    [AddComponentMenu(menuName:"UI/Visual Stater")]
    public class VisualStater : MonoBehaviour
    {
        public InfoMessage infoMessagePrefab;

        private readonly Dictionary<Info,InfoMessage> stats = new Dictionary<Info,InfoMessage>();

        public Theme theme;

        // Add new visual stat
        public void AddInfo(Info info)
        {
            InfoMessage logMessage = Instantiate<InfoMessage>(infoMessagePrefab,transform);
            logMessage.Setup(info,theme.font);
            stats.Add(info,logMessage);
        }

        public void AddInfo(Info info, float timer)
        {
            InfoMessage logMessage = Instantiate<InfoMessage>(infoMessagePrefab,transform);
            logMessage.Setup(info,theme.font);
            stats.Add(info,logMessage);
        }

        public void RemoveInfo(Info info)
        {
            if (stats.TryGetValue(info, out InfoMessage infoMessage))
            {
                Destroy(infoMessage.gameObject);
                stats.Remove(info);

            }

        }


        //
    }

}

