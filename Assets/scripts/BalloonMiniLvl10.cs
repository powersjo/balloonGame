using UnityEngine;
using System.Collections;

public class BalloonMiniLvl10 : MonoBehaviour {

    float posx, posy, posz, speed;
    int health;
    public AudioSource pop;

    /*This works and the script is getting attached, need to move it up to the top
    change the colors and vary it up a bit. 
    */
    // Use this for initialization
    void Start () {
        posz = posx = 0;
        speed = UnityEngine.Random.Range(1.2F, 2.8F);
        posy = 8;
        pop = (AudioSource)gameObject.AddComponent<AudioSource>();
    }
    void OnMouseDown()
    {
        GameObject go = GameObject.Find("Master");
        CountPopped other = (CountPopped)go.GetComponent(typeof(CountPopped));
        other.IncreaseCount();
        AudioClip myAudioClip;
        myAudioClip = (AudioClip)Resources.Load("Pop Banner");
        pop.clip = myAudioClip;
        AudioSource.PlayClipAtPoint(pop.clip, transform.position);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Destroy")
        {
            GameObject go = GameObject.Find("Master");
            CountPopped other = (CountPopped)go.GetComponent(typeof(CountPopped));
            other.IncreaseMissed();
            other.subUserHealth();
            Destroy(this.gameObject);
        }
    }

        // Update is called once per frame
        void Update () {

        Vector3 targetPosition = new Vector3(posx, posy, posz);
        Vector3 targetOffset = new Vector3(0, 0, 0);
        Vector3 currentPosition = this.transform.position;
        if (Application.loadedLevel > 7)
        {
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