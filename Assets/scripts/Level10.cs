using UnityEngine;
using System.Collections;
using System;

public class Level10 : MonoBehaviour
{

    private float posx, posy, posz, speed, offset;
    private GameObject music, go;
    private int health, screenW, screenH;
    String[] balloonColors;
    private bool mini, endGame, levelRunning;
    private GUIStyle currentStyle = new GUIStyle(GUI.skin.box);
    Texture2D healthUserTexture;
    Color userHealthColor;
    private CountPopped other;
    public AudioSource pop;

    // Use this for initialization
    void Start()
    {
        go = GameObject.Find("Master");
        music = GameObject.Find("MainMusic");
        music.GetComponent<MusicControl>().ChangeMusic("beware_theme"); //Level 10 boss Music
        mini = endGame = false;
        levelRunning = true;
        posx = offset = 0;
        posy = speed = 2;
        health = 25;
        pop = (AudioSource)gameObject.AddComponent<AudioSource>();
        userHealthColor = Color.green;
        screenW = Screen.width;
        screenH = Screen.height;
        go.GetComponent<CountPopped>().increaseMaxCustom(health);
        other = (CountPopped)go.GetComponent(typeof(CountPopped));
        SpriteRenderer balloonSR = gameObject.AddComponent<SpriteRenderer>();
        Sprite var = Resources.Load<Sprite>("Balloon/Black");
        try
        {
            balloonSR.sprite = var;
        }
        catch (NullReferenceException e)
        {
            //Who cares?
        }
        balloonColors = new String[8];
        balloonColors[0] = "Balloon/Blue";
        balloonColors[1] = "Balloon/Green";
        balloonColors[2] = "Balloon/Pink";
        balloonColors[3] = "Balloon/Red";
        balloonColors[4] = "Balloon/Yellow";
        balloonColors[5] = "Balloon/Orange";
        balloonColors[6] = "Balloon/Purple";
        balloonColors[7] = "Balloon/Light-Blue";
        healthUserTexture = new Texture2D(2, 2, TextureFormat.ARGB32, false);
        healthUserTexture.Apply();

    }

    void UpdateColor()
    {
        int temp = other.getUserHeatlth();
        if (temp < 16)
        {
            if(temp < 8)
            {
                userHealthColor = Color.red;
            } else
            {
                userHealthColor = Color.yellow;
            }
        }
    }

    private int GetTheHealth()
    {
        return -other.getUserHeatlth() * 5;
    }
    
    void OnGUI()
    {
        //CountPopped other = (CountPopped)go.GetComponent(typeof(CountPopped));
        GUI.Box(new Rect(Screen.width - 20, Screen.height - 45, 15, GetTheHealth()), "");
        //CountPopped other = (CountPopped)go.GetComponent(typeof(CountPopped));
        //healthUserTexture = new Texture2D(2, 2, TextureFormat.ARGB32, false);
        //healthUserTexture.Apply();
        //UpdateColor();
        //GUI.color = userHealthColor;
        //currentStyle.normal.background = healthUserTexture;
        //GUI.Box(new Rect(screenW / 9, screenH / 20, 100, screenH / 34), "test", currentStyle);
        //currentStyle.normal.background = healthUserTexture;
        //UpdateColor();
        //GUI.color = userHealthColor;/////////////////
        //GUI.Box(new Rect(screenW - (screenW * .07F), screenH - (screenH * .12F), 15, other.getUserHeatlth() * -5), "", new GUIStyle());
    }
    public int getBossHealth()
    {
        return health;
    }

    void SetMini()
    {
        mini = true;
    }

    int GetRandomInt()
    {
        return UnityEngine.Random.Range(0, 8);//with ints unity random range in excluding the last digit. so this one is 0, 1, 2, 3, 4, 5, 6 and 7. 
    }

    void OnMouseDown()
    {
        if (levelRunning)
        {
            health--;
            if (health < 1) 
            {
                Destroy(this.gameObject);
            }
            this.transform.localScale = new Vector3(this.transform.localScale.x * .90F, this.transform.localScale.y * .90F, 1);
            this.transform.GetComponent<SphereCollider>().radius = this.transform.GetComponent<SphereCollider>().radius * .96F;
            offset += .0001F; //this offset makes it so that the balloon recovers faster. 

            //make more balloons
            int lastx;
            float lasty, lastFloatx, lastFloaty;
            lastx = (int)this.transform.position.x;
            lasty = this.transform.position.y;
            lastFloatx = this.transform.localScale.x / 4;
            lastFloaty = this.transform.localScale.y / 4;
            GameObject clone1, clone2;
            clone1 = clone2 = new GameObject(); // I left off the clone1 and clone2 have the wrong y axis and don't move. 

            clone1 = Instantiate(this.gameObject, new Vector3(this.transform.position.x - 2, this.transform.position.y - 3, 0), this.transform.rotation) as GameObject;
            clone2 = (GameObject)Instantiate(this.gameObject, new Vector3(this.transform.position.x + 2, this.transform.position.y - 3, 0), this.transform.rotation);

            Destroy(clone1.GetComponent<Level10>());
            Destroy(clone2.GetComponent<Level10>());

            clone1.AddComponent<BalloonMiniLvl10>();
            clone2.AddComponent<BalloonMiniLvl10>();
            go.GetComponent<CountPopped>().increaseMaxTwo();
            AudioClip myAudioClip;
            String[] bossHits = new String[4];
            bossHits[0] = "Sounds/LevelTenBoss/hard punch";
            bossHits[1] = "Sounds/LevelTenBoss/oof";
            bossHits[2] = "Sounds/LevelTenBoss/hit";
            bossHits[3] = "Sounds/LevelTenBoss/punch";
            myAudioClip = (AudioClip)Resources.Load(bossHits[UnityEngine.Random.Range(0, 4)].ToString());
            pop.clip = myAudioClip;
            AudioSource.PlayClipAtPoint(pop.clip, transform.position);
            //add a new script to create the proper mini balloon. 


            /*clone1.GetComponent<Level10>().SetMini();
            clone1.transform.localScale = new Vector3(.7F, 1.2F, 1);
            go.GetComponent<CountPopped>().increaseMaxTwo();
            clone2.GetComponent<Level10>().SetMini();
            clone2.transform.localScale = new Vector3(.7F, 1.2F, 1);*/
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = new Vector3(posx, posy, posz);
        Vector3 targetOffset = new Vector3(0, 0, 0);
        Vector3 currentPosition = this.transform.position;
        if (UnityEngine.Random.Range(0, (16 - Application.loadedLevel)) == 0)
        {
            if (UnityEngine.Random.Range(0, 1) == 0)
            {
                targetOffset += new Vector3(10, 0, 0); //right
                posx = UnityEngine.Random.Range(-4, 4);
            }
            else
            {
                targetOffset += new Vector3(-10, 0, 0); //left
                posx = UnityEngine.Random.Range(-4, 4);
            }
        }
        //first, check to see if we're close enough to the target
        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition + targetOffset;
            //now normalize the direction, since we only want the direction information
            directionOfTravel.Normalize();
            //scale the movement on each axis by the directionOfTravel vector components

            this.transform.Translate(
            (directionOfTravel.x * speed * Time.deltaTime),
            (directionOfTravel.y * speed * Time.deltaTime),
            (directionOfTravel.z),
            Space.World);
        }
        if (this.transform.localScale.y > 5f || -GetTheHealth() < 1)  //Fail the level
        {
            endGame = true;
            other = (CountPopped)go.GetComponent(typeof(CountPopped));
            other.killUser();
            levelRunning = false;
        }
        if (!mini && !endGame)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x * (1.001F + offset), this.transform.localScale.y * (1.001F + offset), 1);
            this.transform.GetComponent<SphereCollider>().radius = this.transform.GetComponent<SphereCollider>().radius * (1.0002F + offset);
        }
    }
}
