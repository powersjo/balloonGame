using UnityEngine;
using System.Collections;

public class MusicStarted : MonoBehaviour {

    public int musicStarted;
	
    void Awake()
    {
        musicStarted = 0;
    }
    
    // Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

    public int GetMusicStatus()
    {
        return musicStarted;
    }

    public void StartMusic()
    {
        musicStarted = 1;
    }

    public void StopMusic()
    {
        musicStarted = 0;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
