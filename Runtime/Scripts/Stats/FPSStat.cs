using UnityEngine;

namespace ExpressoBits.Console.Stats
{
    public class FPSStat : StatBehaviour
    {

        [Range(0.1f,1f)]
        public float UpdateInterval = 0.5f;
        
        public Sprite fpsIcon;
        public Sprite msIcon;

        private Info _infoFPS;
        private Info _infoMS;

        private float m_AccumulatedTime = 0f;
        private int m_AccumulatedFrames = 0;
        private float m_LastUpdateTime;
        private float m_FrameTime = 0f;
        private float m_FrameRate = 0f;

        public static float MinTime = 0.000000001f;

        private void Awake()
        {
            Stater = GetComponentInParent<Stater>();
            _infoFPS = new Info("", new LogAttribute(fpsIcon, new Color(0, 0, 0, 0)))
            {
                isUpdate = true
            };
            _infoMS = new Info("", new LogAttribute(msIcon, new Color(0, 0, 0, 0)))
            {
                isUpdate = true
            };
            infos.Add(_infoFPS);
            infos.Add(_infoMS);
        }


        private void Update()
        {
            float deltaTime = Time.unscaledDeltaTime;

            m_AccumulatedTime += deltaTime;
            m_AccumulatedFrames++;

            float nowTime = Time.realtimeSinceStartup;
            if (nowTime - m_LastUpdateTime < UpdateInterval) {
                return;
            }

            m_FrameTime = m_AccumulatedTime / m_AccumulatedFrames;
            m_FrameRate = 1.0f / m_FrameTime;

            UpdateInfo();

            ResetProbingData();
            m_LastUpdateTime = nowTime;
        }


        private void UpdateInfo()
        {
            _infoFPS.content = string.Format(
                ColorText("{0}",color)+" FPS ",
                m_FrameRate.ToString("F0"));

            _infoMS.content = string.Format(
                ColorText("{0}",color)+" MS ",
                (m_FrameTime*1000f).ToString("F1"));
        }

        
        private void ResetProbingData() {
            m_AccumulatedTime = 0.0f;
            m_AccumulatedFrames = 0;
        }

        private void Reset()
        {
            m_LastUpdateTime = Time.realtimeSinceStartup;
        }

        
    }
}

