using UnityEngine;
using System.Collections;

public class GenerateBalloon : MonoBehaviour {
    void Start()
    {
        InvokeRepeating("Generate", 0f, 1f);
    }
    void Generate()
    {
        GameObject dummy;
        dummy = GameObject.Find("BalloonGroup");
        dummy.GetComponent<FirstSceneBalloon>().SpawnBaloons();
    }
}
