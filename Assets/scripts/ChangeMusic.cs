using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeMusic : MonoBehaviour
{
    GameObject music;
    Button myButton;
	// Use this for initialization
	void Start () {
        // UnityEngine.Events.UnityAction action = () => { changeMusicLocal(); };
        //myButton.onClick.AddListener(action);
        myButton = this.gameObject.AddComponent<Button>();
        //myButton = this.gameObject.GetComponent<Button>();
        UnityEngine.Events.UnityAction action = () => { changeMusicLocal();};
        myButton.onClick.AddListener(action);
    }
    void changeMusicLocal()
    {
        Debug.Log("ftn");
        music = GameObject.Find("MainMusic");
        if(music != null)
        {
            Debug.Log("ftnn");
        }
        music.GetComponent<MusicControl>().ChangeMusic();
    }
	// Update is called once per frame
	void Update () {

	}
}