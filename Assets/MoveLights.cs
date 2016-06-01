using UnityEngine;
using System.Collections;

public class MoveLights : MonoBehaviour {

    private Vector3 directionOfTravel, currentPosition, targetPosition;
    private float time;

    void Start () {
        time = 2f;
        NewTarget();
        currentPosition = this.transform.position;
    }
    /**
    *   This method keeps the lights in a -2 by 2 box on the x and y axis. 
    **/
    private void NewTarget()
    {
        float xhigh = 1f;
        float xlow = -1f;
        float yhigh = 1f;
        float ylow = -1f;  
        if (this.transform.position.x > 2)
        {
            xhigh = xhigh * -1;
            xlow -= 2;
        }
        if (this.transform.position.x < -2)
        {
            xhigh += 2;
            xlow += 2;
        }
        if (this.transform.position.y > 2)
        {
            yhigh = yhigh * -1;
            ylow -= 2;
        }
        if (this.transform.position.y < -2)
        {
            yhigh += 2;
            ylow += 2;
        }
        targetPosition = new Vector3(UnityEngine.Random.Range(xlow, xhigh), UnityEngine.Random.Range(ylow, yhigh), 0.0f);
    }

    // Update is called once per frame
    void Update() {
        directionOfTravel = targetPosition;
        directionOfTravel.Normalize();

        this.transform.Translate(
        (directionOfTravel.x * UnityEngine.Random.Range(1, 5) * Time.deltaTime),
        (directionOfTravel.y * UnityEngine.Random.Range(1, 5) * Time.deltaTime),
        (directionOfTravel.z * UnityEngine.Random.Range(1, 5) * Time.deltaTime),
        Space.World);
        if (time > 0) { 
            time -= Time.deltaTime;
        }
        else
        {
            time = 2f;
            NewTarget();
        }
    }
}
