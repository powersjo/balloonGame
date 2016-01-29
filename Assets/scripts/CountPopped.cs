using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CountPopped : MonoBehaviour {

	private int count, missed;
	public Text countText, currentTime, missedText;
    //private float timer;
    private double beginTime, timer;
	public GameObject but, but01, butExit, losePic;
    private int max;
    private bool hasPlanet;
    private int backgroundNum, userHealth;

	// Use this for initialization
	void Start () {
        beginTime = System.DateTime.Now.ToOADate();
		timer = 0.0;
		count = 0;
		missed = 0;
        max = GetCurrentScene();
        start_click();
        if(Application.loadedLevel == 10)
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
        userHealth--;
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
        max = 10 + (Application.loadedLevel * 5);
        //Debug.Log(max);
        return max;
    }
	void SetCountText(){
		countText.text = "Balloons popped: " + count.ToString ();
	}
	void SetMissedText(){
		missedText.text = "Missed: " + missed.ToString ();
	}
	public void IncreaseCount(){
		count++;
		SetCountText ();
	}
	public void IncreaseMissed(){
		missed++;
		SetMissedText ();
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
    }
	// Update is called once per frame
	void Update () {
		if((missed + count) != max){
            SetTime();
		}
		if (missed < 1) {
			missedText.text = "";
		}
		if (missed + count == max) {
			but.SetActive(true);
            but01.SetActive(true);
            butExit.SetActive(true); //The exit button
            losePic.SetActive(true); //Balloons win
        } 
        if (missed < count)
        {
            losePic.GetComponent<Image>().sprite = Resources.Load("win") as Sprite;
        }
	}
}
