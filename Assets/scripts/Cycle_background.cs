using UnityEngine;
using System.Collections;

public class Cycle_background : MonoBehaviour {
    private CountPopped other;
    private GameObject go;
    // Use this for initialization
    void Start () {
        int planet = Random.Range(0, 1);
        int num = Random.Range(1, 12);
        string zero = "";
        go = GameObject.Find("Master");
        other = (CountPopped)go.GetComponent(typeof(CountPopped));
        other.SetBackNum(num);
        if (num < 10)
        {
            zero = "0";
        }
        if(planet == 1)
        {
            this.GetComponent<MeshRenderer>().material = Resources.Load("SkySphere/Materials/With_Planet/Planet_" + zero + num.ToString(), typeof(Material)) as Material;
            other.SetHasPlanet(true);
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = Resources.Load("SkySphere/Materials/Without_Planet/Sky_" + zero + num.ToString(), typeof(Material)) as Material;
            other.SetHasPlanet(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
