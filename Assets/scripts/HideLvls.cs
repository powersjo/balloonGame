using UnityEngine;
using System.Collections;

public class HideLvls : MonoBehaviour {
    private GameObject go;
    private Profile other;
    public GameObject lvl2, lvl3, lvl4, lvl5, lvl6, lvl7, lvl8, lvl9, lvl10, lvl11;
    // Use this for initialization
    void Start () {
        go = GameObject.Find("Choose_lvl");
        int highest = go.GetComponent<Profile>().GetHighestLvlComplete();
        if(highest < 11)
        {
            lvl11.SetActive(false);
            if(highest < 10)
            {
                lvl10.SetActive(false);
                if (highest < 9)
                {
                    lvl9.SetActive(false);
                    if (highest < 8)
                    {
                        lvl8.SetActive(false);
                        if (highest < 7)
                        {
                            lvl7.SetActive(false);
                            if (highest < 6)
                            {
                                lvl6.SetActive(false);
                                if (highest < 5)
                                {
                                    lvl5.SetActive(false);
                                    if (highest < 4)
                                    {
                                        lvl4.SetActive(false);
                                        if (highest < 3)
                                        {
                                            lvl3.SetActive(false);
                                            if (highest < 2)
                                            {
                                                lvl2.SetActive(false);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
