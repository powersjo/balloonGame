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
        InvokeRepeating("InvokeParent", begin, 30f); // every 30 seconds invoke another invoke repeating generation of balloons. 
    }
    
    public int getBalloonNum()
    {
        return tracker;
    }

    public void addToBalloonTracker(int i)
    {
        tracker = tracker + i;
    }

    void InvokeParent()
    {
        InvokeRepeating("Generate", begin, interval);
    }

    void Generate()
    {
        /* 
        * Maybe use time on the high end of the range to
        * scale the endless scene. 10 second intervals? 
        * 30 second intervals. <<<
        */ 
        amount = Random.Range(1, 4);
        dummy.GetComponent<EndlessBalloon>().setAmount(amount);
        dummy.GetComponent<EndlessBalloon>().SpawnBaloons();
    }
    void Update()
    {

    }
}
