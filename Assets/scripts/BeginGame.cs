using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour {

    private float time;

    // Use this for initialization
    void Start () {
        time = 8f;//UnityEngine.Random.Range(3F, 4F); 
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
