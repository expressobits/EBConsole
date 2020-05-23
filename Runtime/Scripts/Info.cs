namespace ExpressoBits.Console
{
    [System.Serializable]
    public class Info
    {
        public string content;
        public LogAttribute logAttribute;
        public bool isUpdate;

        public Info(string content,LogAttribute logAttribute)
        {
            this.content = content;
            this.logAttribute = logAttribute;
        }

        
    }
}

