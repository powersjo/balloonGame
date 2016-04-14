using UnityEngine;
//using UnityEngine.SceneManagement;
//using System.Collections;

public class MusicControl : MonoBehaviour {
    //private AudioSource backgroudMusic;
    //static bool AudioBegin = false;

    private GameObject musicPlayer = GameObject.Find("MainMusic");
    //private GameObject localMusicStatus = GameObject.Find("MusicChecker");
    void Awake()
    {

        if (musicPlayer == null)
        {
            musicPlayer = this.gameObject;
            musicPlayer.name = "MainMusic";
            //if (!AudioBegin)
            //{
            //AudioClip thisAudioClip;
            //thisAudioClip = (AudioClip)Resources.Load("techno");
            //musicPlayer.AddComponent<AudioSource>().PlayClipAtPoint(thisAudioClip, transform.position, 0.8F);
            AudioSource musicSource = musicPlayer.AddComponent<AudioSource>();//.PlayClipAtPoint(thisAudioClip, transform.position, 0.8F);
            musicSource.PlayOneShot((AudioClip)Resources.Load("techno"));
            //AudioClip thisAudioClip = musicSource.GetComponent<AudioClip>();
            //musicSource.PlayClipAtPoint(thisAudioClip, transform.position, 0.8F);
            //SpriteRenderer balloonSR = gameObject.AddComponent<SpriteRenderer>();
            //GetComponent<AudioSource>().Play();
            //thisAudioClip = (AudioClip)Resources.Load("techno");
           // thisAudioClip = musicPlayer.GetComponent<AudioSource>().GetComponent<AudioClip>();
            //thisAudioClip = (AudioClip)Resources.Load("techno");

            DontDestroyOnLoad(musicPlayer);
                //AudioBegin = true;

                // if (SceneManager.GetActiveScene().buildIndex != 0) { 
                // DontDestroyOnLoad(gameObject);
            //}
        } else
        {
            if (this.gameObject.name != "MainMusic")
            {
                Destroy(this.gameObject);
            }
        }
    }
    void Start() {
        /*if(localMusicStatus.GetComponent<MusicStarted>().GetMusicStatus() == 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            localMusicStatus.GetComponent<MusicStarted>().StartMusic();
        }*/
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
