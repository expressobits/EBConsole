using UnityEngine;

namespace ExpressoBits.Console
{
    [AddComponentMenu(menuName:"Console/Toggle Commander")]
    [RequireComponent(typeof(Commander))]
    public class ToggleCommander : MonoBehaviour
    {

        public KeyCode openKey = KeyCode.Return;
        public KeyCode closeKey = KeyCode.Escape;

        private Commander m_Commander;

        private void Awake()
        {
            m_Commander = GetComponent<Commander>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(openKey))
            {
                m_Commander.OpenCommander();
            }

            if (Input.GetKeyDown(closeKey))
            {
                m_Commander.CloseCommander();
            }
        }

    }

}

