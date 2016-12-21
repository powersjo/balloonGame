using UnityEngine;
using System.Collections;

public class FirstSceneBalloon : MonoBehaviour {
    private GameObject balloon;
    private int amount;
    
    //This mini class is just to move the clones. 
    private class Move : MonoBehaviour { 
        float posy, posx, speed;

        void Start()
        {
            posy = 5f;
            posx = Random.Range(-4f, 4f);
            speed = Random.Range(1f, 6f);
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
            } else
            {
                Destroy(gameObject);
            }
        }
    }

	void Start () {
        balloon = GameObject.Find("Balloon");
        amount = 3; // Number of clones. 
        //SpawnBaloons();
    }

    public void SpawnBaloons()
    {
        GameObject[] clone;
        clone = new GameObject[amount];

        for (int x = 0; x < amount; x++)
        {
            clone[x] = Instantiate(balloon, new Vector3(this.transform.position.x + (Random.Range(-4f, 4f)), this.transform.position.y, 0), this.transform.rotation) as GameObject;
            clone[x].GetComponentInChildren<DummyBalloon>().randomizeColor();
            clone[x].transform.parent = GameObject.Find("BalloonGroup").transform; //set the clone to be a child of the balloon group game object
            clone[x].AddComponent<Move>();
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
