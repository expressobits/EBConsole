using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExpressoBits.Console.Logs;

namespace ExpressoBits.Console
{
    public class MessageLogger : Singleton<MessageLogger>
    {

        public GameObject painelToastLogs;
        public GameObject painelPermanentLogs;

        public LogMessage uiLogPrefab;

        public Queue<LogMessage> messages = new Queue<LogMessage>();

        public float defaultTimer = 16f;


        public void Log(string logText, float timer)
        {
            LogMessage log = Instantiate<LogMessage>(uiLogPrefab, painelToastLogs.transform);
            log.transform.SetSiblingIndex(0);
            log.Setup(logText, timer);

            LogMessage logA = Instantiate<LogMessage>(uiLogPrefab, painelPermanentLogs.transform);
            logA.transform.SetSiblingIndex(0);
            logA.Setup(logText);

            messages.Enqueue(logA);
            if (messages.Count > 32)
            {
                LogMessage e = messages.Dequeue();
                Destroy(e.gameObject);
            }



        }

        public void Log(string logText)
        {
            Log(logText, defaultTimer);
        }

    }



}

