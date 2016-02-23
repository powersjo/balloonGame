using UnityEngine;
using System;

public class Balloon : MonoBehaviour {

    public float posx, posy, posz;
    public int armorCrack;
	public float time, speed;
	public AudioSource pop;
    private bool unclickable, armored, camo, duplicate, origonal;
    public bool move;
    private GameObject clone1, clone2, clone;
    public GameObject cloneMe;
    private Animation anim;

    // Use this for initialization
    void Awake()
    {
        move = origonal = true;
    }

    void Start() {
        unclickable = duplicate = false;
        posz = 0.0f;//UnityEngine.Random.Range(-0.2F, 0.5F);
        cloneMe = Resources.Load<GameObject>("Rope") as GameObject; //problem
        //cloneMe.AddComponent<Animator>();
        //cloneMe.AddComponent<Animation>();
        //anim = Resources.Load<Animation>("RopeAnimation") as Animation;
        
        
        //anim.animation = Resources.Load<Animation>("RopeAnimation") as Animation;
        //cloneMe.GetComponent<Animation>() = Resources.Load<Animation>("RopeAnimation") as Animation;
        armored = false;
        if (UnityEngine.Random.Range(0, (16 - Application.loadedLevel)) == 0 && Application.loadedLevel > 6)
        {
            armored = true;
        }
        if (UnityEngine.Random.Range(0, (14 - Application.loadedLevel)) == 0 && Application.loadedLevel > 8)
        {
            duplicate = true;

        } else
        {

        }
        posy = 8;
        armorCrack = 0;
        if (origonal) {
            time = GetRandomTime();
        }
		speed = UnityEngine.Random.Range (0.5F, 2.4F + (Application.loadedLevel * .1F));
		posx = UnityEngine.Random.Range (-3, 3);
		pop = (AudioSource)gameObject.AddComponent <AudioSource>();
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
        Sprite var = Resources.Load<Sprite>(balloonColors[UnityEngine.Random.Range(0,8)].ToString());
        try {
            balloonSR.sprite = var;
        } catch (NullReferenceException e)
        {
            //Who cares?
        }
        if (armored)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1.5F, 1.5F, 1.5F, 1.0F);

        }

        /*
        * I dont think that I should use Instantiate. 
        */

        //clone.transform.localPosition = new Vector3(0, 0, 0);
        //clone = (GameObject)Instantiate(cloneMe, new Vector3(this.transform.position.x + 2, this.transform.position.y - 3, 0), this.transform.rotation);
        //clone = Instantiate(cloneMe, transform.position, transform.rotation) as GameObject;
        //clone.transform.localPosition = new Vector3(0, 0, 0);
        //clone.transform.parent = this.transform;
        //clone.transform.localPosition = new Vector3(0, 0, 0); /////////////////////////////////// rope is almost working need to get to the right spot. 
    }

    int getBackgroundNum()
    {
        GameObject go = GameObject.Find("Master");
        CountPopped other = (CountPopped)go.GetComponent(typeof(CountPopped));
        return other.GetBackNum();
    }

    public void killTime()
    {
        time = -1.0F;
        origonal = false;
    }

    bool isPlanet()
    {
        GameObject go = GameObject.Find("Master");
        CountPopped other = (CountPopped)go.GetComponent(typeof(CountPopped));
        return other.GetHasPlanet();
    }
    
	void OnTriggerEnter(Collider collider){
		if (collider.name == "Destroy") {
			GameObject go = GameObject.Find ("Master");
			CountPopped other = (CountPopped)go.GetComponent (typeof(CountPopped));
			other.IncreaseMissed ();
			Destroy (this.gameObject);
		}
        if (collider.name == "Cloud")
        {
            unclickable = true;
        }
	}
    void OnTriggerExit(Collider collider)
    {
        if(collider.name == "Cloud")
        {
            unclickable = false;
        }
    }
    void OnMouseDown()
    {
        armorCrack++;
        if (!unclickable && !armored) { 
            GameObject go = GameObject.Find("Master");
            CountPopped other = (CountPopped)go.GetComponent(typeof(CountPopped));
            other.IncreaseCount();
            AudioClip myAudioClip;
            myAudioClip = (AudioClip)Resources.Load("Pop Banner");
            pop.clip = myAudioClip;
            AudioSource.PlayClipAtPoint(pop.clip, transform.position);
            if (duplicate)
            {
                duplicate = false;
                int lastx;
                float lasty, lastFloatx, lastFloaty;
                lastx = (int)this.transform.position.x;
                lasty = this.transform.position.y;
                lastFloatx = this.transform.localScale.x / 2;
                lastFloaty = this.transform.localScale.y / 2;
                
                clone1 = clone2 = new GameObject(); // I left off the clone1 and clone2 have the wrong y axis and don't move. 
                
                clone1 = Instantiate(this.gameObject, new Vector3(this.transform.position.x - 2, this.transform.position.y - 3, 0), this.transform.rotation) as GameObject;
                clone2 = (GameObject)Instantiate(this.gameObject, new Vector3(this.transform.position.x + 2, this.transform.position.y - 3, 0), this.transform.rotation);

                clone1.transform.localScale = new Vector3(.7F, 1.2F, 1);
                go.GetComponent<CountPopped>().increaseMaxTwo();
                clone1.GetComponent<Balloon>().killTime();
                clone2.GetComponent<Balloon>().killTime();
                clone2.transform.localScale = new Vector3(.7F, 1.2F, 1);
            }
            Destroy(this.gameObject);
        }
        if (armored && armorCrack == 2)
        {
            armored = false;
            gameObject.GetComponent<Renderer>().material.color = new Color(3.5F, 3.5F, 3.5F, 1.0F);
            AudioClip tinkAudioClip;
            tinkAudioClip = (AudioClip)Resources.Load("Tink");
            pop.clip = tinkAudioClip;
            AudioSource.PlayClipAtPoint(pop.clip, transform.position);
        }
        else if (armorCrack == 1 && armored)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(2.5F, 2.5F, 2.5F, 1.0F);
            AudioClip tinkAudioClip;
            tinkAudioClip = (AudioClip)Resources.Load("Tink");
            pop.clip = tinkAudioClip;
            AudioSource.PlayClipAtPoint(pop.clip, transform.position);
        }
	}   

    float GetRandomScale()
    {
        return UnityEngine.Random.Range(-.1F, 1.0F);
    }

	float GetRandomTime(){
		return UnityEngine.Random.Range (1.0F, 5.0F + (Application.loadedLevel * 5));
	}
    public static void MyDelay(int seconds)
    {
        DateTime ts = DateTime.Now + TimeSpan.FromSeconds(seconds);

        do { } while (DateTime.Now < ts);
    }
    // Update is called once per frame
    void Update () {
        if (time >= 0 && (clone1 == null || clone2 == null)) {
			time -= Time.deltaTime;
            if (!origonal)
            {
                time = -1F;
            }
		} else if (move == true){
			//move towards the center of the world (or where ever you like)
			Vector3 targetPosition = new Vector3 (posx, posy, 0.0f);
            Vector3 targetOffset = new Vector3(0,0,0);
			Vector3 currentPosition = this.transform.position;
            if (Application.loadedLevel > 7)
            {
                if (UnityEngine.Random.Range(0, (16 - Application.loadedLevel)) == 0) {
                    if(UnityEngine.Random.Range(0,1) == 0)
                    {
                        targetOffset += new Vector3(10,0,0); //right
                        posx = UnityEngine.Random.Range(-4, 4);
                    }
                    else
                    {
                        targetOffset += new Vector3(-10, 0, 0); //left
                        posx = UnityEngine.Random.Range(-4, 4);
                    }
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
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
            }
		}
	}
}
