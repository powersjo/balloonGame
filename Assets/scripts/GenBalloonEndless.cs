using UnityEngine;
using System.Collections;

public class GenBalloonEndless : MonoBehaviour {
    private float interval, begin;
    private int amount; //The amount of balloons to spawn at a time.
    private GameObject dummy;
    private int tracker;

    void Start()
    {
        tracker = 0;
        dummy = GameObject.Find("Master");
        dummy.GetComponent<CountPopped>().hideGuiButtons();
        dummy.GetComponent<CountPopped>().isEndless(true);
        begin = Random.Range(.1f, 1f);
        interval = Random.Range(2f, 6f);
        InvokeRepeating("Generate", begin, interval);
    }
    
    public int getBalloonNum()
    {
        return tracker;
    }

    public void addToBalloonTracker(int i)
    {
        tracker = tracker + i;
    }
    void Generate()
    {
        /* 
        * Maybe use time on the high end of the range to
        * scale the endless scene. 10 second intervals? 
        */ 
        amount = Random.Range(1, 4);
        dummy.GetComponent<EndlessBalloon>().setAmount(amount);
        dummy.GetComponent<EndlessBalloon>().SpawnBaloons();
    }
}
