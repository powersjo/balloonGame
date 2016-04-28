using UnityEngine;

public class MusicControl : MonoBehaviour {
    public AudioClip thisAudioClip;
    private AudioSource musicSource;
    private bool flip = true;
    private GameObject musicPlayer;
    private string[] music;
    private bool mute;
    int cap;
    void Awake()
    {
        musicPlayer = this.gameObject;
        musicPlayer.name = "MainMusic";
        cap = 4;
        musicSource = musicPlayer.AddComponent<AudioSource>();
        DontDestroyOnLoad(musicPlayer);

    }
    void Start() {
        mute = false;
        music = new string[5];
        music[0] = @"Music\techno";
        music[1] = @"Music\circus_or_carousel_theme";
        music[2] = @"Music\complimentary_colours";
        music[3] = @"Music\lilly_s_saloon";
        music[4] = @"Music\beware_theme";
    }
    public void enableEndMusic()
    {
        cap = 5;
    }

    public void ToggleMute()
    {
        if (!mute)
        {
            AudioListener.pause = mute = true;
        }
        else
        {
            AudioListener.pause = mute = false;
        }
    }

    /**
    * Change Music to a random song
    **/
    public void ChangeMusic()
    {
        thisAudioClip = (AudioClip)Resources.Load(music[UnityEngine.Random.Range(0, cap)]);
        CycleMusic();
    }
    /**
    * Change Music to a specific song
    **/
    public void ChangeMusic(string songName)
    {
        thisAudioClip = (AudioClip)Resources.Load(@"Music\"+ songName);
        CycleMusic();
    }
    /*
    *   Helper method to save code space
    *   simply turns off music, assigns and plays the music.    
    */
    private void CycleMusic()
    {
        musicPlayer.GetComponent<AudioSource>().Stop();
        musicPlayer.GetComponent<AudioSource>().clip = thisAudioClip;
        musicPlayer.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (musicSource.clip == null)
        {
            CycleMusic();
            musicPlayer.GetComponent<AudioSource>().loop = true;
        }
    }
}
