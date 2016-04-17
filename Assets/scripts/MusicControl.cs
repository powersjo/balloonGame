using UnityEngine;

public class MusicControl : MonoBehaviour {
    public AudioClip thisAudioClip;
    private AudioSource musicSource;
    private bool flip = true;
    private GameObject musicPlayer;
    private string[] music;
    void Awake()
    {
        musicPlayer = this.gameObject;
        musicPlayer.name = "MainMusic";

        musicSource = musicPlayer.AddComponent<AudioSource>();
        DontDestroyOnLoad(musicPlayer);

    }
    void Start() {
        music = new string[2];
        music[0] = "Music\techno";
        music[1] = @"Music\circus_or_carousel_theme";
    }
    /**
    * Change Music to a random song
    **/
    public void ChangeMusic()
    {
        Debug.Log(music[1]);
        thisAudioClip = (AudioClip)Resources.Load(music[1]);
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
