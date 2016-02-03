using UnityEngine;
using System.Collections;

public class HideLvls : MonoBehaviour {
    private GameObject go;
    private Profile other;
    // Use this for initialization
    void Start () {
        go = GameObject.Find("Choose_lvl");
    }
    void checkLevels()
    {
        other = (Profile)go.GetComponent(typeof(Profile));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
