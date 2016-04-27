using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CountPopped : MonoBehaviour {

	private int count, missed, max, totalClicks, backgroundNum, userHealth;
    public Text countText, currentTime, missedText, accuracyText;
    private double beginTime, timer;
	public GameObject but, but01, butExit, losePic, clickAccurate;
    private GameObject go;
    private bool hasPlanet, fail, complete, lockAccuracy;
    private Profile other;

    // Use this for initialization
    void Start () {
        go = GameObject.Find("Master");
        beginTime = System.DateTime.Now.ToOADate();
		timer = 0.0;
		count = missed = totalClicks = 0;
        max = GetCurrentScene();
        start_click();
        fail = complete = lockAccuracy = false;
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

    public void subUserHealth()
    {
        if (userHealth > 0)
        {
            userHealth--;
        }
    }
    public void killUser()
    {
        userHealth = 0;
        fail = true;
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
    public void increaseMaxTwo()
    {
        max += 2;
    }
    private int GetCurrentScene()
    {
        max = 10 + ((Application.loadedLevel - 1) * 5);
        //Debug.Log(max);
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
    private float GetAccuracy()
    {
        float accurate = (float)count / (float)totalClicks;
        //Debug.Log("Total " + totalClicks + " | Count " + count + " | Accuracy " + accurate);
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
        //  currentTime.text = ts.ToString();
        DateTime dtime = DateTime.MinValue.Add(ts);
        currentTime.text = "Timer: " + string.Format(@"{0:mm\:ss}", dtime);
    }
    private void SetTime()
    {
        //timer = System.DateTime.Now.ToOADate();
        //timer = timer - beginTime;
        //v/ar min = timer / 60;
        //var sec = timer % 60;
        //var frac = (timer * 100) % 100;
        //currentTime.text = string.Format("Timer: {0:00}:{1:00}:{2:00}", min, sec, frac);
        Each_Tick();
        but.SetActive(false); //restart button
        but01.SetActive(false); //Next level button
        butExit.SetActive(false); //The exit button
        losePic.SetActive(false); //Balloons win
        clickAccurate.SetActive(false); //Click accuracy
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            IncreaseClicks();
        }
		if((missed + count) != max){
            SetTime();
		}
		if (missed < 1) {
			missedText.text = "";
		}
		if (missed + count == max || fail) {
			but.SetActive(true);
            butExit.SetActive(true); //The exit button
            losePic.SetActive(true); //Balloons win
            SetAccuracyText();
        } 
        if (missed < count && missed + count == max && !fail) // level difficulty could be implemented here. 
        {
            other = (Profile)go.GetComponent(typeof(Profile));
            if (!complete)
            {
                other.lvlComplete(Application.loadedLevel);
                complete = true;
            }
            losePic.GetComponent<Image>().sprite =  Resources.Load<Sprite>("win");
            but01.SetActive(true); // new level.
            SetAccuracyText();
        }
	}
}
