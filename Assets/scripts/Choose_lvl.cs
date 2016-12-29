using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Choose_lvl : MonoBehaviour {
    GameObject localMusic;
    public int d = 1;
    
	// Use this for initialization
	void Start () {
        localMusic = GameObject.Find("MainMusic");
	}
	public void StartTheGame(){
        SceneManager.LoadScene(13);
	}
    public void Lvl1()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl2()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl3()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl4()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl5()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl6()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl7()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl8()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl9()
    {
        SceneManager.LoadScene(15);
    }
    public void Lvl10()
    {
        SceneManager.LoadScene(15);
    }
    public void Endless()
    {
        SceneManager.LoadScene(15);
    }
    public void LastLevel()
    {
        GameObject temp = GameObject.Find("MainMusic");
        d = temp.GetComponent<MusicControl>().GetLastLevel();
        SceneManager.LoadScene(d);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void SetLastLevel(int level)
    {
        d = level;
    }

    public void SetLastLevelBetter(int n)
    {
        GameObject temp = GameObject.Find("MainMusic");
        temp.GetComponent<MusicControl>().SetLastLevel(n);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
    public void Options()
    {
        SceneManager.LoadScene(12);
    }
    public void ToggleMute()
    {
        localMusic.GetComponent<MusicControl>().ToggleMute();
        Debug.Log("From choose level");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        d = 1;
    }
    public void Specific_lvl()
    {
        SceneManager.LoadScene(d);
    }

    // Update is called once per frame
    void Update () {
        
        //P is for pause the game
        if (Input.GetKeyDown("p"))
        {
            //You should not be able to pause the game when you are not actively in a level. 
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("options") &&
                SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Loading") &&
                SceneManager.GetActiveScene() != SceneManager.GetSceneByName("LvlSelect") &&
                SceneManager.GetActiveScene() != SceneManager.GetSceneByName("mainMenu") &&
                SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MusicStart"))
            {
                SetLastLevel(Application.loadedLevel);
                SceneManager.LoadScene("options");
            }
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(15);
    }
}
