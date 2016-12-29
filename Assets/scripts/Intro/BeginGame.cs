using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour {

    private float time;

    // Use this for initialization
    void Start () {
        time = 8f;
	}
    
    /**
    * This Method is for the time of the intro scene before 
    * going to the main menu. The music has to wait this amount 
    * of time and the text needs to fade in and out in this 
    * amount of time. 
    * @return: float (time).
    **/
    public float getTime()
    {
        return time;
    }
	
	// Update is called once per frame
	void Update () {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("mainMenu");
        }
    }
}
