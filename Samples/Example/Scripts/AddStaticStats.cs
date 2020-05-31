using ExpressoBits.Console;
using ExpressoBits.Console.Stats;
using UnityEngine;

public class AddStaticStats : MonoBehaviour
{
    public Stater stater;
    public LogAttribute logAttribute;
    
    // Start is called before the first frame update
    private void Start()
    {

        stater.AddStat(new Info("TESTING STATUS",logAttribute));
    }

}
