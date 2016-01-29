using UnityEngine;
using System.Collections;

public class Choose_lvl : MonoBehaviour {

    int d;
	// Use this for initialization
	void Start () {
	
	}
	public void StartTheGame(){
		Application.LoadLevel(1);
	}
    public void LastLevel()
    {
        Application.LoadLevel(d);
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
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Options()
    {
        Application.LoadLevel(11);
        d = 0;
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
        d = 0;
    }
    public void Specific_lvl()
    {
        Application.LoadLevel(d);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("p"))
        {
            SetLastLevel(Application.loadedLevel);
            Application.LoadLevel(11);
        }
    }
    public void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
