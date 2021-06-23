using UnityEngine;

namespace ExpressoBits.Console
{
    public interface IVisualConsoler
    {
        public string GetActualText();

        public void SetInputText(string text);
        public void SetCaretInputPosition(int position);
    }
}