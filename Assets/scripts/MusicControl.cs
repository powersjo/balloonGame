using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {
    //private AudioSource backgroudMusic;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start() {
        //backgroudMusic = (AudioSource)gameObject.AddComponent<AudioSource>();
        AudioClip thisAudioClip;
        thisAudioClip = (AudioClip)Resources.Load("techno");
        //backgroudMusic.clip = myAudioClip;
        //backgroudMusic.volume = 0.05F;
        AudioSource.PlayClipAtPoint(thisAudioClip, transform.position, 0.8F);
        // backgroudMusic.Play();
    }
    void Update()
    {
       /* if(Application.loadedLevel == 0 || Application.loadedLevel == 11)
       // {
        //    backgroudMusic.Stop();
           // DestroyObject(this.gameObject);
        //} else *///if (backgroudMusic.isPlaying == false && (Application.loadedLevel != 0 || Application.loadedLevel != 11))
        //{
            //AudioSource.PlayClipAtPoint(myAu);
            //backgroudMusic.volume = 0.05F;
        //}
    }
}
