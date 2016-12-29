using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CountPopped : MonoBehaviour {

	private int count, missed, max, totalClicks, backgroundNum, userHealth;
    public Text countText, currentTime, missedText, accuracyText;
    private double beginTime, timer;
	public GameObject but, but01, butExit, losePic, clickAccurate, options;
    private GameObject go;
    private bool hasPlanet, fail, complete, lockAccuracy, pause, endless;
    private Profile other;

    // Use this for initialization
    void Start () {
        go = GameObject.Find("Master");
        beginTime = System.DateTime.Now.ToOADate();
		timer = 0.0;
		count = missed = totalClicks = 0;
        max = GetCurrentScene();
        start_click();
        fail = complete = lockAccuracy = pause = endless = false;
        if(Application.loadedLevel == 11)
        {
            userHealth = 30;
        }
        else
        {
            userHealth = 0;
        }
	}

    public int getUserHeatlth()
    {
        return userHealth;
    }

    //Using this in level ten to win the game
    public void SetCount(int value)
    {
        count = value;
    }

    //Using this in level ten to win the game
    public void SetMissed(int value)
    {
        missed = value;
    }

    public void isEndless(bool x)
    {
        endless = x;
    }

    public void subUserHealth()
    {
        if (userHealth > 0)
        {
            userHealth--;
        }
    }
    public void killUser() //The boss got too big and won. 
    {
        userHealth = 0;
        if (!fail)
        {
            go.GetComponent<CountPopped>().IncreaseMissed(25); //25 is the boss health. hard coded fail
        }
        fail = true; // Here follow true and see what we need to do to 'pause' the game and show the menu. 
        // probably send stop move commands to balloons and stop grow commands to boss
    }

    public double GetTimer()
    {
        return timer;
    }
    public void SetHasPlanet(bool var)
    {
        hasPlanet = var;
    }
    public bool GetHasPlanet()
    {
        return hasPlanet;
    }
    public void SetBackNum(int var)
    {
        backgroundNum = var;
    }
    public int GetBackNum()
    {
        return backgroundNum;
    }
    public void increaseMaxCustom(int x)
    {
        max += x;
    }
    public void increaseMaxTwo()
    {
        max += 2;
    }
    private int GetCurrentScene()
    {
        max = 10 + ((Application.loadedLevel - 1) * 5);
        return max;
    }
	void SetCountText(){
		countText.text = "popped: " + count.ToString ();
	}
	void SetMissedText(){
		missedText.text = "Missed: " + missed.ToString ();
	}
    void SetAccuracyText()
    {
        if (!lockAccuracy)
        {
            pause = true;
            options.SetActive(true); //Options button
            accuracyText.text = "Accuracy: " + GetAccuracy().ToString("0.00") + "%";
            clickAccurate.SetActive(true); //Accuracy display
            lockAccuracy = true;
        }
    }
    public void IncreaseCount(){
		count++;
		SetCountText ();
	}
    private void IncreaseClicks()
    {
        totalClicks++;
    }
	public void IncreaseMissed(){
		missed++;
		SetMissedText ();
	}
    public void IncreaseMissed(int x)
    {
        missed += x;
        SetMissedText();
    }
    private float GetAccuracy()
    {
        float accurate = (float)count / (float)totalClicks;
        return accurate * 100;
    }
    System.Diagnostics.Stopwatch _sw = new System.Diagnostics.Stopwatch();
    private void start_click()
    {
        if (!_sw.IsRunning)
        {
            _sw.Start();
        }
        else
        {
            _sw.Stop();
            _sw.Reset();
        }
    }
    private void Each_Tick()
    {
        TimeSpan ts = _sw.Elapsed;
        DateTime dtime = DateTime.MinValue.Add(ts);
        currentTime.text = "Timer: " + string.Format(@"{0:mm\:ss}", dtime);
    }
    private void SetTime()
    {
        Each_Tick();
        but.SetActive(false); //restart button
        but01.SetActive(false); //Next level button
        butExit.SetActive(false); //The exit button
        losePic.SetActive(false); //Balloons win
        clickAccurate.SetActive(false); //Click accuracy
        options.SetActive(false); // Options button
    }

    /**
    * Use this public method to hide the gui in the case of 
    * a non-standard level that does not count balloons the 
    * normal way. 
    **/
    public void hideGuiButtons()
    {
        options.SetActive(false);
        but.SetActive(false);
        butExit.SetActive(false);
        losePic.SetActive(false);
        clickAccurate.SetActive(false);
    }

    //For level ten win only
    bool GetLevel10()
    {
        bool value = false;
        if (SceneManager.GetSceneByName("scene10") == SceneManager.GetActiveScene())
        {
            if (!GameObject.FindGameObjectWithTag("Balloon"))
            {
                value = true;
            }
        }
        return value;
    } 

	// Update is called once per frame
	void Update () {
        other = (Profile)go.GetComponent(typeof(Profile));
        if (Input.GetMouseButtonDown(0))
        {
            IncreaseClicks();
        }
		if(((missed + count) != max && !other.DidFail()) || endless ){ //Did fail is a question, did we fail? If not, continue time. 
            SetTime();
		}
		if (missed < 1) {
			missedText.text = "";
		}
		if (missed + count == max || fail) {
			but.SetActive(true);
            butExit.SetActive(true); //The exit button
            losePic.SetActive(true); //Balloons win
            other.SetFail(true);
            lockAccuracy = false;
            SetAccuracyText();
        } 
        if (missed < count && missed + count == max && !fail || GetLevel10()) // level difficulty could be implemented here. 
        {
            if (!complete)
            {
                other.lvlComplete(Application.loadedLevel);
                complete = true;
            }
            other.SetFail(false);
            losePic.SetActive(true);
            but01.SetActive(true); // new level.
            SetAccuracyText();
        }
	}
}
