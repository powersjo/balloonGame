using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Choose_lvl : MonoBehaviour {

    int d;
	// Use this for initialization
	void Start () {
	
	}
	public void StartTheGame(){
        SceneManager.LoadScene(12);
	}
    public void Lvl1()
    {
        SceneManager.LoadScene(1);
    }
    public void Lvl2()
    {
        SceneManager.LoadScene(2);
    }
    public void Lvl3()
    {
        SceneManager.LoadScene(3);
    }
    public void Lvl4()
    {
        SceneManager.LoadScene(4);
    }
    public void Lvl5()
    {
        SceneManager.LoadScene(5);
    }
    public void Lvl6()
    {
        SceneManager.LoadScene(6);
    }
    public void Lvl7()
    {
        SceneManager.LoadScene(7);
    }
    public void Lvl8()
    {
        SceneManager.LoadScene(8);
    }
    public void Lvl9()
    {
        SceneManager.LoadScene(9);
    }
    public void Lvl10()
    {
        SceneManager.LoadScene(10);
    }
    public void Endless()
    {
        SceneManager.LoadScene(13);
    }
    public void LastLevel()
    {
        SceneManager.LoadScene(d);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private void SetLastLevel(int level)
    {
        d = level;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
    public void Options()
    {
        SceneManager.LoadScene(11);
        d = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        d = 0;
    }
    public void Specific_lvl()
    {
        SceneManager.LoadScene(d);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("p"))
        {
            SetLastLevel(Application.loadedLevel);
            SceneManager.LoadScene(11);
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }
}
