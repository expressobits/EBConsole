using UnityEngine;

namespace ExpressoBits.Console.UI
{
    [CreateAssetMenu(fileName = "New Theme", menuName = "Expresso Bits/Console/Theme", order = 0)]
    public class Theme : ScriptableObject
    {
        public Font font;
        
        [Header("Log Attributes")]
        public LogAttribute defaultLogAttribute;
        public LogAttribute warnLogAttribute;
        public LogAttribute errorLogAttribute;
        public LogAttribute helpLogAttribute;
        public LogAttribute successLogAttribute;
    }
}