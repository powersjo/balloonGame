using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeMusic : MonoBehaviour
{
    GameObject music;
    Button myButton;
	// Use this for initialization
	void Start () {
        myButton = this.gameObject.AddComponent<Button>();
        UnityEngine.Events.UnityAction action = () => { changeMusicLocal();};
        myButton.onClick.AddListener(action);
    }

    /**
    @"Music\techno";
    @"Music\circus_or_carousel_theme";
    @"Music\complimentary_colours";
    @"Music\lilly_s_saloon";
    @"Music\beware_theme";
    **/
    void changeMusicLocal()
    {
        music = GameObject.Find("MainMusic");
        string button = this.gameObject.name.ToString();
        if (button.Equals("Latin"))
        {
            music.GetComponent<MusicControl>().ChangeMusic("complimentary_colours");
        }
        else if (button.Equals("Techno"))
        {
            music.GetComponent<MusicControl>().ChangeMusic("techno");
        }
        else if (button.Equals("Ending"))
        {
            music.GetComponent<MusicControl>().ChangeMusic("beware_theme");
        }
        else if (button.Equals("Circus"))
        {
            music.GetComponent<MusicControl>().ChangeMusic("circus_or_carousel_theme");
        }
        else if (button.Equals("Saloon"))
        {
            music.GetComponent<MusicControl>().ChangeMusic("lilly_s_saloon");
        }
        else {
            music.GetComponent<MusicControl>().ChangeMusic();
        }
    }   
	// Update is called once per frame
	void Update () {

	}
}