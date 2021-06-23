using UnityEngine;

namespace ExpressoBits.Console.Stats
{
    public class FPSStat : StatBehaviour
    {

        [Range(0.1f,1f)]
        public float updateInterval = 0.5f;
        
        public Sprite fpsIcon;
        public Sprite msIcon;

        private Info m_InfoFPS;
        private Info m_InfoMS;

        private float m_AccumulatedTime = 0f;
        private int m_AccumulatedFrames = 0;
        private float m_LastUpdateTime;
        private float m_FrameTime = 0f;
        private float m_FrameRate = 0f;

        private void Awake()
        {
            Stater = GetComponentInParent<Stater>();
            m_InfoFPS = new Info("A",new LogAttribute(fpsIcon,new Color(0f,0f,0f,0f)))
            {
                isUpdate = true
            };
            m_InfoMS = new Info("A",new LogAttribute(msIcon,new Color(0f,0f,0f,0f)))
            {
                isUpdate = true
            };
            infos.Add(m_InfoFPS);
            infos.Add(m_InfoMS);
        }


        private void Update()
        {
            var deltaTime = Time.unscaledDeltaTime;

            m_AccumulatedTime += deltaTime;
            m_AccumulatedFrames++;

            var nowTime = Time.realtimeSinceStartup;
            if (nowTime - m_LastUpdateTime < updateInterval) {
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
            m_InfoFPS.content = string.Format(
                ColorText("{0}",color)+" FPS ",
                m_FrameRate.ToString("F0"));

            m_InfoMS.content = string.Format(
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

