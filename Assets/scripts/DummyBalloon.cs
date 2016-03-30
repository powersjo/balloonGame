﻿using UnityEngine;
using System.Collections;
using System;

public class DummyBalloon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float temp1, temp2; //Use temp1 for y and temp2 for x. 
        temp1 = GetRandomScale();
        temp2 = temp1 - UnityEngine.Random.Range(0.0f, 0.5f);
        transform.localScale += new Vector3(temp2, temp1, 0);
        SphereCollider localCollider = transform.GetComponent<SphereCollider>();
        localCollider.radius = 0.75f; // using .75 cause that's what seems to work.
        //This code sets the color of the balloon. 

        //This code will use sprites instead of changing the material color. 
        String[] balloonColors = new String[8];
        balloonColors[0] = "Balloon/Blue";
        balloonColors[1] = "Balloon/Green";
        balloonColors[2] = "Balloon/Pink";
        balloonColors[3] = "Balloon/Red";
        balloonColors[4] = "Balloon/Yellow";
        balloonColors[5] = "Balloon/Orange";
        balloonColors[6] = "Balloon/Purple";
        balloonColors[7] = "Balloon/Light-Blue";
        SpriteRenderer balloonSR = gameObject.AddComponent<SpriteRenderer>();
        Sprite var = Resources.Load<Sprite>(balloonColors[UnityEngine.Random.Range(0, 8)].ToString());
        try
        {
            balloonSR.sprite = var;
        }
        catch (NullReferenceException e)
        {
            //Who cares?
        }
    }
    private float GetRandomScale()
    {
        return UnityEngine.Random.Range(-.1F, 1.0F);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
