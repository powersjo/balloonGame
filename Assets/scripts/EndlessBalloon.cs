using UnityEngine;
using System.Collections;

public class EndlessBalloon : MonoBehaviour {

    private GameObject balloon;
    private int amount;

    //This mini class is just to move the clones. 
    public class Move : MonoBehaviour
    {
        float posy, posx, speed;
        //public AudioSource pop;

        void Start()
        {
            posy = 10f; //How high does the balloon go?
            posx = Random.Range(-4f, 4f);
            speed = Random.Range(1f, 6f);
            //pop = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        void Update()
        {
            //move towards the center of the world (or where ever you like)
            Vector3 targetPosition = new Vector3(posx, posy, 0.0f);
            Vector3 targetOffset = new Vector3(0, 0, 0);
            Vector3 currentPosition = this.transform.position;
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
            else
            {
                GameObject go = GameObject.Find("Master");
                CountPopped other = (CountPopped)go.GetComponent(typeof(CountPopped));
                other.IncreaseMissed();
                Debug.Log("increase missed" + Time.deltaTime.ToString());
                Destroy(gameObject);
            }

        }
        
    }

    // Use this for initialization
    void Start () {
        balloon = GameObject.Find("Balloon");
        amount = 1; // Number of clones. 
    }

    public void setAmount(int x)
    {
        amount = x;
    }


    public void SpawnBaloons()
    {
        GameObject[] clone;
        clone = new GameObject[amount];

        for (int x = 0; x < amount; x++)
        {
            GameObject go = GameObject.Find("Master");
            go.GetComponent<GenBalloonEndless>().addToBalloonTracker(1);
            clone[x] = Instantiate(balloon, new Vector3(balloon.transform.position.x + (Random.Range(-4f, 4f)), balloon.transform.position.y, 0), balloon.transform.rotation) as GameObject;
            clone[x].GetComponentInChildren<DummyBalloon>().randomizeColor();
            clone[x].transform.parent = GameObject.Find("Master").transform; //set the clone to be a child of the balloon group game object
            clone[x].AddComponent<Move>();
            clone[x].gameObject.name = "Balloon" + go.GetComponent<GenBalloonEndless>().getBalloonNum();
        }
    }
}
