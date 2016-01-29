using UnityEngine;
using System.Collections;

public class CloudBehavior : MonoBehaviour {

    public int cloudNum;
    private int posx, posy;
    private float speed;
    private Vector3 targetPosition;
    // Use this for initialization
    void Start () {
        SetTarget(cloudNum);
    }
    private void SetTarget(int cloudNumber)
    {
        if (cloudNumber == 1)
        {
            speed = Random.Range(0.2F, 2.0F);
            posx = GetRandomXY(1);
            posy = GetRandomXY(0);
            targetPosition = new Vector3(posx, posy, -2);
        } else if (cloudNumber == 2)
        {
            speed = Random.Range(1.0F, 2.0F);
            posx = Random.Range(-2, 6);
            posy = 4;
            targetPosition = new Vector3(posx, posy, -2);
        }
    }
    // y = 0, x = else
    private int GetRandomXY(int y_or_x)
    {
        if (y_or_x == 0)
        {
            return Random.Range(-3, 1);
        }
        else
        {
            return Random.Range(-2, 2);
        }
    }

    // Update is called once per frame
    void Update () {

        Vector3 currentPosition = this.transform.position;
        //first, check to see if we're close enough to the target
        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {
            //Debug.Log("Update if");
            Vector3 directionOfTravel = targetPosition - currentPosition;
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
            SetTarget(cloudNum);
            //Debug.Log("Update else");
        }
    }


}
